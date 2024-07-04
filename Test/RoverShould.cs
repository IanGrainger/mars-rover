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

    [DataTestMethod]
    [DataRow("PLACE 0,0,NORTH\nMOVE\nREPORT", "0,1,NORTH")]
    [DataRow("PLACE 0,0,NORTH\nLEFT\nREPORT", "0,0,WEST")]
    [DataRow("PLACE 1,2,EAST\nMOVE\nMOVE\nLEFT\nMOVE\nREPORT", "3,3,NORTH")]
    public void Acceptance(string commands, string expectedOutput)
    {
        ProcessCommandsAndAssertExpectedOutput(commands, expectedOutput);
    }

    [DataTestMethod]
    [DataRow("MOVE\nMOVE\nPLACE 1,2,NORTH\nMOVE\nREPORT", "1,3,NORTH")]
    [DataRow("RIGHT\nMOVE\nRIGHT\nPLACE 1,2,EAST\nMOVE\nMOVE\nRIGHT\nMOVE\nREPORT", "3,1,SOUTH")]
    public void NotMoveUntilPlaced(string commands, string expectedOutput)
    {
        ProcessCommandsAndAssertExpectedOutput(commands, expectedOutput);
    }

    [DataTestMethod]
    [DataRow("PLACE 0,1,WEST\nMOVE\nREPORT", "0,1,WEST")]
    [DataRow("PLACE 2,0,SOUTH\nMOVE\nREPORT", "2,0,SOUTH")]
    [DataRow("PLACE 5,0,EAST\nMOVE\nREPORT", "5,0,EAST")]
    [DataRow("PLACE 3,5,NORTH\nMOVE\nREPORT", "3,5,NORTH")]
    public void NotFallOffTable(string commands, string expectedOutput)
    {
        ProcessCommandsAndAssertExpectedOutput(commands, expectedOutput);
    }

    private static void ProcessCommandsAndAssertExpectedOutput(string commands, string expectedOutput)
    {
        // otherwise test will pass without checking output
        Assert.IsTrue(commands.EndsWith("\nREPORT"));

        var outputAssertion = (string output) => { Assert.AreEqual(expectedOutput, output); };
        var sut = new Rover.Rover(new CommandParser(), outputAssertion);
        sut.ProcessCommandFile(StreamFromString(commands));
    }

    private static MemoryStream StreamFromString(string commands)
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(commands));
    }
}