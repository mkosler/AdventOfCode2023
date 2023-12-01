namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2015.Day2))]
public class Year2015Day2 : AdventOfCodeTestBase<Problems.Year2015.Day2>
{
    public Year2015Day2() : base(2015, 2)
    {
    }

    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    [Test, TestOf(nameof(Problems.Year2015.Day2.Part1))]
    public void Year2015Day2_Part1_Examples(string input, int expected)
    {
        // Arrange
        var lines = input.Split(Environment.NewLine);

        // Act
        var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test, TestOf(nameof(Problems.Year2015.Day2.Part1))]
    public void Year2015Day2_Part1_Solution()
    {
        // Act
        var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

        // Assert
        Assert.That(result, Is.EqualTo(1598415));
    }
}