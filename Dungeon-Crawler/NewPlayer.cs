using System.Security.Cryptography.X509Certificates;
using MyDungeonCrawlerMethods;

namespace MyNewPlayer
{
    
    public class NewPlayer
    {
        DungeonCrawlerMethods method = new DungeonCrawlerMethods();
        
        public int health = 0;
        public int gold = 0;
        public int attackDamage =  0;
        
        public int attack = 0;
        public int defence = 0;

        public NewPlayer()
        {
            attackDamage = method.DiceRoll(2);
            health = 25;
            gold = 0;
            attack = 0;
            defence = 2;
        }
    }
}