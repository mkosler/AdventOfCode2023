namespace AdventOfCode2023.Test;

public class Year2023Day2 : AdventOfCodeTestBase<Problems.Year2023.Day2>
{
  public Year2023Day2() : base(2023, 2)
  {
  }

  [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
  [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2)]
  [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 0)]
  [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 0)]
  [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5)]
  [Test, TestOf(nameof(Problems.Year2023.Day2.Part1))]
  public void Year2023Day2_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day2.Part1))]
  public void Year2023Day2_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(2512));
  }

  [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
  [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
  [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
  [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
  [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
  [Test, TestOf(nameof(Problems.Year2023.Day2.Part2))]
  public void Year2023Day2_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day2.Part2))]
  public void Year2023Day2_Part2_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(67335));
  }
}