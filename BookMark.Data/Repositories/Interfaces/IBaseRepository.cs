namespace BookMark.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
