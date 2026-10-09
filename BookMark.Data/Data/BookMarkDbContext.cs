using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace BookMark.Data.Data
{
    public class BookMarkDbContext(DbContextOptions<BookMarkDbContext> options) : DbContext(options)
    {

    }
}
