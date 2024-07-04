namespace Rover
{
    public class CommandParser
    {
        public ICommand Parse(string? commandStr)
        {
            _ = commandStr ?? throw new ArgumentException("Null command");
            var parts = commandStr.Split(' ');
            if (parts.Length < 1) { throw new ArgumentException("Empty command"); }
            switch (parts[0])
            {
                case "PLACE":
                    return ParsePlaceCommand(parts[1]);
                case "LEFT":
                    return new LeftCommand();
                case "RIGHT":
                    return new RightCommand();
                case "REPORT":
                    return new ReportCommand();
                case "MOVE":
                    return new MoveCommand();
            }
            throw new ArgumentException($"Unrecognised command {commandStr}");
        }

        private ICommand ParsePlaceCommand(string locationAndFacing)
        {
            var args = locationAndFacing.Split(',');
            if (args.Length < 3)
            {
                throw new ArgumentException($"PLACE command requires 3 arguments <X,Y,F>, provided: {locationAndFacing}");
            }

            // todo: these will throw an exception if not integers
            var x = int.Parse(args[0]);
            var y = int.Parse(args[1]);
            var f = (Facing)Enum.Parse(typeof(Facing), args[2]);
            return new PlaceCommand(x, y, f);
        }
    }
}