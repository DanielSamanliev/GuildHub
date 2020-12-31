namespace GuildHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserGame
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public string Username { get; set; }
    }
}
