
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Problems.Year2023;

public class Day19 : IProblem
{
  private static IDictionary<string, ParameterExpression> PARAMS = new Dictionary<string, ParameterExpression>
  {
    ["x"] = Expression.Parameter(typeof(int), "x"),
    ["m"] = Expression.Parameter(typeof(int), "m"),
    ["a"] = Expression.Parameter(typeof(int), "a"),
    ["s"] = Expression.Parameter(typeof(int), "s"),
  };

  public string Part1(IEnumerable<string> input)
  {
    var split = string.Join(Environment.NewLine, input).Split("\r\n\r\n");
    var workflows = GenerateWorkflows(split[0].Split(Environment.NewLine).Where(l => !string.IsNullOrEmpty(l)));

    var sum = 0;

    foreach (var obj in split[1].Split(Environment.NewLine).Where(l => !string.IsNullOrEmpty(l)))
    {
      var match = Regex.Match(obj, @"{x=(\d+),m=(\d+),a=(\d+),s=(\d+)}");
      var x = int.Parse(match.Groups[1].Value);
      var m = int.Parse(match.Groups[2].Value);
      var a = int.Parse(match.Groups[3].Value);
      var s = int.Parse(match.Groups[4].Value);

      Expression wf = workflows["in"];

      while (true)
      {
        var lambda = Expression.Lambda<Func<int, int, int, int, string>>(wf, PARAMS.Values);
        var val = lambda.Compile()(x, m, a, s);

        if (val == "A")
        {
          sum += x + m + a + s;
          break;
        }
        else if (val == "R")
        {
          break;
        }

        wf = workflows[val];
      }
    }
  
    return $"{sum}";
  }

  public string Part2(IEnumerable<string> input)
  {
    throw new NotImplementedException();
  }

  private static IDictionary<string, Expression> GenerateWorkflows(IEnumerable<string> input)
  {
    var workflows = new Dictionary<string, Expression>();

    foreach (var workflow in input)
    {
      var match = Regex.Match(workflow, @"(.+){(.*)}");
      var name = match.Groups[1].Value;
      workflows.Add(name, GenerateExpressionFromString(match.Groups[2].Value));
    }

    return workflows;
  }

  private static Expression GenerateExpressionFromString(string s)
  {
    var exprs = new Stack<(Expression Condition, Expression IfTrue)>();

    var pieces = s.Split(",");

    foreach (var p in pieces[..^1])
    {
      var match = Regex.Match(p, @"(\w+)([><])(\d+):(\w+)");

      var left = PARAMS[match.Groups[1].Value];
      var right = Expression.Constant(int.Parse(match.Groups[3].Value));
      var condition = match.Groups[2].Value switch
      {
        ">" => Expression.GreaterThan(left, right),
        "<" => Expression.LessThan(left, right),
        _ => throw new Exception("Unknown parameter")
      };

      exprs.Push((condition, Expression.Constant(match.Groups[4].Value)));
    }

    Expression current = Expression.Constant(pieces.Last());

    while (exprs.TryPop(out var result)) current = Expression.Condition(result.Condition, result.IfTrue, current);

    return current;
  }
}