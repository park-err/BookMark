namespace BookMark.Data.Repositories.Interfaces
{
    public interface IOwnedBooksRepository : IBaseRepository<OwnedBooksEntity>
    {
        Task<OwnedBooksEntity?> GetOwnedBookByIdAsync(int userId, string bookId, CancellationToken cancellationToken = default);
        Task<IEnumerable<OwnedBooksEntity>> GetOwnedBooksByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task AddOwnedBookAsync(OwnedBooksEntity ownedBook, CancellationToken cancellationToken = default);
        Task UpdateOwnedBookAsync(OwnedBooksEntity ownedBook, CancellationToken cancellationToken = default);
        Task DeleteOwnedBookAsync(int userId, string bookId, CancellationToken cancellationToken = default);
    }
}
