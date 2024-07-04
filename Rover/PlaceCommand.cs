namespace Rover
{
    public class PlaceCommand: ICommand
    {
        public Rover? Rover {get;set;}
        public int X {get;set;}
        public int Y {get;set;}
        public Facing Facing { get; set; }

        public PlaceCommand(int x, int y, Facing facing) {
            X = x;
            Y = y;
            Facing = facing;
        }

        public void Execute(Rover rover) {
            if (!(X <= Constants.TABLE_SIZE_X
                && Y <= Constants.TABLE_SIZE_Y
                && X >= 0
                && Y >= 0))
            {
                return;
            }

            rover.X = X; 
            rover.Y = Y; 
            rover.Facing = Facing;
            rover.IsPlaced = true;
        }
    }
}
