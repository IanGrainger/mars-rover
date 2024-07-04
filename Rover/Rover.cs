
namespace Rover;

public class Rover
{
    public int X;
    public int Y;
    public Facing Facing;
    public CommandParser CommandParser;
    public Action<string> Reporter;

    public Rover(CommandParser parser, Action<string> reporter)
    {
        CommandParser = parser;
        Reporter = reporter;
    }

    // todo: move to a RoverManager class?
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
