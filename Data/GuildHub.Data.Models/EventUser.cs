namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventUser
    {
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
