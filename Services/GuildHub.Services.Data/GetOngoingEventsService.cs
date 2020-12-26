namespace GuildHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GuildHub.Data.Common.Repositories;
    using GuildHub.Data.Models;
    using GuildHub.Data.Models.Enums;

    public class GetOngoingEventsService : IGetOngoingEventsService
    {
        private IDeletableEntityRepository<Event> eventsRepsitory;
        private IDeletableEntityRepository<Guild> guildsRepository;
        private IDeletableEntityRepository<ApplicationUser> usersRepository;
        private IRepository<UserGuild> usersGuildsRepository;
        private IRepository<GuildAlly> alliesRepository;
        //private string userId;

        public GetOngoingEventsService(
            IDeletableEntityRepository<Event> eventsRepository,
            IDeletableEntityRepository<Guild> guildsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IRepository<UserGuild> usersGuildsRepository,
            IRepository<GuildAlly> alliesRepository
            //string userId
            )
        {
            this.eventsRepsitory = eventsRepository;
            this.guildsRepository = guildsRepository;
            this.usersGuildsRepository = usersGuildsRepository;
            this.usersRepository = usersRepository;
            this.alliesRepository = alliesRepository;
            //this.userId = userId;
        }

        public ICollection<Event> GetOngoingEvents()
        {
            throw new NotImplementedException();

            //var publicEvents = this.eventsRepsitory.AllAsNoTracking().Where(x => x.Privacy == EventPrivacy.Public).ToList();
            ////var guildEvents = this.eventsRepsitory.AllAsNoTracking().Where(x => x.Guild.GuildMembers.FirstOrDefault(u => u.UserId == this.userId) != null).ToList();
            //return guildEvents.Union(publicEvents).ToList();
            //// TODO: Add Allied Guilds Events
        }
    }
}
