namespace BookMark.Data.Repositories.Interfaces
{
    public interface IWishlistItemRepository : IBaseRepository<WishlistItemEntity>
    {
        Task<WishlistItemEntity?> GetWishlistItemByIdAsync(int wishlistId, string bookId, CancellationToken cancellationToken = default);
        Task<IEnumerable<WishlistItemEntity>> GetAllWishlistItemsByIdAsync(int wishlistId, CancellationToken cancellationToken = default);
        Task AddWishlistItemAsync(WishlistItemEntity wishlistItem, CancellationToken cancellationToken = default);
        Task UpdateWishlistItemAsync(WishlistItemEntity wishlistItem, CancellationToken cancellationToken = default);
        Task DeleteWishlistItemAsync(int id, CancellationToken cancellationToken = default);
    }
}
