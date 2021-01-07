namespace GuildHub.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Data.Models;

    public class ImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Images.Any(x => x.Id == "DefaultGuildIcon"))
            {
                return;
            }

            var defGuildIcon = new Image() { Extension = "png" };
            defGuildIcon.Id = "DefaultGuildIcon";

            await dbContext.AddAsync(defGuildIcon);
        }
    }
}
