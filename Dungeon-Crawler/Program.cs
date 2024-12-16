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

            string emptyString = "";
            method.MessagePlayer("$ cd ../");
        }
    }
}