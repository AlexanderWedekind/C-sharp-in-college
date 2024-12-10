using MyDungeonCrawlerMethods;
using MyNewRoom;
using MyNewPlayer;

namespace MyDungeonCrawler
{
    public class MyDungeonCrawler
    {
        
        public static void Main()
        {
            DungeonCrawlerMethods method = new DungeonCrawlerMethods();
            Room newRoom = new Room();
            Console.WriteLine(newRoom.num);
        }
    }
}