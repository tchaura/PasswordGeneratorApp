namespace PasswordGeneratorApp.Utils;


public class PasswordStrengthCalculator(string password)
{
    private readonly Zxcvbn.Result _strengthScore = Zxcvbn.Core.EvaluatePassword(password);

    private static readonly Dictionary<int, string> StrengthStrings = new()
    {
        { 0, "Very Weak" },
        { 1, "Weak" },
        { 2, "Normal" },
        { 3, "Strong" },
        { 4, "Very strong" }
    };

    public string GetStrength() => StrengthStrings[_strengthScore.Score];
}