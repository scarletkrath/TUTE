using System;

namespace TUTE.Commands
{
public class Delete : Data, ICommand
{
private int toDelete;
private bool parsed, correctLength;
public void ParseArgs(string[] args)
{
    if (args.Length == 2)
    {
        toDelete = Parse(args[1]);
        if (toDelete > 0) // if the number was parsed correctly
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
        Console.WriteLine(argError);
    }
}

public void Execute()
{
    if ((toDelete <= lines.Count) && (parsed) && (correctLength))
    // if the parsed number is less than or equal to the lines
    // count, greater than 0 and there's the arguments we need
    {
        lines.RemoveAt(toDelete - 1);
    }
    else
    {
        if (parsed)
        {
            Console.WriteLine(argError);
        }
    }
}
}
}