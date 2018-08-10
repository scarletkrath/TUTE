using System;
using System.IO;

namespace TUTE.Commands
{
public class Copy : Data, ICommand
{
private int toCopy;
private bool parsed, correctLength;
public void ParseArgs(string[] args)
{
    if (args.Length == 2) // if there's the arguments we need
    {
        correctLength = true;
    }
    else
    {
        correctLength = false;
    }

    if (correctLength)
    {
        toCopy = Parse(args[1]);
        if (toCopy > 0) // if the number was parsed correctly
        {
            parsed = true;
        }
        else
        {
            parsed = false;
        }
    }
    else
    {
        Console.WriteLine(argError);
    }
}

private string copied;
public void Execute()
{
    if ((toCopy <= lines.Count) && (toCopy > 0) && (correctLength))
    // if the parsed number is less than or equal to the lines
    // count, greater than 0 and there's the arguments we need
    {
        copied = lines[toCopy - 1];
        string[] copiedYet = new string[] { copied }; // same as before but as an array so it can be written
        File.WriteAllLines(copyPath + "\\copylist.tute", copiedYet);
        hasCopied = true; // See Paste.cs and PasteReplace.cs
        Console.WriteLine("|| Copied succesfully!");
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
