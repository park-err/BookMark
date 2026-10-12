using BookMark.Data.Data;
using BookMark.Data.Repositories;
using BookMark.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMark.Data
{
    public static class DependencyInjection
    {
        public static string ConnectionStringName { get; set; } = "BookMarkConnection";
        /// <summary>
        /// Registers BookMark DbContext and repository services using a connection string from configuration.
        /// Looks for a connection string with the given name "BookMarkConnection".
        /// </summary>
        public static IServiceCollection AddBookMarkData(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                // allow reading direct value from configuration section as fallback
                connectionString = configuration[ConnectionStringName];
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException($"Connection string '{ConnectionStringName}' not found in configuration.");
            }

            return services.AddBookMarkData(connectionString);
        }

        /// <summary>
        /// Registers BookMark DbContext and repository services using the provided SQL Server connection string.
        /// </summary>
        public static IServiceCollection AddBookMarkData(this IServiceCollection services, string connectionString)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<BookMarkDbContext>(options => options.UseSqlServer(connectionString));

            // Register repositories
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IWishlistItemRepository, WishlistItemRepository>();
            services.AddScoped<IReadBooksRepository, ReadBooksRepository>();
            services.AddScoped<IOwnedBooksRepository, OwnedBooksRepository>();

            return services;
        }
    }
}
