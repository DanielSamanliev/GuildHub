namespace GuildHub.Web.ViewModels.Guild
{
    using System.ComponentModel.DataAnnotations;

    using GuildHub.Data.Models;
    using GuildHub.Services.Mapping;

    public class GuildApplicationInputModel : IMapFrom<Guild>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Application Message")]
        public string ApplicationTemplate { get; set; }
    }
}
