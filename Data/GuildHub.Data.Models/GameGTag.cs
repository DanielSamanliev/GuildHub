namespace GuildHub.Data.Models
{

    using System.ComponentModel.DataAnnotations.Schema;

    public class GameGTag
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [ForeignKey(nameof(GTag))]
        public int GTagId { get; set; }

        public virtual GTag Tag { get; set; }
    }
}
