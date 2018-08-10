using System;
namespace TUTE.Commands
{
public class Exit : Data, ICommand
{
public void ParseArgs(string[] args)
{
    // nothing to parse
}

public void Execute()
{
    if (hasSaved) // if the user has saved
    {
        Console.WriteLine("|| Exiting TUTE: The Useless Text Editor");
        Console.ReadLine();
        done = true;
    }
    else
    {
        Console.Write("|| You have unsafe progress. Are you sure you want to exit? [Y/N] ");
        string exit = Console.ReadLine();
        switch (exit.ToUpper()) // to upper so it doesn't matter if it's written in caps or not
        {
            case "Y":
                Console.WriteLine("|| Exiting TUTE: The Useless Text Editor");
                Console.ReadLine();
                done = true;
                break;
            case "N":
                done = false;
                break;
            default:
                Console.WriteLine(invalidError);
                done = false;
                break;
        }
    }
}
}
}