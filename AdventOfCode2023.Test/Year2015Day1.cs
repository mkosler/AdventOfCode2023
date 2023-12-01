namespace AdventOfCode2023.Test;

[TestFixture, TestOf(typeof(Problems.Year2015.Day1))]
public class Year2015Day1 : AdventOfCodeTestBase<Problems.Year2015.Day1>
{
    public Year2015Day1() : base(2015, 1)
    {
    }

    [TestCase("(())", 0)]
    [TestCase("(((", 3)]
    [TestCase("(()(()(", 3)]
    [TestCase("))(((((", 3)]
    [TestCase("())", -1)]
    [TestCase("))(", -1)]
    [TestCase(")))", -3)]
    [TestCase(")())())", -3)]
    [Test, TestOf(nameof(Problems.Year2015.Day1.Part1))]
    public void Year2015Day1_Part1_Examples(string input, int expected)
    {
        // Arrange
        var lines = input.Split(Environment.NewLine);

        // Act
        var result = int.Parse(Problem?.Part1(lines) ?? throw new NullReferenceException());

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test, TestOf(nameof(Problems.Year2015.Day1.Part1))]
    public void Year2015Day1_Part1_Solution()
    {
        // Act
        var result = int.Parse(Problem?.Part1(Input) ?? throw new NullReferenceException());

        // Assert
        Assert.That(result, Is.EqualTo(280));
    }

    [TestCase(")", 1)]
    [TestCase("()())", 5)]
    [Test, TestOf(nameof(Problems.Year2015.Day1.Part2))]
    public void Year2015Day1_Part2_Examples(string input, int expected)
    {
        // Arrange
        var lines = input.Split(Environment.NewLine);

        // Act
        var result = int.Parse(Problem?.Part2(lines) ?? throw new NullReferenceException());

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test, TestOf(nameof(Problems.Year2015.Day1.Part2))]
    public void Year2015Day1_Part2_Solution()
    {
        // Act
        var result = int.Parse(Problem?.Part2(Input) ?? throw new NullReferenceException());

        // Assert
        Assert.That(result, Is.EqualTo(1797));
    }
}