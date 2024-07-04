namespace Rover
{
    public class MoveCommand: ICommand
    {
        private const int TABLE_SIZE_X = 5;
        private const int TABLE_SIZE_Y = 5;

        public MoveCommand() {
        }

        public void Execute(Rover rover) {
            


            switch (rover.Facing)
            {
                case Facing.EAST:
                    if (rover.X < TABLE_SIZE_X)
                    {
                        rover.X++;
                    }
                    break;

                case Facing.SOUTH:
                    if(rover.Y > 1)
                    {
                        rover.Y--;
                    }
                    break;

                case Facing.WEST:
                    if(rover.X > 1)
                    {
                        rover.X--;
                    }
                    break;

                case Facing.NORTH:
                    if (rover.Y < TABLE_SIZE_Y)
                    {
                        rover.Y++;
                    }
                    break;
            }
        }
    }
}
