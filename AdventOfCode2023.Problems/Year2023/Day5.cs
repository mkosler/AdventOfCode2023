namespace AdventOfCode2023.Problems.Year2023;

public class Day5 : IProblem
{
  private readonly string[] HEADERS = new string[]{ "seed-to-soil", "soil-to-fertilizer", "fertilizer-to-water", "water-to-light", "light-to-temperature", "temperature-to-humidity", "humidity-to-location" };

  public string Part1(IEnumerable<string> input)
  {
    var initialSeeds = GetInitialSeeds(input);
    var maps = HEADERS.ToDictionary(h => h, h => GetMappingSection(input, h));
    var lowestLocation = long.MaxValue;

    foreach (var seed in initialSeeds)
    {
      var soil = GetMappedDestinationValue(maps["seed-to-soil"], seed);
      var fertilizer = GetMappedDestinationValue(maps["soil-to-fertilizer"], soil);
      var water = GetMappedDestinationValue(maps["fertilizer-to-water"], fertilizer);
      var light = GetMappedDestinationValue(maps["water-to-light"], water);
      var temperature = GetMappedDestinationValue(maps["light-to-temperature"], light);
      var humidity = GetMappedDestinationValue(maps["temperature-to-humidity"], temperature);
      var location = GetMappedDestinationValue(maps["humidity-to-location"], humidity);

      if (location < lowestLocation) lowestLocation = location;
    }

    return $"{lowestLocation}";
  }

  public string Part2(IEnumerable<string> input)
  {
    var seedRanges = new List<(long SeedStart, long SeedRangeLength)>();
    var initialSeeds = GetInitialSeeds(input).ToList();
    var maps = HEADERS.ToDictionary(h => h, h => GetMappingSection(input, h));

    for (var i = 0; i < initialSeeds.Count; i += 2)
    {
      seedRanges.Add((initialSeeds[i], initialSeeds[i + 1]));
    }

    seedRanges = MapSeedRanges(maps["seed-to-soil"], seedRanges).ToList();
    seedRanges = MapSeedRanges(maps["soil-to-fertilizer"], seedRanges).ToList();
    seedRanges = MapSeedRanges(maps["fertilizer-to-water"], seedRanges).ToList();
    seedRanges = MapSeedRanges(maps["water-to-light"], seedRanges).ToList();
    seedRanges = MapSeedRanges(maps["light-to-temperature"], seedRanges).ToList();
    seedRanges = MapSeedRanges(maps["temperature-to-humidity"], seedRanges).ToList();
    seedRanges = MapSeedRanges(maps["humidity-to-location"], seedRanges).ToList();

    return $"{seedRanges.Min(r => r.SeedStart)}";

    // // foreach (var seed in initialSeeds)
    // // {
    // for (var i = 0; i < initialSeeds.Count; i += 2)
    // {
    //   for (var seed = initialSeeds[i]; seed < initialSeeds[i] + initialSeeds[i + 1]; seed++)
    //   {
    //     var soil = GetMappedDestinationValue(maps["seed-to-soil"], seed);
    //     var fertilizer = GetMappedDestinationValue(maps["soil-to-fertilizer"], soil);
    //     var water = GetMappedDestinationValue(maps["fertilizer-to-water"], fertilizer);
    //     var light = GetMappedDestinationValue(maps["water-to-light"], water);
    //     var temperature = GetMappedDestinationValue(maps["light-to-temperature"], light);
    //     var humidity = GetMappedDestinationValue(maps["temperature-to-humidity"], temperature);
    //     var location = GetMappedDestinationValue(maps["humidity-to-location"], humidity);

    //     if (location < lowestLocation) lowestLocation = location;
    //   }
    // }
  }

  private static IEnumerable<long> GetInitialSeeds(IEnumerable<string> input)
  {
    var seedsLine = input.First(l => l.Contains("seeds:"));

    return seedsLine[7..].Split(" ").Select(long.Parse);
  }

  private static IEnumerable<(long DestinationRangeStart, long SourceRangeStart, long RangeLength)> GetMappingSection(IEnumerable<string> input, string header)
  {
    var sections = string.Join(Environment.NewLine, input).Split("\r\n\r\n");
    var splitSection = sections.First(s => s.Contains(header)).Split(Environment.NewLine);

    return splitSection[1..]
      .Where(l => !string.IsNullOrEmpty(l))
      .Select(l => l.Split(" ").Select(long.Parse).ToList())
      .Select(x => (DestinationRangeStart: x[0], SourceRangeStart: x[1], RangeLength: x[2]));
  }

  private static long GetMappedDestinationValue(IEnumerable<(long DestinationRangeStart, long SourceRangeStart, long RangeLength)> ranges, long sourceValue)
  {
    foreach (var (DestinationRangeStart, SourceRangeStart, RangeLength) in ranges)
    {
      if (SourceRangeStart <= sourceValue && sourceValue < SourceRangeStart + RangeLength)
      {
        var diff = sourceValue - SourceRangeStart;

        return DestinationRangeStart + diff;
      }
    }

    return sourceValue;
  }

  private static IEnumerable<(long SeedStart, long SeedRangeLength)> MapSeedRanges(IEnumerable<(long DestinationRangeStart, long SourceRangeStart, long RangeLength)> ranges, IEnumerable<(long SeedStart, long SeedRangeLength)> seedRanges)
  {
    var newSeedRanges = new List<(long SeedStart, long SeedRangeLength)>();

    foreach (var seedRange in seedRanges)
    {
      newSeedRanges.AddRange(MapSeedRange(ranges, seedRange));
    }

    return newSeedRanges;
  }

  private static IEnumerable<(long SeedStart, long SeedRangeLength)> MapSeedRange(IEnumerable<(long DestinationRangeStart, long SourceRangeStart, long RangeLength)> ranges, (long SeedStart, long SeedRangeLength) seedRange)
  {
    var newSeedRanges = new List<(long SeedStart, long SeedRangeLength)>();
    var seedStart = seedRange.SeedStart;
    var seedRangeLength = seedRange.SeedRangeLength;
    var seedEnd = seedStart + seedRangeLength - 1;
    var points = new List<long>() { seedStart, seedEnd };

    foreach (var (DestinationRangeStart, SourceRangeStart, RangeLength) in ranges)
    {
      var sourceRangeEnd = SourceRangeStart + RangeLength - 1;

      if (seedStart <= SourceRangeStart && SourceRangeStart <= seedEnd)
      {
        points.Add(SourceRangeStart);
      }
      
      if (seedStart <= sourceRangeEnd && sourceRangeEnd <= seedEnd)
      {
        points.Add(sourceRangeEnd);
      }
    }

    points = points.OrderBy(p => p).ToList();

    for (var i = 0; i < points.Count - 1; i++)
    {
      var start = points[i];
      var range = points[i + 1] - points[i] + 1;
      var end = points[i + 1];

      if (ranges.Any(r => r.SourceRangeStart <= start && end < r.SourceRangeStart + r.RangeLength))
      {
        var (DestinationRangeStart, SourceRangeStart, RangeLength) = ranges.First(r => r.SourceRangeStart <= start && end < r.SourceRangeStart + r.RangeLength);
        var diff = DestinationRangeStart - SourceRangeStart;

        newSeedRanges.Add((start + diff, range));
      }
      else
      {
        newSeedRanges.Add((start, range));
      }
    }

    return newSeedRanges;
  }
}