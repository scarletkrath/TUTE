using System;

namespace TUTE.Commands
{
public class Edit : Data, ICommand
{
private int toEdit;
private bool parsed, correctLength;
public void ParseArgs(string[] args)
{
    if (args.Length == 2)
    {
        toEdit = Parse(args[1]);
        if (toEdit > 0) // if the number was parsed correctly
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
    if ( (toEdit <= lines.Count) && (parsed) && (correctLength) )
    // if the parsed number is less than or equal to the lines
    // count, greater than 0 and there's the arguments we need
    {
        Console.Write("|| ");
        string edited = Console.ReadLine();
        lines[toEdit - 1] = edited;
        Console.WriteLine("|| Edited succesfully.");
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