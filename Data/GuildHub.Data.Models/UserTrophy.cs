namespace GuildHub.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserTrophy
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Trophy))]
        public int TrophyId { get; set; }

        public virtual Trophy Trophy { get; set; }

        public DateTime AwardedOn { get; set; }
    }
}
