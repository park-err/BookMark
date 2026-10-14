namespace BookMark.Data.Repositories.Interfaces
{
    public interface IWishlistRepository : IBaseRepository<WishlistEntity>
    {
        Task<WishlistEntity?> GetWishlistByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<WishlistEntity>> GetAllWishlistsAsync(CancellationToken cancellationToken = default);
        Task AddWishlistAsync(WishlistEntity wishlist, CancellationToken cancellationToken = default);
        Task UpdateWishlistAsync(WishlistEntity wishlist, CancellationToken cancellationToken = default);
        Task DeleteWishlistAsync(int id, CancellationToken cancellationToken = default);
    }
}
