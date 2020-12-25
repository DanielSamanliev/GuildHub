namespace GuildHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using GuildHub.Data.Common.Models;

    public class GTag : BaseDeletableModel<int>
    {
        public GTag()
        {
            this.Games = new HashSet<GameGTag>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<GameGTag> Games { get; set; }
    }
}
