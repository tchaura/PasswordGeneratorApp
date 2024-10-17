namespace PasswordGeneratorApp.Tests;

using Utils;
using Xunit;

public class PasswordStrengthCalculatorTests
{
    [Theory]
    [InlineData("12345", "Very Weak")]
    [InlineData("password123", "Weak")]
    [InlineData("fFEfsefegfr", "Normal")]
    [InlineData("Str0ngPass!", "Strong")]
    [InlineData("Sup3rStr0ngPass!", "Very strong")]
    public void GetStrength_ShouldReturnCorrectStrengthBasedOnPassword(string password, string expectedStrength)
    {
        // Arrange
        var calculator = new PasswordStrengthCalculator(password);

        // Act
        var strength = calculator.GetStrength();

        // Assert
        Assert.Equal(expectedStrength, strength);
    }
}
