namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Common.Models;
    using GuildHub.Data.Models.Enums;

    public class GuildApplication
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Guild))]
        public int GuildId { get; set; }

        public virtual Guild Guild { get; set; }

        public GuildAppStatus Status { get; set; }

        public string Message { get; set; }
    }
}
