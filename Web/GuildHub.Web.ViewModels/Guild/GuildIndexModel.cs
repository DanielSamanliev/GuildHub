﻿namespace GuildHub.Web.ViewModels.Guild
{
    using System.Collections.Generic;

    using GuildHub.Web.ViewModels.Guild;

    public class GuildIndexModel
    {
        public ICollection<ListGuildInfo> UserGuilds { get; set; }

        public ICollection<ListGuildInfo> PublicGuilds { get; set; }

        public GuildApplicationInputModel ApplicationInput { get; set; }
    }
}
