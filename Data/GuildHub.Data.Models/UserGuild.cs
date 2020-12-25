namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Models.Enums;

    public class UserGuild
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Guild))]
        public int GuildId { get; set; }

        public virtual Guild Guild { get; set; }

        public MemberType MemberType { get; set; }

        public int GuildPoints { get; set; }
    }
}
