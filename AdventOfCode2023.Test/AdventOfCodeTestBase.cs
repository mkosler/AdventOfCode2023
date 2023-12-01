using AdventOfCode2023.Problems;
using AdventOfCode2023.Utility;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode2023.Test;

public class AdventOfCodeTestBase<T> where T : IProblem
{
  protected readonly IConfigurationRoot Config;
  protected string? File { get; private set; }
  protected IEnumerable<string> Input { get; private set; } = new List<string>();
  protected T? Problem { get; private set; }
  private readonly int _year;
  private readonly int _day;

  public AdventOfCodeTestBase(int year, int day)
  {
    Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    _year = year;
    _day = day;
  }

  [SetUp]
  public virtual async Task SetUp()
  {
    Problem = Activator.CreateInstance<T>();

    File = await WebUtility.GetFile($"inputs/{_year}/day{_day}.txt", Config["Session"], _year, _day);
    Input = File.Split("\n");
  }
}