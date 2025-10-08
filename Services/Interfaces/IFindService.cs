using EPiServer.Find.UnifiedSearch;
using System.Globalization;

namespace Optimizely002.Services.Interfaces;

public interface IFindService
{
    Task<UnifiedSearchResults> FindAsync(string query, CultureInfo cultureInfo);
}
