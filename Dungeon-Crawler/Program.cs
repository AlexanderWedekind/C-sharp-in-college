using MyDungeonCrawlerMessages;
using MyDungeonCrawlerMethods;
using MyMonster;
using MyNewRoom;
using MyPlayer;
using Gamefinished;

namespace MyDungeonCrawler
{
    public class MyDungeonCrawler
    {
        
        public static void Main()
        {
            bool play = false;
            do
            {
                try
                {
                    method.Game();
                }
                catch(GameFinished finished)
                {
                    method.MessagePlayer(finished.Message);
                    method.CollectPlayerInput("");
                    play = method.PlayAgainMenu();
                }
                
                
            }
            while(play == true);
            Environment.Exit(1);
            

            // Player currentPlayer = new Player();
           
            // Room newRoom = method.CreateNewRoom();
            
            // Monster newMonster = new Monster();
            
            // Player.name = "Mr Winter Bottom";
            // // Console.WriteLine("monster name : \" " + Monster.name + " \"");
            // // Console.WriteLine(Player.name);
            // // method.UpdateStaticStringClassField(typeof(Player), "name", "Carly");
            // // Console.WriteLine(method.GetCurrentStaticStringClassFieldValue(typeof(Player), "name"));
            // // Console.WriteLine(Player.name);
            // // Console.WriteLine(method.GetCurrentStaticIntClassFieldValue(typeof(Player), "health"));
            // // method.UpdateStaticIntClassField(typeof(Player), "health", -4);
            // // Console.WriteLine(method.GetCurrentStaticIntClassFieldValue(typeof(Player), "health"));

            // method.MessagePlayer(method.GenerateStatsDisplay());

            // // Console.WriteLine(method.CleanedInput("           hello              world []{}()-+=/\\.;:,9876ynYN"));
            // // Console.WriteLine(method.AcceptOnlyNumbers(method.CleanedInput("           hello              world []{}()-+=/\\.;:,9876ynYN")));
            // // Console.WriteLine(method.AcceptOnlyYorN(method.CleanedInput("           hello              world []{}()-+=/\\.;:,9876ynYN")));
            // // Console.Write(method.RemoveDoubleWhitespaces(method.AcceptOnlyLetters("           hello              world []{}()-+=/\\.;:,9876ynYN")).Trim());
        }
    }
}