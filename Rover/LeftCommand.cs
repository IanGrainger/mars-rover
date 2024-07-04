namespace Rover
{
    public class LeftCommand: ICommand
    {

        public LeftCommand() {
        }

        public void Execute(Rover rover) {
            if (!rover.IsPlaced)
            {
                return;
            }

            switch (rover.Facing)
            {
                case Facing.EAST:
                    rover.Facing = Facing.NORTH;
                    break;

                case Facing.NORTH:
                    rover.Facing = Facing.WEST;
                    break;

                case Facing.WEST:
                    rover.Facing = Facing.SOUTH;
                    break;

                case Facing.SOUTH:
                    rover.Facing = Facing.EAST;
                    break;
            }
        }
    }
}
