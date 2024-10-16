namespace PasswordGeneratorApp.Models;

public class PasswordOptions
{
    public int Length { get; init; }
    public bool IncludeUppercase { get; init; }
    public bool IncludeLowercase { get; init; }
    public bool IncludeNumbers { get; init; }
    public bool IncludeSymbols { get; init; }
}