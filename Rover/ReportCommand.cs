namespace Rover
{
    public class ReportCommand: ICommand
    {

        public ReportCommand() {}

        public void Execute(Rover rover) 
        {
            rover.Reporter.Invoke($"{rover.X},{rover.Y},{rover.Facing}");
        }
    }
}
