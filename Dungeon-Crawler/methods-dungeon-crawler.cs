using System.Security.Cryptography.X509Certificates;
using MyMonster;
using MyNewRoom;
using MyPlayer;
using MyDungeonCrawlerMessages;

namespace MyDungeonCrawlerMethods
{
    struct method
    {
        public static Random random = new Random();

        

        public static void MessagePlayer(string message)
        {
            Console.WriteLine(message);
        }

        public static string CollectPlayerInput(string message)
        {
            MessagePlayer(message);
            return Console.ReadLine();
        }

        public static string CleanedInput(string input)
        {
            return input.Replace(" ", "").Replace("/", "").Replace("-", "").Replace("\\", "").Replace(":", "").Substring(0, 10);
        }

        

        public static string GenerateStatsDisplay()
        {
            return "________\n|       |\n_______";
        }

        public static int OneD6()
        {
            int throwResult = 0;
            throwResult = random.Next(1, 7);
            return throwResult;
        }

        public static int DiceRoll(int numberOfDice)
        {
            int roll = 0;
            for(int i = 0; i < numberOfDice; i++)
            {
                roll = roll + OneD6();
            }
            return roll;
        }

        public static int FoundGoldAmount()
        {   
            return OneD6() * 100;
        }

        public static int VictoryGoldRewardAmount()
        {
            return DiceRoll(2) * 100;
        }

        public static int GetCurrentStaticClassFieldValue(Type classType, string fieldName)
        {
            return Convert.ToInt32(classType.GetField(fieldName));
        }

        public static void UpdateStaticClassField(Type classType, string fieldName, int valueIncrease)
        {
            var staticPlayerField = classType.GetField(fieldName);
            int currentStaticFieldValue = Convert.ToInt32(classType.GetField(fieldName));
            int newValue = currentStaticFieldValue + valueIncrease;
            staticPlayerField.SetValue(null, newValue);
        }

        public static void ItemFindEvent()
        {   
            MessagePlayer(message.treasureChest);
            int find = random.Next(1, 4);
            string item = "";
            switch(find)
            {
                case 1:
                    item = "a weapon";
                    UpdateStaticClassField(typeof(Player), "attack", 2);
                    MessagePlayer(message.itemFind(item));
                    MessagePlayer(message.attackUp);
                    break;
                case 2:
                    item = "a piece of armour";
                    UpdateStaticClassField(typeof(Player), "defence", 2);
                    MessagePlayer(message.itemFind(item));
                    MessagePlayer(message.defenceUp);
                    break;
                case 3:
                    item = "healing potion";
                    UpdateStaticClassField(typeof(Player), "healingPotion", 1);
                    MessagePlayer(message.itemFind(item));
                    break;
            }
        }

        public static void HealingFountainEvent()
        {
            int currentHealthValue = GetCurrentStaticClassFieldValue(typeof(Player), "Health");
            int valueIncrease = Convert.ToInt32(Math.Round(Convert.ToDouble(currentHealthValue) / 2));
            UpdateStaticClassField(typeof(Player), "health", valueIncrease);
            MessagePlayer(message.newLine + message.healingFountain(valueIncrease));
        }

        public static void MonsterDoesDamage()
        {
            MessagePlayer(message.newLine);
            MessagePlayer(message.monsterSwings());
            int damage = Monster.attackDamage(2);
            Player.health = Player.health - damage;
            MessagePlayer(message.monsterDoesDamage(damage));
        }

        public static void PLayerDoesDamage()
        {
            MessagePlayer(message.newLine);
            MessagePlayer(message.playerSwings());
            int damage = Player.attackDamage(2);
            Monster.health = Monster.health - damage;
            MessagePlayer(message.playerDoesDamage(damage));
        }

        public static void Battle(bool whoStrikes)
        {
            while(Monster.health > 0 || Player.health > 0)
            {
                if(whoStrikes == true)
                {
                    MonsterDoesDamage();
                    whoStrikes = false;
                }
                else
                {
                    PLayerDoesDamage();
                    whoStrikes = true;
                }
            }
        }

        public static void MonsterEvent()
        {

        }

        public static void GoldFindEvent()
        {
            int amount = FoundGoldAmount();
            UpdateStaticClassField(typeof(Player), "gold", amount);
            MessagePlayer(message.foundGold(amount));
        }

        public static void TrapEvent()
        {
            MessagePlayer(message.trap());
            int chance = random.Next(1, 101);
            if(chance > 50)
            {
                int damage = -1 * DiceRoll(2);
                UpdateStaticClassField(typeof(Player), "health", damage);
                MessagePlayer(message.trapDamage(damage));
            }
            else
            {
                MessagePlayer(message.trapAvoid);
            }
        }

        public static Room CreateNewRoom()
        {
            Room newRoom = new Room(method.GoldFindEvent, method.HealingFountainEvent, method.ItemFindEvent, method.TrapEvent, method.MonsterEvent);
            return newRoom;
        }

        public static string GenerateRandomMonsterName()
        {
            //a b c d e f g h i j  k  l  m  n  o  p  q  r  s  t  u  v  w  x  y  z
            //1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26
            string randomMonsterName = "";
            int doubleConsonantChance = 0;
            bool ConsOrVowel = true;
            int nameLengthExtensioChance = 0;
            int chanceReductionPercentage = 0;
            int chanceReduction = 0;
            int progressivelyReducedChance = 101;
            string[] consonants = {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"};
            string[] vowels = {"a", "e", "i", "o", "u"};
            while(progressivelyReducedChance > 1)
            {
                //Console.WriteLine("1");
                nameLengthExtensioChance = random.Next(1, 101);
                if(nameLengthExtensioChance < progressivelyReducedChance)
                {
                    if(randomMonsterName.Length == 0)
                    {
                        if(random.Next(1, 101) > 50)
                        {
                            ConsOrVowel = false;
                        }
                    }
                    do
                    {
                        if(ConsOrVowel == true)
                        {
                            randomMonsterName = randomMonsterName + vowels[random.Next(0, 5)];
                        }
                        else
                        {
                            randomMonsterName = randomMonsterName + consonants[random.Next(0, 22)];
                        }
                        doubleConsonantChance = doubleConsonantChance + random.Next(1, 101);
                    }
                    while(doubleConsonantChance < 50 );
                    if(ConsOrVowel == true)
                    {
                        ConsOrVowel = false;
                    }
                    else
                    {
                        ConsOrVowel = true;
                    }
                }
                chanceReductionPercentage = random.Next(1, 36);
                chanceReduction = Convert.ToInt32(Convert.ToDouble(progressivelyReducedChance) * (Convert.ToDouble(chanceReductionPercentage) / Convert.ToDouble(100)));
                progressivelyReducedChance = progressivelyReducedChance - chanceReduction;
                //Console.WriteLine("progressivelyReducedChance : " + progressivelyReducedChance);
            }
            randomMonsterName = randomMonsterName.Substring(0, 1).ToUpper() + randomMonsterName.Substring(1);
            return randomMonsterName;
        }

        public static void CarryOnOrQuitMenu()
        {

        }
        public static void FinishGame()
        {

        }
        public static void BattleMenu()
        {

        }
        public static void NewRoomOrQuitMeny()
        {
            
        }
        public static void DoCurrentRoom()
        {

        }
        public static void ProceedFromRoomToRoom()
        {
            bool isFirstRoom = true;
            int numberOfRooms = 10;
            do
            {
                if(isFirstRoom == true)
                {

                }
                else
                {
                    
                }
            }
            while(numberOfRooms > 0);
        }
        public static void Game()
        {

        }

        

        
    }
}