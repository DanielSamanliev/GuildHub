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

            return this.Redirect("All");
        }

        public async Task<IActionResult> All()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var model = new GuildIndexModel();

            if (user != null)
            {
                model.UserGuilds = this.guildService.GetUserGuilds(user.Id);
            }

            model.PublicGuilds = this.guildService.GetPublicGuilds();

            return this.View(model);
        }

        public IActionResult ById(int id)
        {
            var guild = this.guildService.GetById<SingleGuildViewModel>(id);

            return this.View(guild);
        }

        public async Task<IActionResult> Apply(int id)
        {
            var guild = this.guildService.GetById<GuildApplicationInputModel>(id);
            var user = await this.userManager.GetUserAsync(this.User);
            guild.UserId = user.Id;

            return this.View(guild);
        }
    }
}
