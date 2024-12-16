using MyDungeonCrawlerMethods;
using MyPlayer;

namespace MyMonster
{
    public class Monster
    {
        public static int health = 0;
        public static string name = "";
        public static int attackDamage(int dice)
        {
            return method.DiceRoll(dice) - Player.defence;
        }

        public Monster()
        {
            health = 25;
            name = method.GenerateRandomMonsterName();
        }
    }
}