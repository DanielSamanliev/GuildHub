namespace GuildHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Data.Common.Repositories;
    using GuildHub.Data.Models;
    using GuildHub.Data.Models.Enums;
    using GuildHub.Services.Mapping;
    using GuildHub.Web.ViewModels.Game;
    using GuildHub.Web.ViewModels.Guild;
    using GuildHub.Web.ViewModels.Image;
    using GuildHub.Web.ViewModels.Tag;

    public class GuildsService : IGuildService
    {
        private IDeletableEntityRepository<Guild> guildRepo;
        private IDeletableEntityRepository<Image> imagesRepo;
        private IRepository<GuildApplication> applicsRepo;
        private IRepository<UserGuild> membersRepo;

        public GuildsService(
            IDeletableEntityRepository<Guild> guildRepo,
            IDeletableEntityRepository<Image> imagesRepo,
            IRepository<GuildApplication> applicsRepo)
        {
            this.guildRepo = guildRepo;
            this.imagesRepo = imagesRepo;
            this.applicsRepo = applicsRepo;
        }

        public async Task CreateAsync(CreateGuildInputModel input, string userId)
        {
            var guild = new Guild()
            {
                Name = input.Name,
                Description = input.Description,
                GameId = input.GameId,
            };
            guild.GuildMembers.Add(new UserGuild() { UserId = userId, MemberType = MemberType.Leader });
            if (input.Private)
            {
                guild.Privacy = GuildPrivacy.Private;
            }
            else
            {
                guild.Privacy = GuildPrivacy.Public;
            }

            await this.guildRepo.AddAsync(guild);
            await this.guildRepo.SaveChangesAsync();
        }

        public ICollection<ListGuildInfo> GetUserGuilds(string userId)
        {
            var guilds = new List<ListGuildInfo>();

            if (userId == null)
            {
                return new List<ListGuildInfo>();
            }

            var userGuilds = this.guildRepo.AllAsNoTracking()
                .Where(x => x.GuildMembers.Any(gm => gm.UserId == userId))
                .Take(25)
                .Select(x => new ListGuildInfo
                {
                    GuildName = x.Name,
                    MembersCount = x.GuildMembers.Count(),
                    TrophiesCount = x.Trophies.Count(),
                    GuildDecription = x.Description,
                    GuidCrest = new ImageViewModel { Path = $"{x.GuildCrest.Id}.{x.GuildCrest.Extension}" },
                    Game = new GameViewModel { Name = x.Game.Name },
                    UserMemberType = x.GuildMembers.FirstOrDefault(gm => gm.UserId == userId).MemberType,
                    Tags = x.Tags.Select(t => new TagViewModel { Name = t.Tag.Name }).ToList(),
                }).ToList();


            return userGuilds;
        }

        public ICollection<ListGuildInfo> GetPublicGuilds()
        {
            var publicGuilds = this.guildRepo.AllAsNoTracking()
                .Where(x => x.Privacy == GuildPrivacy.Public)
                .Take(25)
                .Select(x => new ListGuildInfo
                {
                    GuildName = x.Name,
                    MembersCount = x.GuildMembers.Count(),
                    TrophiesCount = x.Trophies.Count(),
                    GuildDecription = x.Description,
                    GuidCrest = new ImageViewModel { Path = $"{x.GuildCrest.Id}.{x.GuildCrest.Extension}" },
                    Game = new GameViewModel { Name = x.Game.Name },
                    Tags = x.Tags.Select(t => new TagViewModel { Name = t.Tag.Name }).ToList(),
                }).ToList();

            return publicGuilds;
        }

        public async Task ApplyForGuildAsync(GuildApplicationInputModel input)
        {
            if (this.applicsRepo.AllAsNoTracking().Any(x => x.UserId == input.UserId || x.GuildId == input.Id))
            {
                return;
            }

            var guild = this.guildRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == input.Id);

            var application = new GuildApplication()
            {
                UserId = input.UserId,
                GuildId = input.Id,
                Message = input.ApplicationTemplate,
                Status = GuildAppStatus.Pending,
            };

            await this.applicsRepo.AddAsync(application);
            await this.applicsRepo.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var guild = this.guildRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return guild;
        }

        public async Task Accept(string userId, int guildId)
        {
            await this.membersRepo.AddAsync(new UserGuild
            {
                GuildId = guildId,
                UserId = userId,
            });
            await this.membersRepo.SaveChangesAsync();

            var application = this.applicsRepo.All().FirstOrDefault(x => x.UserId == userId && x.GuildId == guildId);
            this.applicsRepo.Delete(application);
            await this.applicsRepo.SaveChangesAsync();
        }

        public ICollection<T> GetGuildApplicationsGuild<T>(int guildId)
        {
            T[] applications = this.applicsRepo.AllAsNoTracking()
                .Where(x => x.GuildId == guildId)
                .To<T>()
                .ToArray();

            return applications;
        }
    }
}
