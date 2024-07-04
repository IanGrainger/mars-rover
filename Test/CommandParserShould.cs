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
}