using PasswordGenerator;
using PasswordGeneratorApp.Models;

namespace PasswordGeneratorApp.Utils;

public class PasswordGenerator(PasswordOptions options)
{
    private readonly Password _pwdGenerator = new(includeLowercase: options.IncludeLowercase,
        includeUppercase: options.IncludeUppercase,
        includeNumeric: options.IncludeNumbers,
        includeSpecial: options.IncludeSymbols,
        passwordLength: options.Length);

    public string GetPassword() => _pwdGenerator.Next();
}