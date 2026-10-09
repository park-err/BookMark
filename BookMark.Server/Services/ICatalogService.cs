namespace BookMark.Server.Services
{
    public interface ICatalogService
    {
        Task<string> GetBookAsync(string query);
    }
}
