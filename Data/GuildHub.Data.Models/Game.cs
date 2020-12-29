namespace GuildHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Common.Models;

    public class Game : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Website { get; set; }

        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }

        public virtual Image GameIcon { get; set; }

        public virtual ICollection<GameTag> GameTags { get; set; }

        public virtual ICollection<Guild> Guilds { get; set; }
    }
}
