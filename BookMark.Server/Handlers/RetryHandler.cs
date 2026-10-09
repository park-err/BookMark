namespace BookMark.Server.Handlers
{
    public class RetryHandler : DelegatingHandler
    {
        private readonly int maxRetries = 3;

        public RetryHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            for (int retries = 0; retries < maxRetries; retries++ )
            {
                try
                {
                    var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                        return response;

                    // Retry on server errors
                    if ((int)response.StatusCode >= 500)
                    {
                        retries++;
                        await Task.Delay(System.TimeSpan.FromSeconds(System.Math.Pow(2, retries)), cancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    return response;
                }
                catch (HttpRequestException)
                {
                    retries++;
                    // exponential backoff
                    await Task.Delay(System.TimeSpan.FromSeconds(System.Math.Pow(2, retries)), cancellationToken).ConfigureAwait(false);
                    continue;
                }
            }
            throw new HttpRequestException($"Request to Google Books failed after {maxRetries} retries.");
        }
    }
}
