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
                GameTags = new List<GameTag> { new GameTag { TagId = 1 }, new GameTag { TagId = 6 }, new GameTag { TagId = 7 }, new GameTag { TagId = 8 } },
            });
            await dbContext.AddAsync(new Game
            {
                Name = "Destiny 2",
                Description = "Destiny 2 is a free-to-play online-only multiplayer first-person shooter video game developed by Bungie.",
                GameTags = new List<GameTag> { new GameTag { TagId = 4 }, new GameTag { TagId = 6 }, new GameTag { TagId = 7 }, new GameTag { TagId = 5 }, new GameTag { TagId = 9 } },
            });
            await dbContext.AddAsync(new Game
            {
                Name = "League of Legends",
                Description = "League of Legends is a 2009 multiplayer online battle arena video game developed and published by Riot Games for Microsoft Windows and macOS.",
                GameTags = new List<GameTag> { new GameTag { TagId = 2 }, new GameTag { TagId = 8 }, new GameTag { TagId = 7 } },
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
