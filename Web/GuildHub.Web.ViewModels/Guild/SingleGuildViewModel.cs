namespace GuildHub.Web.ViewModels.Guild
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using GuildHub.Data.Models;
    using GuildHub.Services.Mapping;

    public class SingleGuildViewModel : IMapFrom<Guild>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string GameName { get; set; }

        public int GameId { get; set; }

        public IEnumerable<SingleGuildPlayerInfoModel> Members { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Guild, SingleGuildViewModel>()
                .ForMember(x => x.Members, opt =>
                opt.MapFrom(x => x.GuildMembers.Select(m => new SingleGuildPlayerInfoModel {
                    Username = m.User.UserName,
                    InGameUsername = m.User.Games.Where(g => g.Game.Name == this.GameName).FirstOrDefault().Username,
                    MemberType = m.MemberType.ToString(),
                    MemberTypeValue = (int)m.MemberType,
                })
                .ToArray()
                .OrderByDescending(x => x.MemberTypeValue)
                .ToArray()));
        }
    }
}
