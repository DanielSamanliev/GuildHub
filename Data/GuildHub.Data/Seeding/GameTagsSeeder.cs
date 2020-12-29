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
            if (dbContext.Tags.Any())
            {
                return;
            }

            await dbContext.Tags.AddAsync(new Tag { Name = "MMORPG", Type = Models.Enums.TagType.Game }); // 1
            await dbContext.Tags.AddAsync(new Tag { Name = "MOBA", Type = Models.Enums.TagType.Game }); // 2
            await dbContext.Tags.AddAsync(new Tag { Name = "RPG", Type = Models.Enums.TagType.Game }); // 3
            await dbContext.Tags.AddAsync(new Tag { Name = "MMO", Type = Models.Enums.TagType.Game }); // 4
            await dbContext.Tags.AddAsync(new Tag { Name = "FPS", Type = Models.Enums.TagType.Game }); // 5
            await dbContext.Tags.AddAsync(new Tag { Name = "PvE", Type = Models.Enums.TagType.Both }); // 6
            await dbContext.Tags.AddAsync(new Tag { Name = "PvP", Type = Models.Enums.TagType.Both }); // 7
            await dbContext.Tags.AddAsync(new Tag { Name = "Fantasy", Type = Models.Enums.TagType.Game }); // 8
            await dbContext.Tags.AddAsync(new Tag { Name = "Sci-Fi", Type = Models.Enums.TagType.Game }); // 9

            await dbContext.SaveChangesAsync();
        }
    }
}
