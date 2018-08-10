using System;
using System.Linq;
using System.IO;

namespace TUTE.Commands
{
public class Save : Data, ICommand
{
private string toSave;
private bool parsed;
public void ParseArgs(string[] args)
{
    if (args.Length == 2) // if there's the arguments we need
    {
        // args[0]: /save
        // args[1]: name of the file
        toSave = path + $"\\{args[1]}";
        parsed = true;
    }
    else
    {
        Console.WriteLine(argError);
    }
}

public void Execute()
{
    if ( (parsed) && (lines.Count() > 0) ) // if the arguments could be parsed and there are lines written
    {
        File.WriteAllLines(toSave, lines);
        hasSaved = true;
        Console.WriteLine("|| Succesfully saved.");
    }
    else
    {
        if (parsed)
        {
            Console.WriteLine(linesError);
        }
    }
}
}
}