using System;

namespace TUTE.Commands
{
public class Move : Data, ICommand
{
private int intOne, intTwo;
private bool parsed, correctLength;
public void ParseArgs(string[] args)
{
    if (args.Length == 3)
    {
        intOne = Parse(args[1]);
        intTwo = Parse(args[2]);
        if ( (intOne > 0) && (intTwo > 0) ) // if the numbers were parsed correctly
        {
            parsed = true;
        }
        else
        {
            parsed = false;
        }
        correctLength = true;
    }
    else
    {
        if (parsed)
        {
            Console.WriteLine(invalidError);
        }
        else
        {
            Console.WriteLine(argError);
        }
    }
}

public void Execute()
{
    if ( (intOne <= lines.Count) && (intTwo <= lines.Count) && (parsed) && (correctLength))
    // if the parsed numbers are less than or equal to the lines
    // count, greater than 0 and there's the arguments we need
    {
        string lineOne = lines[intOne - 1], lineTwo = lines[intTwo - 1];
        lines[intTwo - 1] = lineOne;
        lines[intOne - 1] = lineTwo;
    } else { } // else do nothing
}
}
}