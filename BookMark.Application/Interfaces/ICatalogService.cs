namespace BookMark.Application.Interfaces
{
    public interface ICatalogService
    {
        Task<string> GetBookAsync(string query);
    }
}
