using MyDungeonCrawlerMessages;
using MyDungeonCrawlerMethods;
using MyMonster;
using MyNewRoom;
using MyPlayer;

namespace MyDungeonCrawler
{
    public class MyDungeonCrawler
    {
        
        public static void Main()
        {
            Player currentPlayer = new Player();
           
            Room newRoom = method.CreateNewRoom();
            
            Monster newMonster = new Monster();

            Console.WriteLine("monster name : \" " + Monster.name + " \"");
            method.MessagePlayer(method.GenerateStatsDisplay());

            method.GenerateStatsDisplay();
            Console.WriteLine(method.CleanedInput("           hello              world []{}()-+=/\\.;:,9876ynYN"));
            Console.WriteLine(method.AcceptOnlyNumbers(method.CleanedInput("           hello              world []{}()-+=/\\.;:,9876ynYN")));
            Console.WriteLine(method.AcceptOnlyYorN(method.CleanedInput("           hello              world []{}()-+=/\\.;:,9876ynYN")));
            Console.Write(method.RemoveDoubleWhitespaces(method.AcceptOnlyLetters("           hello              world []{}()-+=/\\.;:,9876ynYN")).Trim());
        }
    }
}