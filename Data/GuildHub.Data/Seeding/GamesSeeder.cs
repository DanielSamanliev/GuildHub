namespace GuildHub.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Data.Models;
    using GuildHub.Data.Models.Enums;

    public class GamesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Games.Any())
            {
                return;
            }

            await dbContext.AddAsync(new Game
            {
                Name = "World of Warcraft",
                Description = "World of Warcraft is a massively multiplayer online role-playing game released in 2004 by Blizzard Entertainment. It is the fourth released game that is set in the Warcraft fantasy universe.",
                GameTags = new List<GameGTag> { new GameGTag { GTagId = 1 }, new GameGTag { GTagId = 6 }, new GameGTag { GTagId = 7 }, new GameGTag { GTagId = 8 } },
            });
            await dbContext.AddAsync(new Game
            {
                Name = "Destiny 2",
                Description = "Destiny 2 is a free-to-play online-only multiplayer first-person shooter video game developed by Bungie.",
                GameTags = new List<GameGTag> { new GameGTag { GTagId = 4 }, new GameGTag { GTagId = 6 }, new GameGTag { GTagId = 7 }, new GameGTag { GTagId = 5 }, new GameGTag { GTagId = 9 } },
            });
            await dbContext.AddAsync(new Game
            {
                Name = "League of Legends",
                Description = "League of Legends is a 2009 multiplayer online battle arena video game developed and published by Riot Games for Microsoft Windows and macOS.",
                GameTags = new List<GameGTag> { new GameGTag { GTagId = 2 }, new GameGTag { GTagId = 8 }, new GameGTag { GTagId = 7 } },
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
