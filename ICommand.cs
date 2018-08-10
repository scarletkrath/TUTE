namespace TUTE.Commands
{
public interface ICommand
{
    void ParseArgs(string[] args); // convert the data you want to use
    void Execute(); // do whatever with those values
}
}