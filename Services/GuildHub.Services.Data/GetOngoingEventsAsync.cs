namespace GuildHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Data.Common.Repositories;
    using GuildHub.Data.Models;
    using GuildHub.Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;

    public class GetOngoingEventsAsync : IGetOngoingEventsServiceAsync
    {
        private IDeletableEntityRepository<Event> eventsRepsitory;
        private IDeletableEntityRepository<Guild> guildsRepository;
        private IDeletableEntityRepository<ApplicationUser> usersRepository;
        private IRepository<UserGuild> usersGuildsRepository;
        private IRepository<GuildAlly> alliesRepository;

        public GetOngoingEventsAsync(
            IDeletableEntityRepository<Event> eventsRepository,
            IDeletableEntityRepository<Guild> guildsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IRepository<UserGuild> usersGuildsRepository,
            IRepository<GuildAlly> alliesRepository)
        {
            this.eventsRepsitory = eventsRepository;
            this.guildsRepository = guildsRepository;
            this.usersGuildsRepository = usersGuildsRepository;
            this.usersRepository = usersRepository;
            this.alliesRepository = alliesRepository;
        }

        public async Task<ICollection<Event>> GetOngoingEvents()
        {
            throw new NotImplementedException();

            //var events = new List<Event>();
            //eventsRepsitory.AllAsNoTracking()
            //    .Where(x => x.Guild.GuildMembers.Any(x => x.UserId == this.userId))
            //    .Where(x => x.Guild.Allies.Where(g => g.GuildTwo.GuildMembers.Any(u => u.UserId == this.userId) || g.GuildTwo.GuildMembers.Any(u => u.UserId == this.userId)));
        }
    }
}
