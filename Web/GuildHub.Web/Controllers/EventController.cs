namespace GuildHub.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GuildHub.Services.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EventController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;

        public EventController(
            UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> OngoingEvents()
        {
            throw new NotImplementedException();
        }
    }
}
