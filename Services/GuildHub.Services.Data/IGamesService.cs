namespace GuildHub.Services.Data
{
    using System.Collections.Generic;

    public interface IGamesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();
    }
}
