# mars-rover

Mars Rover technical task for Cell Therapy

## Usage

Example usage:
`dotnet run --project Program rover1.txt`

Examples given in the task are stored in the root folder (rover1.txt, rover2.txt, rover3.txt).

## Requirements

- Robot can be placed on a 5x5 table
- Robot must not be allowed off the edge (not yet implemented)
- Accept commands:
  - PLACE X,Y,F
  - MOVE
  - LEFT
  - RIGHT
  - REPORT
- Ignore commands until placed
- Report will output: X,Y,F
- Input from file or standard input (from file)
- Provide test data
