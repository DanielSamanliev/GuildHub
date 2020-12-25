namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class GuildAlly
    {
        [ForeignKey(nameof(Guild))]
        public int GuildOneId { get; set; }

        public virtual Guild GuildOne { get; set; }

        [ForeignKey(nameof(Guild))]
        public int GuildTwoId { get; set; }

        public virtual Guild GuildTwo { get; set; }
    }
}
