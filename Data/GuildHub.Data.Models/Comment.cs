namespace GuildHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Models;

    public class Comment
    {
        public Comment()
        {
            this.Likes = new HashSet<LikeableEntityLike>();
        }

        [Key]
        [ForeignKey(nameof(LikeableEntity))]
        public int LikeableEntityId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ForumPostId { get; set; }

        public virtual ForumPost ForumPost { get; set; }

        public string Content { get; set; }

        public virtual ICollection<LikeableEntityLike> Likes { get; set; }
    }
}
