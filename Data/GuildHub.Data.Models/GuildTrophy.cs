namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class GuildTrophy
    {
        [ForeignKey(nameof(Guild))]
        public int GuildId { get; set; }

        public virtual Guild Guild { get; set; }

        [ForeignKey(nameof(Trophy))]
        public int TrophyId { get; set; }

        public virtual Trophy Trophy { get; set; }
    }
}
