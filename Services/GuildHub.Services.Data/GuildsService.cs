namespace GuildHub.Services.Data
{
    using System.Threading.Tasks;

    using GuildHub.Data.Common.Repositories;
    using GuildHub.Data.Models;
    using GuildHub.Web.ViewModels.Guild;

    public class GuildsService : IGuildService
    {
        private IDeletableEntityRepository<Guild> guildRepo;

        public GuildsService(
            IDeletableEntityRepository<Guild> guildRepo)
        {
            this.guildRepo = guildRepo;
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

            await this.guildRepo.AddAsync(guild);
            await this.guildRepo.SaveChangesAsync();
        }
    }
}
