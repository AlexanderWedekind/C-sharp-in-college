using System.ComponentModel;
using MyDungeonCrawlerMethods;
using MyMonster;
using MyNewRoom;
using MyPlayer;

namespace MyDungeonCrawlerMessages
{
    struct message
    {
        public static string newLine = "\n";
        public static string lucky = "Luck is on your side!";
        public static string unlucky = "Ill luck befalls you!";
        public static string treasureChest = "This room is empty, apart from an old, forgotten treasure chest in the corner.";
        public static string itemFind(string item)
        {
            return "You open it and inside you find " + item + "!";
        }
        public static string attackUp = "Your attack increases by 2.";
        public static string defenceUp = "Your defence increases by 2.";
        public static string foundGold(int gold)
        {
            return lucky + " You have found " + gold + " gold!";
        }
        public static string victoryReward(int gold)
        {
            return "You fought valiantly and you were victorious!\nYou vanquished " + Monster.name + " and looted their corpse to find " + gold + " gold.";
        }
        public static string healingFountain(int amount)
        {
            return lucky + newLine + "You find a healing fountain. You bathe in the rejuvenating water and recover " + amount + " health.";
        }
        public static string trap()
        {
            return unlucky + newLine + "You run into a trap!";
        }
        public static string trapAvoid = "But your quick reflexes save you and you jump out of the way at the last moment, avoiding any harm!";
        public static string trapDamage(int damage)
        {
            return "The wearyness from the journey has taken its toll on your reflexes and you walk straight into it!\nYou take " + damage + " damge.";
        }
        public static string playerSwings()
        {
            return "You take a swing at " + Monster.name + "!";
        }
        public static string monsterSwings()
        {
            return Monster.name + " takes a swing at you!";
        }
        public static string monsterDoesDamage(int damage)
        {
            return Monster.name + " does " + damage + " to you! Your health is down to " + Player.health + ".";
        }
        public static string playerDoesDamage(int damage)
        {
            return "You do " + damage + " damage! " + Monster.name + " has " + Monster.health + " health left.";
        }

    }
}