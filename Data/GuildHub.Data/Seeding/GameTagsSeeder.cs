namespace GuildHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Data.Models;

    public class GameTagsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.GTags.Any())
            {
                return;
            }

            await dbContext.GTags.AddAsync(new GTag { Name = "MMORPG" }); // 1
            await dbContext.GTags.AddAsync(new GTag { Name = "MOBA" }); // 2
            await dbContext.GTags.AddAsync(new GTag { Name = "RPG" }); // 3
            await dbContext.GTags.AddAsync(new GTag { Name = "MMO" }); // 4
            await dbContext.GTags.AddAsync(new GTag { Name = "FPS" }); // 5
            await dbContext.GTags.AddAsync(new GTag { Name = "PvE" }); // 6
            await dbContext.GTags.AddAsync(new GTag { Name = "PvP" }); // 7
            await dbContext.GTags.AddAsync(new GTag { Name = "Fantasy" }); // 8
            await dbContext.GTags.AddAsync(new GTag { Name = "Sci-Fi" }); // 9

            await dbContext.SaveChangesAsync();
        }
    }
}
