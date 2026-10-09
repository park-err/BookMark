namespace BookMark.Server.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient client;
        private readonly string apiKey;

        public CatalogService(HttpClient client, Microsoft.Extensions.Options.IOptions<BookMark.Server.Config.GoogleBooksOptions> options)
        {
            this.client = client ?? throw new System.ArgumentNullException(nameof(client));
            var value = options?.Value ?? throw new System.ArgumentNullException(nameof(options));
            apiKey = value.ApiKey ?? throw new System.InvalidOperationException("GoogleBooksApi:ApiKey is not configured.");
        }

        public async Task<string> GetBookAsync(string query)
        {
            using HttpResponseMessage response = await client.GetAsync($"/books/v1/volumes?q={System.Uri.EscapeDataString(query ?? string.Empty)}&key={apiKey}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
    }
}
