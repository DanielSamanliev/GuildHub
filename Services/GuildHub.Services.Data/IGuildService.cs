namespace GuildHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GuildHub.Data.Models;
    using GuildHub.Web.ViewModels.Guild;

    public interface IGuildService
    {
        Task CreateAsync(CreateGuildInputModel input, string userId);

        ICollection<ListGuildInfo> GetUserGuilds(string userId);

        ICollection<ListGuildInfo> GetPublicGuilds();

        T GetById<T>(int id);

        public ICollection<T> GetGuildApplicationsGuild<T>(int guildId);

        public Task Accept(string userId, int guildId);
    }
}
