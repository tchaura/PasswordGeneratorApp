namespace PasswordGeneratorApp.Tests;

using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

public class HomeControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HomeControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GeneratePassword_ShouldReturnPartialViewWithPassword()
    {
        // Arrange
        var client = _factory.CreateClient();
        var postData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Length", "12"),
            new KeyValuePair<string, string>("IncludeLowercase", "true"),
            new KeyValuePair<string, string>("IncludeUppercase", "true"),
            new KeyValuePair<string, string>("IncludeNumbers", "true"),
            new KeyValuePair<string, string>("IncludeSymbols", "true")
        });

        // Act
        var response = await client.PostAsync("/Home/GeneratePassword", postData);

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        // Check if the response contains the expected HTML elements
        Assert.Contains("Generated Password", responseString);
        Assert.Contains("Strength:", responseString);
    }
}
