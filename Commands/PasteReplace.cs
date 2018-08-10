using System;
using System.IO;

namespace TUTE.Commands
{
public class PasteReplace : Data, ICommand
{
private char method;
private int toPaste;
private bool parsed;
public void ParseArgs(string[] args)
{
    if (args.Length == 3)
    {
        // args[0]: /paste
        // args[1]: append or replace
        // args[2]: line to replace
        char[] toParse = args[1].ToCharArray();
        method = toParse[0];
        toPaste = Parse(args[2]);
        if (toPaste > 0) // if the number was parsed correctly
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

public void Execute()
{
    string[] pasted = File.ReadAllLines(copyPath + "\\copylist.tute"); // the copy list
    if ( (hasCopied) && (toPaste > 0) && (toPaste <= lines.Count) && (parsed) && (toPaste != lines.Count) )
    // if the parsed number is less than or equal to the lines
    // count, greater than 0 (a.k.a parsed correctly), the
    // user has copied, the number was parsed correctly and
    // the number is not the last line written
    {
        if (method == 'r')
        {
            lines[toPaste - 1] = pasted[0];
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