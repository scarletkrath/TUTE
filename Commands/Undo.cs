using System;
using System.Linq;

namespace TUTE.Commands
{
public class Undo : Data, ICommand
{
private int lastLine = lines.Count() - 1;
public void ParseArgs(string[] args)
{
    // nothing to parse
}
public void Execute()
{
    if (lines.Count() > 0)
    {
        undos.Add(lines[lastLine]); // add the last line written to the undo list
        lines.RemoveAt(lastLine); // remove it from the main one
        Console.WriteLine("|| Undone succesfully.");
    }
    else
    {
        Console.WriteLine(linesError);
    }
}
}
}