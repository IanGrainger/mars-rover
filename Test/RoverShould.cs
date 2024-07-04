using Rover;
using System.Text;

namespace Test;

[TestClass]
public class RoverShould
{
    [TestMethod]
    public void BePlacedByPlace()
    {
        var sut = new Rover.Rover(new CommandParser(), (_) => { });
        sut.ProcessCommandFile(StreamFromString("PLACE 1,2,NORTH"));

        Assert.AreEqual(Facing.NORTH, sut.Facing);
        Assert.AreEqual(1, sut.X);
        Assert.AreEqual(2, sut.Y);
    }

    [TestMethod]
    public void BeTurnedByLeft()
    {

        var sut = new Rover.Rover(new CommandParser(), (_) => { });
        sut.ProcessCommandFile(StreamFromString("PLACE 1,2,NORTH\nLEFT"));

        Assert.AreEqual(Facing.WEST, sut.Facing);
    }

    [TestMethod]
    public void BeTurnedByRight()
    {

        var sut = new Rover.Rover(new CommandParser(), (_) => { });
        sut.ProcessCommandFile(StreamFromString("PLACE 1,2,NORTH\nRIGHT"));

        Assert.AreEqual(Facing.EAST, sut.Facing);
    }

    [TestMethod]
    public void Report()
    {
        var outputAssertion = (string output) => { Assert.AreEqual("3,4,SOUTH", output); };
        var sut = new Rover.Rover(new CommandParser(), outputAssertion);
        sut.ProcessCommandFile(StreamFromString("PLACE 3,4,SOUTH\nREPORT"));
    }

    [TestMethod]
    public void BeMovedByMove()
    {
        var sut = new Rover.Rover(new CommandParser(), (_) => { });
        sut.ProcessCommandFile(StreamFromString("PLACE 3,4,SOUTH\nMOVE"));

        Assert.AreEqual(3, sut.X);
        Assert.AreEqual(3, sut.Y);
    }

    [TestMethod]
    public void Acceptance1()
    {
        var outputAssertion = (string output) => { Assert.AreEqual("0,1,NORTH", output); };
        var sut = new Rover.Rover(new CommandParser(), (_) => { });
        sut.ProcessCommandFile(StreamFromString("PLACE 0,0,NORTH\nMOVE\nREPORT"));
    }

    [TestMethod]
    public void Acceptance2()
    {
        var outputAssertion = (string output) => { Assert.AreEqual("0,0,WEST", output); };
        var sut = new Rover.Rover(new CommandParser(), (_) => { });
        sut.ProcessCommandFile(StreamFromString("PLACE 0,0,NORTH\nLEFT\nREPORT"));
    }

    [TestMethod]
    public void Acceptance3()
    {
        var outputAssertion = (string output) => { Assert.AreEqual("3,3,NORTH", output); };
        var sut = new Rover.Rover(new CommandParser(), (_) => { });
        sut.ProcessCommandFile(StreamFromString("PLACE 1,2,EAST\nMOVE\nMOVE\nLEFT\nMOVE\nREPORT"));
    }

    private static MemoryStream StreamFromString(string commands)
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(commands));
    }
}