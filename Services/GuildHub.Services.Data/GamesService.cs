namespace GuildHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GuildHub.Data.Common.Repositories;
    using GuildHub.Data.Models;

    public class GamesService : IGamesService
    {
        private IDeletableEntityRepository<Game> gamesRepo;

        public GamesService(IDeletableEntityRepository<Game> gamesRepo)
        {
            this.gamesRepo = gamesRepo;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.gamesRepo.AllAsNoTracking()
                .Select(x => new
                {
                    x.Name,
                    x.Id,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Name, x.Id.ToString()));
        }
    }
}
