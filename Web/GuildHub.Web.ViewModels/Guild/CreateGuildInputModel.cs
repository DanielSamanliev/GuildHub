namespace GuildHub.Web.ViewModels.Guild
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateGuildInputModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Game")]
        public int GameId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GamesKeyValue { get; set; }

        public bool Private { get; set; }
    }
}
