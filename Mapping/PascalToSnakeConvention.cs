using System.Text.RegularExpressions;

using Dapper.FluentMap.Conventions;

namespace DataAccess.Mapping;

public class PascalToSnakeConvention : Convention
{
  public PascalToSnakeConvention()
  {
    // Adds underscores before every capital letter except
    // the first letter, then converts to lowercase
    MatchEvaluator matchEvaluator = new(AddUnderscores);
    Properties()
      .Configure(c =>
        c.Transform(s =>
          Regex.Replace(
            input: s,
            pattern: "(?<=[A-Za-z0-9])([A-Z])",
            evaluator: matchEvaluator
          ).ToLower()
        )
      );
  }
  static string AddUnderscores(Match m)
  {
    // Adds underscore in front of every capture group
    return $"_{m.Groups[1].Value}";
  }
}