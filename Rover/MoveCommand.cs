namespace Rover
{
    public class MoveCommand: ICommand
    {

        public MoveCommand() {
        }

        public void Execute(Rover rover) {
            // todo: don't fall over the edge
            switch (rover.Facing)
            {
                case Facing.EAST:
                    rover.X++;
                    break;

                case Facing.SOUTH:
                    rover.Y--;
                    break;

                case Facing.WEST:
                    rover.X--;
                    break;

                case Facing.NORTH:
                    rover.Y++;
                    break;
            }
        }
    }
}
