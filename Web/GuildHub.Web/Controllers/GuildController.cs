namespace GuildHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Data.Models;
    using GuildHub.Services.Data;
    using GuildHub.Web.ViewModels.Guild;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class GuildController : BaseController
    {
        private readonly IGamesService gamesService;
        private readonly IGuildService guildService;
        private UserManager<ApplicationUser> userManager;

        public GuildController(
            IGamesService gamesService,
            IGuildService guildService,
            UserManager<ApplicationUser> userManager)
        {
            this.gamesService = gamesService;
            this.guildService = guildService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateGuildInputModel();
            viewModel.GamesKeyValue = this.gamesService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateGuildInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.GamesKeyValue = this.gamesService.GetAllAsKeyValuePair();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.guildService.CreateAsync(input, user.Id);

            return this.Redirect("/");
        }

        public async Task<IActionResult> GuildsList()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var guilds = new ListGuildsViewModel { Guilds = this.guildService.GetGuilds(user.Id) };

            return this.View(guilds);
        }
    }
}
