using System;
using System.Linq;

namespace TUTE.Commands
{
public class Redo : Data, ICommand
{
private int lastUndo = undos.Count() - 1;
public void ParseArgs(string[] args)
{
    // nothing to parse
}
public void Execute()
{
    if (undos.Count() > 0) // if you have undone
    {
        lines.Add(undos[lastUndo]);
        Console.WriteLine("|| Redone succesfully.");
    }
    else
    {
        Console.WriteLine(undoError);
    }
}
}
}