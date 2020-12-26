namespace GuildHub.Services.Data
{
    using System;
    using System.Linq;

    using GuildHub.Data.Common.Repositories;
    using GuildHub.Data.Models;
    using GuildHub.Web.ViewModels.Home;

    public class GetHomeInfoCounts : IGetHomeInfoCounts
    {
        private IDeletableEntityRepository<Game> gamesRepository;
        private IDeletableEntityRepository<Guild> guildsRepository;
        private IDeletableEntityRepository<ApplicationUser> usersRepository;
        private IDeletableEntityRepository<Event> eventsRepository;

        public GetHomeInfoCounts(
            IDeletableEntityRepository<Game> gamesRepository,
            IDeletableEntityRepository<Guild> guildsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Event> eventsRepository)
        {
            this.gamesRepository = gamesRepository;
            this.guildsRepository = guildsRepository;
            this.usersRepository = usersRepository;
            this.eventsRepository = eventsRepository;
        }

        public IndexViewModel GetCounts()
        {
            var currDate = DateTime.Now;
            var data = new IndexViewModel
            {
                GamesCount = this.gamesRepository.AllAsNoTracking().Count(),
                GuildsCount = this.guildsRepository.AllAsNoTracking().Count(),
                UsersCount = this.usersRepository.AllAsNoTracking().Count(),
                EventsCount = this.eventsRepository.AllAsNoTracking().Where(x => x.StartTime <= currDate || x.EndTime > currDate).Count(),
            };

            return data;
        }

        public int GetGamesCount()
        {
            return this.gamesRepository.AllAsNoTracking().Count();
        }

        public int GetGuildsCount()
        {
            return this.guildsRepository.AllAsNoTracking().Count();
        }

        public int GetPlayersCount()
        {
            return this.usersRepository.AllAsNoTracking().Count();
        }
    }
}
