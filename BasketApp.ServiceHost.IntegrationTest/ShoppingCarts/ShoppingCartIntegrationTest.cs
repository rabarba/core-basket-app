using BasketApp.ServiceHost.Api.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BasketApp.ServiceHost.IntegrationTest.ShoppingCarts
{
    public class ShoppingCartIntegrationTest
    {
        [Theory]
        [InlineData("5f048f0bfd90440a2cc14119")]
        public async Task Add_Product_To_Not_Existing_ShoppingCart_Should_Return_Cart_Id(string productId)
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;

            // Act
            var response = await httpClient.PostAsync($"/api/shoppingcarts/{productId}", new StringContent("{}", Encoding.UTF8, "application/json"));
            var cartId = JsonConvert.DeserializeObject<HttpServiceResponseBase<string>>(await response.Content.ReadAsStringAsync()).Data;

            // Assert
            cartId.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("5f048f0bfd90440a2cc14119", "5f04b245d959ed40e0b5b8fd")]
        public async Task Add_Product_To_Existing_ShoppingCart_Should_Return_Cart_Id(string productId, string cartId)
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;
            var content = JsonConvert.SerializeObject(new { cartId });

            // Act
            var response = await httpClient.PostAsync($"/api/shoppingcarts/{productId}", new StringContent(content, Encoding.UTF8, "application/json"));
            cartId = JsonConvert.DeserializeObject<HttpServiceResponseBase<string>>(await response.Content.ReadAsStringAsync()).Data;

            // Assert
            cartId.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
