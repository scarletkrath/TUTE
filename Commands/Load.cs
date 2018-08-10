using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace TUTE.Commands
{
public class Load : Data, ICommand
{
private string toLoad;
private char method;
private bool parsed;
public void ParseArgs(string[] args)
{
    if (args.Length == 3)
    {
        // args[0]: /load
        // args[1]: the file to load
        // args[2]: append or replace
        toLoad = args[1];
        char[] toParse = args[2].ToCharArray();
        method = toParse[0];
        parsed = true;
    }
    else
    {
        Console.WriteLine(argError);
    }
}

public void Execute()
{
    if (File.Exists(path + $"\\{toLoad}")) // if the specified file exists
    {
        List<string> file = File.ReadAllLines(path + $"\\{toLoad}").ToList(); // make a list with it
        if (file.Count > 0) // if the file has lines written
        {
            switch (method)
            {
                case 'a':
                    lines.AddRange(file);
                    break;
                case 'r':
                    lines.Clear();
                    lines.AddRange(file);
                    break;
                default:
                    Console.WriteLine(invalidError);
                    break;
            }
        }
    }
    else
    {
        if (parsed)
        {
            Console.WriteLine(invalidError);
        }
    }
}
}
}