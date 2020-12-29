namespace GuildHub.Services.Data
{
    using System.Threading.Tasks;

    using GuildHub.Data.Models;
    using GuildHub.Web.ViewModels.Guild;

    public interface IGuildService
    {
        Task CreateAsync(CreateGuildInputModel input, string userId);
    }
}
