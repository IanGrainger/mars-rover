using Rover;

namespace Test;

[TestClass]
public class CommandParserShould
{
    [TestMethod]
    public void ReturnPlaceWhenPlaceIsFirstInString()
    {
        var sut = new CommandParser();
        var command = sut.Parse("PLACE 1,2,NORTH");
        Assert.IsInstanceOfType(command, typeof(PlaceCommand));
        var placeCommand = command as PlaceCommand;
        Assert.AreEqual(1, placeCommand?.X);
        Assert.AreEqual(2, placeCommand?.Y);
        Assert.AreEqual(Facing.NORTH, placeCommand?.Facing);
    }

    [TestMethod]
    public void ReturnLeft()
    {
        var sut = new CommandParser();
        var command = sut.Parse("LEFT");
        Assert.IsInstanceOfType(command, typeof (LeftCommand));
    }

    [TestMethod]
    public void ReturnRight()
    {
        var sut = new CommandParser();
        var command = sut.Parse("RIGHT");
        Assert.IsInstanceOfType(command, typeof(RightCommand));
    }

    [TestMethod]
    public void ReturnReport()
    {
        var sut = new CommandParser();
        var command = sut.Parse("REPORT");
        Assert.IsInstanceOfType(command, typeof(ReportCommand));
    }

    [TestMethod]
    public void ReturnMove()
    {
        var sut = new CommandParser();
        var command = sut.Parse("MOVE");
        Assert.IsInstanceOfType(command, typeof(MoveCommand));
    }

    [DataTestMethod]
    [DataRow("UNKNOWN")]
    [DataRow("report")]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow("%%£%!£!)(")]
    [DataRow("\n\n")]
    public void ErrorOnUnknownCommand(string commandText)
    {
        var sut = new CommandParser();
        Assert.ThrowsException<ArgumentException>(() => sut.Parse(commandText));
    }

    [DataTestMethod]
    [DataRow("PLACE A,1,SOUTH")]
    [DataRow("PLACE 0,%,SOUTH")]
    public void FormatExceptionOnInvalidPlaceInts(string commandText)
    {
        var sut = new CommandParser();
        Assert.ThrowsException<FormatException>(() => sut.Parse(commandText));
    }

    [DataTestMethod]
    [DataRow("PLACE 1,1,egeih6£&%")]
    [DataRow("PLACE 0,0,R")]
    [DataRow("PLACE 0,0,1")]
    public void ErrorOnInvalidPlaceFacing(string commandText)
    {
        var sut = new CommandParser();
        Assert.ThrowsException<ArgumentException>(() => sut.Parse(commandText));
    }
}