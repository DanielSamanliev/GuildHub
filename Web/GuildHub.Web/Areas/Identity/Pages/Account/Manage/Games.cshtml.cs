using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuildHub.Web.Areas.Identity.Pages.Account.Manage
{
    public class GamesModel : PageModel
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public void OnGet()
        {

        }
    }
}
