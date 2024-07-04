namespace Rover
{
    public class MoveCommand: ICommand
    {
        public MoveCommand() {
        }

        public void Execute(Rover rover)
        {
            if (!rover.IsPlaced)
            {
                return;
            }

            switch (rover.Facing)
            {
                case Facing.EAST:
                    if (rover.X < Constants.TABLE_SIZE_X)
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
                    if (rover.Y < Constants.TABLE_SIZE_Y)
                    {
                        rover.Y++;
                    }
                    break;
            }
        }
    }
}
