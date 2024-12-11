using System.Security.Cryptography.X509Certificates;


namespace MyPlayer
{
    using MyDungeonCrawlerMethods;    
    public class Player
    {
        //DungeonCrawlerMethods method = new DungeonCrawlerMethods();
        
        public static int health = 0;
        public static int gold = 0;
        public static int healingPotion = 0;
        public static int attackDamage(int dice)
        {
            return method.DiceRoll(dice);
        }
        
        public static int attack = 0;
        public static int defence = 0;

        public Player()
        {
            healingPotion = 2;
            health = 25;
            gold = 0;
            attack = 0;
            defence = 2;
        }
    }
}