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

    public string GetPassword()
    {
        string password;
        
        try
        {
            password = _pwdGenerator.Next();
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentException("Password options are invalid");
        }

        if (password.Contains("Password length invalid"))
        {
            throw new ArgumentOutOfRangeException(password);
        }

        return password;
    }
}