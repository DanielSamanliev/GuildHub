namespace GuildHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using GuildHub.Data.Common.Models;
    using GuildHub.Data.Models.Enums;

    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            this.Games = new HashSet<GameTag>();
            this.Guilds = new HashSet<GuildTag>();
        }

        [Required]
        public string Name { get; set; }

        public TagType Type { get; set; }

        public virtual ICollection<GameTag> Games { get; set; }

        public virtual ICollection<GuildTag> Guilds { get; set; }
    }
}
