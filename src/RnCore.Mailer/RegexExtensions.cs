using System.Text.RegularExpressions;

namespace RnCore.Mailer;

public static class RegexExtensions
{
  [Obsolete("Replace this")]
  public static bool MatchesRegex(this string input, string pattern) =>
    !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

  [Obsolete("Replace this")]
  public static MatchCollection GetRegexMatches(this string input, string pattern) =>
    Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
}
