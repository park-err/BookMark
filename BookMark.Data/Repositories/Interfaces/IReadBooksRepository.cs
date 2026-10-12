namespace BookMark.Data.Repositories.Interfaces
{
    public interface IReadBooksRepository : IBaseRepository<ReadBooksEntity>
    {
        Task<ReadBooksEntity?> GetReadBookByBookIdAsync(int userId, string bookId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReadBooksEntity>> GetAllReadBooksByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task AddReadBookAsync(ReadBooksEntity readBook, CancellationToken cancellationToken = default);
        Task UpdateReadBookAsync(ReadBooksEntity readBook, CancellationToken cancellationToken = default);
        Task DeleteReadBookAsync(int userId, string bookId, CancellationToken cancellationToken = default);
    }
}
