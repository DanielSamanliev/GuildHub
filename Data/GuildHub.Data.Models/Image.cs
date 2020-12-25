namespace GuildHub.Data.Models
{
    using GuildHub.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public string Extension { get; set; }

        // Image stored in local
    }
}
