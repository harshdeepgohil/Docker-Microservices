using Microsoft.AspNetCore.Mvc.Testing;

namespace ProductsIntegrationTests
{
    public class ProductsIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public ProductsIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task GetProducts_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/api/Products/GetProducts");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Test", content); // Adjust to your expected result
        }
    }
}
