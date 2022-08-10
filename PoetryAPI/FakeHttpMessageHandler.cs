namespace PoetryAPI
{
    /// <summary>
    /// A Fake Http message handler for mock testing.
    /// </summary>
    public class FakeHttpMessageHandler : DelegatingHandler
    {
        private HttpResponseMessage _fakeResponse;

        /// <summary>
        /// Initialises a new instance of the FakeHttpMessageHandler class.
        /// </summary>
        public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            _fakeResponse = responseMessage;
        }

        /// <summary>
        /// Returns a fake response when mocking a request to the API for testing.
        /// </summary>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_fakeResponse);
        }
    }
}
