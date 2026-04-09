namespace Lab11.Tests;

public class CellTests
{
    Cell testCell = new(2,1);

    [SetUp]
    public void Setup()
    {
    }

    // I don't really know what else to test about the Cell struct
    [Test]
    public void CellPropertyTest()
    {
        Assert.That(testCell, Has.Property("X").EqualTo(2));
        Assert.That(testCell, Has.Property("Y").EqualTo(1));
    }
}