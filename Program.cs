using System;
using TUTE.Commands;
using System.Collections.Generic;
using System.IO;

namespace TUTE
{
public class Data
{
// Public variables for all classes //
public static int line = 1;
public static List<string> lines = new List<string>();
public static List<string> undos = new List<string>();
public static bool hasCopied = false;
public static bool hasSaved = false;
public static bool done = false;
public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Path to desktop
public static string copyPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TUTE"; // Path to AppData\TUTE

// Parse method //
public static int Parse(string toParse)
{
    int number;
    if (int.TryParse(toParse, out int parsed))
    {
        number = parsed;
        return number;
    }
    else
    {
        Console.WriteLine(parseError);
        return -1;
    }
}

// Error messages //
public static string argError = "|| Error: Arguments out of range";
public static string linesError = "|| Error: The lines list is empty";
public static string undoError = "|| Error: The undo list is empty";
public static string copyError = "|| Error: You haven't copied a line yet, or the line you chose is invalid";
public static string invalidError = "|| Error: One of the arguments entered is invalid";
public static string parseError = "|| Error: Could not parse one of the arguments";
public static string syntaxError = "|| Error: Invalid command";
}

class Program : Data
{
static void Main(string[] args)
{
    Console.ForegroundColor = ConsoleColor.White; // Set the console color to white
    string v = "1.0";
    Console.Title = $"|| TUTE: The Useless Text Editor v{v} ||";
    Console.WriteLine($"|| TUTE: The Useless Text Editor v{v} ||");
    Console.WriteLine("|| Type \"/help\" for a list of commands");
    Prompt();
}

static void Prompt()
{
    // If the directory nor the files exist, create them
    if (!Directory.Exists(copyPath))
    {
        Directory.CreateDirectory(copyPath);
    }
    if (!File.Exists(copyPath + "\\copylist.tute"))
    {
        File.Create(copyPath + "\\copylist.tute").Close();
    }

    while (!done)
    {
        Console.Write($"#{line} ");
        string command = Console.ReadLine();
        string[] args = command.Split(new[] { ' ' }, 2);
        string[] argsFull = command.Split(' '); // Ask for a command, split it into two arrays, one where it only splits once and one when it constantly splits
        char[] check = args[0].ToCharArray(); // Convert the first argument of args into a char array
        switch (args[0])
        {
            case "/save":
                var Save = new Save();
                Save.ParseArgs(argsFull);
                Save.Execute();
                break;
            case "/load":
                var Load = new Load();
                Load.ParseArgs(argsFull);
                Load.Execute();
                break;
            case "/undo":
                var Undo = new Undo();
                Undo.Execute();
                break;
            case "/redo":
                var Redo = new Redo();
                Redo.Execute();
                break;
            case "/copy":
                var Copy = new Copy();
                Copy.ParseArgs(argsFull); 
                Copy.Execute();
                break;
            case "/paste":
                var Paste = new Paste();
                var PasteReplace = new PasteReplace();
                if ( (argsFull.Length == 3) && (argsFull[1] == "r") ) // if there are 3 arguments and the second one is r
                {
                    PasteReplace.ParseArgs(argsFull);
                    PasteReplace.Execute();
                }
                else if ( (argsFull.Length == 2) && (argsFull[1] == "a")) // if there are two arguments and the second one is a
                {
                    Paste.ParseArgs(argsFull);
                    Paste.Execute();
                }
                else
                {
                    Console.WriteLine(argError);
                }
                break;
            case "/dis":
                var Display = new Display();
                Display.Execute();
                break;
            case "/edit":
                var Edit = new Edit();
                Edit.ParseArgs(argsFull);
                Edit.Execute();
                break;
            case "/move":
                var Move = new Move();
                Move.ParseArgs(argsFull);
                Move.Execute();
                break;
            case "/del":
                var Delete = new Delete();
                Delete.ParseArgs(argsFull);
                Delete.Execute();
                break;
            case "/clear":
                Console.Clear();
                break;
            case "/exit":
                var Exit = new Exit();
                Exit.ParseArgs(args);
                Exit.Execute();
                break;
            default:
                string fullCommand; // Initialize a full command string
                if (args.Length > 1) // if args has more than one argument
                {
                    fullCommand = args[0] + " " + args[1]; // the full command is the argument 0, plus a space, plus the rest
                }
                else
                {
                    fullCommand = args[0]; // else its just the arg 0
                }

                if (check[0] == '/') // check if the char array made before has as its first letter a /
                {
                    Console.WriteLine(syntaxError);
                }
                else
                {
                    lines.Add(fullCommand); // add the command to the lines list
                    line++; // increment the lines counter
                }
                hasSaved = false;
                break;
        }
    }
}
}
}