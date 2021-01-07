namespace GuildHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Common.Models;
    using GuildHub.Data.Models.Enums;

    public class Guild : BaseDeletableModel<int>
    {
        public Guild()
        {
            this.GuildMembers = new HashSet<UserGuild>();
            this.Allies = new HashSet<GuildAlly>();
            this.Trophies = new HashSet<GuildTrophy>();
            this.GuildApiKey = Guid.NewGuid().ToString();
            this.Tags = new HashSet<GuildTag>();
            this.Applicants = new HashSet<GuildApplication>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }

        public virtual Image GuildCrest { get; set; }

        public virtual ICollection<UserGuild> GuildMembers { get; set; }

        public virtual ICollection<GuildAlly> Allies { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public GuildPrivacy Privacy { get; set; }

        [Required]
        public string GuildApiKey { get; set; }

        public virtual ICollection<GuildTrophy> Trophies { get; set; }

        public virtual ICollection<GuildTag> Tags { get; set; }

        public virtual ICollection<GuildApplication> Applicants { get; set; }
    }
}
