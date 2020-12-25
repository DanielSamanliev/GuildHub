namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class LikeableEntityLike
    {
        [ForeignKey(nameof(LikeableEntity))]
        public int LikeableEntityId { get; set; }

        public virtual LikeableEntity Entity { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
