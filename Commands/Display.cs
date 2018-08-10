using System;
using System.Linq;

namespace TUTE.Commands
{
public class Display : Data, ICommand
{
public void ParseArgs(string[] args)
{
    // nothing to parse
}
public void Execute()
{
    if (lines.Count() > 0) // if there are lines written
    {
        int lineCount = 1; // to count lines
        foreach (string c in lines)
        {
            Console.WriteLine($"{lineCount} || {c}");
            lineCount++;
        }
    }
    else
    {
        Console.WriteLine(linesError);
    }
}
}
}