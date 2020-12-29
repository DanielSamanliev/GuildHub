namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;


    public class GuildTag
    {
        [ForeignKey(nameof(Guild))]
        public int GuildId { get; set; }

        public virtual Guild Guild { get; set; }


        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
