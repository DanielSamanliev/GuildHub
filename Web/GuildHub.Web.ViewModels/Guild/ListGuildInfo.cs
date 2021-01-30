namespace GuildHub.Web.ViewModels.Guild
{
    using System.Collections.Generic;

    using GuildHub.Data.Models.Enums;
    using GuildHub.Web.ViewModels.Game;
    using GuildHub.Web.ViewModels.Image;
    using GuildHub.Web.ViewModels.Tag;

    public class ListGuildInfo
    {
        public int GuildId { get; set; }

        public string GuildName { get; set; }

        public string GuildDecription { get; set; }

        public int MembersCount { get; set; }

        public MemberType UserMemberType { get; set; }

        public ImageViewModel GuidCrest { get; set; }

        public int TrophiesCount { get; set; }

        public GameViewModel Game { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }
    }
}
