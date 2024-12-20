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
        public static string welcome = "A new adventurer approaches the dungeon in search of treasure!\nThe old hag by the entrance asks them what their name is.";
        public static string askName = "What is your adventurer's name?";
        public static string rejectInvalidName = "Please try again. Choose a name by using the letter keys.";
        public static string lucky = "Luck is on your side!";
        public static string unlucky = "Ill luck befalls you!";
        public static string treasureChest = "This room is empty, apart from an old, forgotten treasure chest in the corner.";
        public static string itemFind(string item)
        {
            return "You open it and inside you find " + item + "!";
        }
        public static string attackUp = "Your attack increases by 2.";
        public static string defenceUp = "Your defence increases by 2.";
        public static string MonsterAppears()
        {
            return "A fearsome monster by the name of " + Monster.name + "occupies this room.";
        }
        public static string MonsterDidntSeeYou()
        {
            return Monster.name + " is asleep and hasn't noticed you.";
        }
        public static string SneakOrAttack = "Do you want to attack, or will you attempt to quitly sneak past to get to the next room?"
                                            + "\nChoose option (1) Attack, or option (2) Sneak";
        public static string approachSuccessfull()
        {
            return "You quietly approach the sleeping " + Monster.name + " and get the jump on them; you launch the first attack.";
        }
        public static string approachTooNoisy = "Your approach is too noisy!";
        public static string sneakTooNoisy = "You make too much noise as you try to sneak and you get noticed!";
        public static string MonsterSeesYou()
        {
            return "As soon as " + Monster.name + " lays eyes on you, they immediately attack!";
        }
        public static string sneakSuccess = "You sneak past without getting noticed.";
        public static string proceed = "With trepidation you proceed to the next room...";
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
        public static string askMenuChoice = "please choose an option:";
        public static string rejectInvalidMenuChoice = "Sorry, that wasn't a valid choice.\nPlease choose from the menu by selecting the number that corresponds to you your choice, using the number keys.";
        public static string chosePlusEnter = "(type your choice, then press ENTER)";
        public static string askYesOrNo = "Choose Yes (y) or No (n).";
        public static string rejectInvalidYesOrNo = "Sorry that wasn't a valid choice. Choose Yes or No by using the (y) or (n) keys.";
        public static string goodLuck()
        {
            return "\"Good luck on your adventure " + Player.name + "!\" the old hag shouts, with a sinister grin, as you enter the first room...";
        }
        public static string askNextRoom = "Do you want to progress to the next room, or do you want to return to the surface?e\nContinue your quest?";
        public static string death()
        {
            return "You perish from your injuries...\nAs you lie dead and forgotten in the accursed dungeon, the monsters loot all or your " + Player.gold + " coins.";
        }
        public static string exit = "Assessing your chances and fortune, you decide to end your quest and ascend back to the world of the living.";
        public static string backstab()
        {
            return "As you breathe in the fresh air deeply and close your eyes for a moment, feeling gratefull to have survived this ordeal,\n"
                    + "the old hag steps out from behind a rock and stabs you in the back, killing you instantly.\n"
                    + "As she loots your treasure, she cackles to herself: \"Ha! This one has brought me " + Player.gold + " coins!\nA good haul, can't wait for the next one tomorrow.\"";
        }
        public static string victory()
        {
            return "You conquered all the rooms in the dungeon with " + Player.healingPotion + " potions and " + Player.health + " health left!"
                    + "Relieved to be alive, you make your way back to the surface.";
        }
        public static string playAgain = "Do you want to play again?";

    }
}