namespace GuildHub.Web.Controllers
{
    using System.Diagnostics;

    using GuildHub.Services.Data;
    using GuildHub.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private IGetHomeInfoCounts getHomeInfoCounts;
        private readonly IGetOngoingEventsServiceAsync getOngoingEventsService;

        public HomeController(
            IGetHomeInfoCounts getHomeInfoCounts,
            IGetOngoingEventsServiceAsync getOngoingEventsService)
        {
            this.getHomeInfoCounts = getHomeInfoCounts;
            this.getOngoingEventsService = getOngoingEventsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.getHomeInfoCounts.GetCounts();
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
