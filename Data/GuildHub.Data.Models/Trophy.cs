namespace GuildHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Common.Models;
    using GuildHub.Data.Models.Enums;

    public class Trophy : BaseDeletableModel<int>
    {
        public Trophy()
        {
            this.UsersWithTrophy = new HashSet<UserTrophy>();
            this.GuildsWithTrophy = new HashSet<GuildTrophy>();
        }

        [Required]
        public string Name { get; set; }

        public TrophyType TrophyType { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Image")]
        public string ImageId { get; set; }

        public virtual Image TrophyIcon { get; set; }

        public virtual ICollection<UserTrophy> UsersWithTrophy { get; set; }

        public virtual ICollection<GuildTrophy> GuildsWithTrophy { get; set; }
    }
}
