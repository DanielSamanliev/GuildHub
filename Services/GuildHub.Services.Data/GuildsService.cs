namespace GuildHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Data.Common.Repositories;
    using GuildHub.Data.Models;
    using GuildHub.Data.Models.Enums;
    using GuildHub.Web.ViewModels.Game;
    using GuildHub.Web.ViewModels.Guild;
    using GuildHub.Web.ViewModels.Image;
    using GuildHub.Web.ViewModels.Tag;

    public class GuildsService : IGuildService
    {
        private IDeletableEntityRepository<Guild> guildRepo;
        private IDeletableEntityRepository<Image> imagesRepo;

        public GuildsService(
            IDeletableEntityRepository<Guild> guildRepo,
            IDeletableEntityRepository<Image> imagesRepo)
        {
            this.guildRepo = guildRepo;
            this.imagesRepo = imagesRepo;
        }
        public async Task CreateAsync(CreateGuildInputModel input, string userId)
        {
            var guild = new Guild()
            {
                Name = input.Name,
                Description = input.Description,
                GameId = input.GameId,
            };
            guild.GuildMembers.Add(new UserGuild() { UserId = userId, MemberType = GuildHub.Data.Models.Enums.MemberType.Leader });
            if (input.Private)
            {
                guild.Privacy = GuildPrivacy.Private;
            }
            else
            {
                guild.Privacy = GuildPrivacy.Public;
            }

            guild.GuildCrest = this.imagesRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == "DefaultGuildIcon");

            await this.guildRepo.AddAsync(guild);
            await this.guildRepo.SaveChangesAsync();
        }

        public ICollection<Guild> GetGuilds(string userId)
        {
            //var userGuilds = this.guildRepo.AllAsNoTracking()
            //    .Where(x => x.GuildMembers.Any(gm => gm.UserId == userId))
            //    .Select(x => new ListGuildInfo
            //    {
            //        GuildName = x.Name,
            //        MembersCount = x.GuildMembers.Count(),
            //        TrophiesCount = x.Trophies.Count(),
            //        GuildDecription = x.Description,
            //        GuidCrest = new ImageViewModel { Path = $"{x.GuildCrest.Id}.{x.GuildCrest.Extension}" },
            //        Game = new GameViewModel { Name = x.Game.Name },
            //        UserMemberType = x.GuildMembers.FirstOrDefault(gm => gm.UserId == userId).MemberType,
            //    }).ToList();

            List<Guild> guilds = new List<Guild>();

            if (userId != null)
            {
                guilds.AddRange(this.guildRepo.AllAsNoTracking()
                .Where(x => x.GuildMembers.Any(gm => gm.UserId == userId))
                .ToList());
            }

            guilds.Union(this.guildRepo.AllAsNoTracking().Where(x => x.Privacy == 0).ToList());

            return guilds;
        }
    }
}
