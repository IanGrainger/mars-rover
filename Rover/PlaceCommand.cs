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
            rover.X = X; rover.Y = Y; rover.Facing = Facing;
        }
    }
}
