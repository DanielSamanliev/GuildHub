namespace GuildHub.Services.Data
{
    using System.Collections.Generic;

    using GuildHub.Data.Models;

    public interface IGetOngoingEventsService
    {
        ICollection<Event> GetOngoingEvents();
    }
}
