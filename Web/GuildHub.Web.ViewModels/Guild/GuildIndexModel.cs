namespace GuildHub.Web.ViewModels.Guild
{
    using System.Collections.Generic;

    using GuildHub.Web.ViewModels.Guild;

    public class GuildIndexModel
    {
        public GuildIndexModel()
        {
            this.UserGuilds = new List<ListGuildInfo>();
            this.PublicGuilds = new List<ListGuildInfo>();
        }

        public ICollection<ListGuildInfo> UserGuilds { get; set; }

        public ICollection<ListGuildInfo> PublicGuilds { get; set; }

        public GuildApplicationInputModel ApplicationInput { get; set; }
    }
}
