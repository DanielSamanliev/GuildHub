namespace GuildHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GuildHub.Data.Common.Models;
    using GuildHub.Data.Models.Enums;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.Participants = new HashSet<EventUser>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int? PointValue { get; set; }

        [ForeignKey(nameof(Guild))]
        public int GuildId { get; set; }

        public virtual Guild Guild { get; set; }

        public EventPrivacy Privacy { get; set; }

        public virtual ICollection<EventUser> Participants { get; set; }
    }
}
