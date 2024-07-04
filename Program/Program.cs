
using Rover;

if (args.Length < 1)
{
  throw new ArgumentException("Usage: Program.exe <path to file>");
}
var firstArg = args[0];
var commandFileInfo = new FileInfo(firstArg);
if (!commandFileInfo.Exists)
{
  throw new ArgumentException($"Unable to find file {commandFileInfo.FullName}");
}

// DI
var commandParser = new CommandParser();
var reporter = (string s) => Console.WriteLine(s);
var rover = new Rover.Rover(commandParser, reporter);

using var inputStream = commandFileInfo.OpenRead();
rover.ProcessCommandFile(inputStream);

Console.WriteLine("Press any key to exit");
Console.ReadLine();
