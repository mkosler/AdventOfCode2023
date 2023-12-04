namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2023.Day4))]
public class Year2023Day4 : AdventOfCodeTestBase<Problems.Year2023.Day4>
{
  public Year2023Day4() : base(2023, 4)
  {
  }

  [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
  [TestCase("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
  [TestCase("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
  [TestCase("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
  [TestCase("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
  [TestCase("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
  [Test, TestOf(nameof(Problems.Year2023.Day4.Part1))]
  public void Year2023Day4_Part1_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day4.Part1))]
  public void Year2023Day4_Part1_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(21959));
  }

  [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\r\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\r\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\r\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\r\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\r\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 30)]
  [Test, TestOf(nameof(Problems.Year2023.Day4.Part2))]
  public void Year2023Day4_Part2_Examples(string input, int expected)
  {
    // Arrange
    var lines = input.Split(Environment.NewLine);

    // Act
    var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test, TestOf(nameof(Problems.Year2023.Day4.Part2))]
  public void Year2023Day4_Part2_Solution()
  {
    // Act
    var result = int.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

    // Assert
    Assert.That(result, Is.EqualTo(5132675));
  }
}
