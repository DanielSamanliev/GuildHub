namespace GuildHub.Web.ViewModels.Guild
{
    using System.ComponentModel.DataAnnotations;

    public class GuildApplicationInputModel
    {
        public int GuildId { get; set; }

        public string GuildName { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Application Message")]
        public string Message { get; set; }
    }
}
