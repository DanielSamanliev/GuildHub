namespace GuildHub.Services.Data
{
    using GuildHub.Web.ViewModels.Home;

    public interface IGetHomeInfoCounts
    {
        IndexViewModel GetCounts();
    }
}
