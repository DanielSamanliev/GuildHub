namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Models;

    public class ForumPost
    {
        [Key]
        [ForeignKey(nameof(LikeableEntity))]
        public int LikeableEntityId { get; set; }

        public virtual LikeableEntity Entity { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
