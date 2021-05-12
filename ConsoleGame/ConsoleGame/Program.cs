namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManagment = new GameManager();
            gameManagment.Start();
            gameManagment.RunGame();
        }
    }
}