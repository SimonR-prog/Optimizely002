namespace Optimizely002.Services.Interfaces
{
    public interface IDescendantService
    {
        IEnumerable<T> GetDescendantsOfType<T>(PageData pageData) where T : class;
    }
}
