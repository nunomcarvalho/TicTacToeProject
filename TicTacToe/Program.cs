namespace TicTacToe;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var startGame = new StartGame();
            startGame.Start();
        }
        catch
        {
            //TODO: Error handler
            Console.WriteLine("An error occurred");
        }
    }
}