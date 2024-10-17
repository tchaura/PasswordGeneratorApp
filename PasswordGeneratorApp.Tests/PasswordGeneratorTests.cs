namespace PasswordGeneratorApp.Tests;

using PasswordGeneratorApp.Models;
using PasswordGeneratorApp.Utils;
using Xunit;

public class PasswordGeneratorTests
{
    [Fact]
    public void GetPassword_ShouldGeneratePasswordWithGivenOptions()
    {
        // Arrange
        var options = new PasswordOptions
        {
            Length = 10,
            IncludeLowercase = true,
            IncludeUppercase = false,
            IncludeNumbers = true,
            IncludeSymbols = false
        };
        var generator = new PasswordGenerator(options);

        // Act
        var password = generator.GetPassword();

        // Assert
        Assert.Equal(10, password.Length);
        Assert.Matches(@"[a-z0-9]", password);
        Assert.DoesNotMatch(@"[A-Z]", password);
        Assert.DoesNotMatch(@"[\W_]", password);  // No special characters
    }

    [Fact]
    public void GetPasswordWithNoOptions_ShouldThrowArgumentException()
    {
        // Arrange
        var options = new PasswordOptions
        {
            Length = 10,
            IncludeLowercase = false,
            IncludeNumbers = false,
            IncludeSymbols = false,
            IncludeUppercase = false
        };
        var generator = new PasswordGenerator(options);
        
        // Assert
        Assert.Throws<ArgumentException>(() => generator.GetPassword());
    }
    
    [Fact]
    public void GetPasswordWithInvalidLength_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var options = new PasswordOptions
        {
            Length = -1,
            IncludeLowercase = false,
            IncludeNumbers = false,
            IncludeSymbols = false,
            IncludeUppercase = false
        };
        var generator = new PasswordGenerator(options);
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => generator.GetPassword());
    }
}
