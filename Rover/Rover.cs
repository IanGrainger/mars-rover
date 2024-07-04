
namespace Rover;

public class Rover
{
    public int X = 0;
    public int Y = 0;
    public Facing Facing = Facing.NORTH;
    public CommandParser CommandParser;
    public Action<string> Reporter;
    public bool IsPlaced = false;

    public Rover(CommandParser parser, Action<string> reporter)
    {
        CommandParser = parser;
        Reporter = reporter;
    }

    public void ProcessCommandFile(Stream inputStream)
    {
        using var textStream = new StreamReader(inputStream);
        while (!textStream.EndOfStream)
        {
            var command = CommandParser.Parse(textStream.ReadLine());
            command.Execute(this);
        }
    }
}
