using BookMark.Data.Data;
using BookMark.Data.Repositories.Interfaces;

namespace BookMark.Data.Repositories
{
    public class WishlistRepository : BaseRepository<WishlistEntity>, IWishlistRepository
    {
        public WishlistRepository(BookMarkDbContext context) : base(context) { }
        public async Task<WishlistEntity?> GetWishlistByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }
        public async Task<IEnumerable<WishlistEntity>> GetAllWishlistsAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }
        public async Task AddWishlistAsync(WishlistEntity wishlist, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(wishlist);
            await SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateWishlistAsync(WishlistEntity wishlist, CancellationToken cancellationToken)
        {
            _dbSet.Update(wishlist);
            await SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteWishlistAsync(int id, CancellationToken cancellationToken)
        {
            var wishlist = await _dbSet.FindAsync(id);
            if (wishlist != null)
            {
                _dbSet.Remove(wishlist);
                await SaveChangesAsync(cancellationToken);
            }
        }
    }
}
