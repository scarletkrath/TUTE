using System;
using System.IO;

namespace TUTE.Commands
{
public class Paste : Data, ICommand
{
private char method;
public void ParseArgs(string[] args)
{
    if (args.Length == 2)
    {
        // args[0]: /paste
        // args[1]: append or replace
        char[] toParse = args[1].ToCharArray();
        method = toParse[0];
    }
    else
    {
        Console.WriteLine(argError);
    }
}

public void Execute()
{
    if (hasCopied) // see Copy.cs
    {
        string[] pasted = File.ReadAllLines(copyPath + "\\copylist.tute"); // the copy list
        if (method == 'a')
        {
            lines.Add(pasted[0]);
            Console.WriteLine("|| Pasted succesfully!");
        }
        else
        {
            Console.WriteLine(invalidError);
        }
    }
    else
    {
        Console.WriteLine(copyError);
    }
}
}
}