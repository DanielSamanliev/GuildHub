namespace GuildHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GuildHub.Data.Models;

    public interface IGetOngoingEventsServiceAsync
    {
        Task<ICollection<Event>> GetOngoingEvents();
    }
}
