using EPiServer.Find;
using EPiServer.Find.Framework;
using EPiServer.Find.UnifiedSearch;
using Optimizely002.Services.Interfaces;
using System.Globalization;

namespace Optimizely002.Services
{
    public class FindService : IFindService
    {
        public async Task<UnifiedSearchResults> FindAsync(string query, CultureInfo cultureInfo)
        {
            var searchClient = SearchClient.Instance;
            var language = new Language(cultureInfo.Name, "default", cultureInfo.TwoLetterISOLanguageName, "porter", null, null, null);
            var result = await searchClient.UnifiedSearchFor(query, language).GetResultAsync();

            return result;
        }
    }
}
