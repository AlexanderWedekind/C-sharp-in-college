using System.Security.Cryptography.X509Certificates;
using MyMonster;
using MyNewRoom;
using MyPlayer;
using MyDungeonCrawlerMessages;
using System.Text.RegularExpressions;
using MyDungeonCrawler;
using Gamefinished;

namespace MyDungeonCrawlerMethods
{
    struct method
    {
        public static Random random = new Random();

        struct Cause
        {
            public static string death = "death";
            public static string exit = "exit";
            public static string victory = "victory";
        }

        public static void MessagePlayer(string message)
        {
            Console.WriteLine(message);
        }

        public static string CollectPlayerInput(string message)
        {
            MessagePlayer(message);
            return Console.ReadLine();
        }

        public static bool GotDetected()
        {
            bool noticed = false;
            int noise = DiceRoll(2);
            int heard = DiceRoll(2);
            if(noise > heard)
            {
                noticed = true;
            }
            return noticed;
        }

        public static string AcceptOnlyLetters(string input)
        {
            return Regex.Replace(input, @"[^a-zA-Z]", " ");
        }        

        public static string CleanedInput(string input)
        {
            return Regex.Replace(input, @"[\[\]\.\\/\s\(\)\{\}=\+\-,:;]", " ");
            //return Regex.Replace(input, @"[^[:alnum:]]", "");
        }

        public static (bool isNum, bool isValidSelection) TestNumInput(string input, int numberOfChoices)
        {
            bool isNum = false;
            bool isValidSelection = false;
            if(Int32.TryParse(input, out int number))
            {
                isNum = true;
                if(0 < number && number < numberOfChoices + 1)
                {
                    isValidSelection = true;
                }
            }
            return (isNum, isValidSelection);
        }

        public static string AcceptOnlyNumbers(string input)
        {
            return Regex.Replace(input.Trim(), @"[^0-9]", " ");
        }

        public static string AcceptOnlyYorN(string input)
        {
            return Regex.Replace(input.Trim(), @"[^ynYN]", " ").ToLower();
        }

        public static string RemoveDoubleWhitespaces(string input)
        {
            return Regex.Replace(input, @"(\s+)", " ");
        }

        public static string CollectPlayerName()
        {
            string input = RemoveDoubleWhitespaces(AcceptOnlyLetters(CollectPlayerInput(message.askName + message.newLine + message.chosePlusEnter))).Trim();
            while(String.IsNullOrEmpty(input) == true || String.IsNullOrWhiteSpace(input) == true)
            {
                input = RemoveDoubleWhitespaces(AcceptOnlyLetters(CollectPlayerInput(message.rejectInvalidName))).Trim();
            }
            if(input.Length > 14)
            {
                input = input.Substring(0, 20);
            }
            return input;
        }

        public static int CollectMenuSelection(int numberOfChoices)
        {
            string input = RemoveDoubleWhitespaces(AcceptOnlyNumbers(CollectPlayerInput(message.askMenuChoice + message.newLine + message.chosePlusEnter))).Trim();
            while(TestNumInput(input, numberOfChoices).isNum == false || TestNumInput(input, numberOfChoices).isValidSelection == false)
            {
                input = RemoveDoubleWhitespaces(AcceptOnlyNumbers(CollectPlayerInput(message.rejectInvalidMenuChoice + message.newLine + message.chosePlusEnter))).Trim();
            }
            return Int32.Parse(input);
        }

        public static string collectYorNselection()
        {
            string input = RemoveDoubleWhitespaces(AcceptOnlyYorN(CollectPlayerInput(message.askYesOrNo + message.newLine + message.chosePlusEnter))).Trim();
            while(String.IsNullOrEmpty(input) == true || String.IsNullOrWhiteSpace(input) == true)
            {
                input = RemoveDoubleWhitespaces(AcceptOnlyYorN(CollectPlayerInput(message.rejectInvalidYesOrNo + message.newLine + message.chosePlusEnter))).Trim();
            }
            return input.Substring(0, 1);
        }

        public static string GenerateStatsDisplay()
        {
            string statsDisplay = "";

            string name = String.Concat("Name: \"", Player.name, "\"");
            string health = String.Concat("Health: ", Convert.ToString(Player.health));
            string healingPotion = String.Concat("Healing Potions: ", Convert.ToString(Player.healingPotion));
            string gold = String.Concat("Gold: ", Convert.ToString(Player.gold));
            string attack = String.Concat("Attack: ", Convert.ToString(Player.attack));
            string defence = String.Concat("Defence: ", Convert.ToString(Player.defence));

            string healthPlusPotions()
            {
                string line = "";
                if(health.Length < healingPotion.Length)
                {
                    line = health.PadLeft(healingPotion.Length + 1).PadRight(healingPotion.Length + 2) + "|" + healingPotion.PadLeft(healingPotion.Length + 1).PadRight(healingPotion.Length + 2);
                }
                else if(healingPotion.Length < health.Length)
                {
                    line = health.PadLeft(health.Length + 1).PadRight(health.Length + 2) + "|" + healingPotion.PadRight(health.Length + 1).PadLeft(health.Length + 2);
                }
                else if(health.Length == healingPotion.Length)
                {
                    line =health.PadLeft(health.Length + 1).PadRight(health.Length + 2) + "|" + healingPotion.PadLeft(healingPotion.Length + 1).PadRight(healingPotion.Length + 2);
                }
                return line;
            }

            string attackPlusDefence()
            {
                string line = "";
                if(attack.Length < defence.Length)
                {
                    line = attack.PadLeft(defence.Length + 1).PadRight(defence.Length + 2) + "|" + defence.PadLeft(defence.Length + 1).PadRight(defence.Length + 2);
                }
                else if(defence.Length < attack.Length)
                {
                    line = attack.PadLeft(attack.Length + 1).PadRight(attack.Length + 2) + "|" + defence.PadRight(attack.Length + 1).PadLeft(attack.Length + 2);
                }
                else if(attack.Length == defence.Length)
                {
                    line = attack.PadLeft(attack.Length + 1).PadRight(attack.Length + 2) + "|" + defence.PadLeft(defence.Length + 1).PadRight(defence.Length + 2);
                }
                return line;
            }

            string[] lines =  
            {
                "",
                name.PadLeft(name.Length + 1).PadRight(name.Length + 2),
                "",
                healthPlusPotions(),
                "",
                attackPlusDefence(),
                "",
                gold.PadLeft(gold.Length + 1).PadRight(gold.Length + 2),
                "",
            };

            int topBorder = 0;
            int nameLine = 1;
            int nameBorder = 2;
            int healthAndPotionLine = 3;
            int healthBorder = 4;
            int attackAndDefenceLine = 5;
            int attackBorder = 6;
            int goldLine = 7;
            int bottomBorder = 8;

            int longestLineLength = 0;

            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Length > longestLineLength)
                {
                    longestLineLength = lines[i].Length;
                }
            }

            for(int i = 1; i < lines.Length; i += 2)
            {
                int padd = 0;
                if(lines[i].Length < longestLineLength)
                {
                    if((longestLineLength - lines[i].Length) % 2 == 0)
                    {
                        padd = (longestLineLength - lines[i].Length) / 2;
                        lines[i] = "|" + lines[i].PadLeft(lines[i].Length + padd).PadRight(lines[i].Length + (padd * 2)) + "|";
                    }
                    else
                    {
                        padd = ((longestLineLength - lines[i].Length) + 1) / 2;
                        lines[i] = "|" + lines[i].PadLeft(lines[i].Length + (padd - 1)).PadRight(lines[i].Length + (padd * 2) - 1) + "|";
                    }
                }
                else
                {
                    lines[i] = "|" + lines[i] + "|";
                }
            }

            for (int i = 0; i < lines.Length; i+=2)
            {
                for(int j = 0; j < longestLineLength + 1; j++)
                {
                    if(lines[i].Length == 0)
                    {
                        lines[i] += "+";
                    }
                    else if(lines[i].Length == longestLineLength + 1)
                    {
                        lines[i] = lines[i].PadLeft(1);
                    }
                    else if(i == 4)
                    {
                        lines[i] += "-";
                    }
                    else if(lines[i].Substring(lines[i].Length - 1, 1) == "-")
                    {
                        lines[i] += "+";
                    }
                    else if(lines[i].Substring(lines[i].Length - 1, 1) == "+")
                    {
                        lines[i] += "-";
                    }
                }
            }

            for(int i = 0; i < lines.Length; i ++)
            {
                statsDisplay += lines[i] + "\n";
            }
            return statsDisplay;
            //return " ----------\n|          |\n ----------";
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

        public static int GetCurrentStaticIntClassFieldValue(Type classType, string fieldName)
        {
            
            var field = classType.GetField(fieldName);
            int fieldValue = Convert.ToInt32(field.GetValue(classType));
            return fieldValue;
        }

        public static string GetCurrentStaticStringClassFieldValue(Type classType, string fieldName)
        {
            var field = classType.GetField(fieldName);
            string fieldValue = Convert.ToString(field.GetValue(classType));
            return fieldValue;
        }

        public static void UpdateStaticIntClassField(Type classType, string fieldName, int valueIncrease)
        {
            var staticPlayerField = classType.GetField(fieldName);
            int currentStaticFieldValue = Convert.ToInt32(staticPlayerField.GetValue(classType));
            int newValue = currentStaticFieldValue + valueIncrease;
            staticPlayerField.SetValue(null, newValue);
        }

        public static void UpdateStaticStringClassField(Type classType, string fieldName, string newValue)
        {
            var staticPlayerField = classType.GetField(fieldName);
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
                    UpdateStaticIntClassField(typeof(Player), "attack", 2);
                    MessagePlayer(message.itemFind(item));
                    MessagePlayer(message.attackUp);
                    break;
                case 2:
                    item = "a piece of armour";
                    UpdateStaticIntClassField(typeof(Player), "defence", 2);
                    MessagePlayer(message.itemFind(item));
                    MessagePlayer(message.defenceUp);
                    break;
                case 3:
                    item = "healing potion";
                    UpdateStaticIntClassField(typeof(Player), "healingPotion", 1);
                    MessagePlayer(message.itemFind(item));
                    break;
            }
        }

        public static void HealingFountainEvent()
        {
            int currentHealthValue = GetCurrentStaticIntClassFieldValue(typeof(Player), "Health");
            int valueIncrease = Convert.ToInt32(Math.Round(Convert.ToDouble(currentHealthValue) / 2));
            UpdateStaticIntClassField(typeof(Player), "health", valueIncrease);
            MessagePlayer(message.newLine + message.healingFountain(valueIncrease));
        }

        public static void MonsterDoesDamage()
        {
            MessagePlayer(message.newLine);
            MessagePlayer(message.monsterSwings());
            int damage = Monster.attackDamage(2);
            Player.health = Player.health - damage;
            if(Player.health < 0)
            {
                Player.health = 0;
            }
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
            while(Monster.health > 0)
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
            if(Monster.health < 1)
            {
                int reward = VictoryGoldRewardAmount();
                UpdateStaticIntClassField(typeof(Player), "gold", reward);
                MessagePlayer(message.victoryReward(reward));
            }
            AssessPlayerHealth();
        }

        public static void MonsterEvent()
        {
            bool whoStrikesFirst = true;
            Monster monster = new Monster();
            MessagePlayer(message.MonsterAppears());
            if(GotDetected() == true)
            {
                MessagePlayer(message.MonsterSeesYou());
                Battle(whoStrikesFirst);
            }
            else
            {
                MessagePlayer(message.MonsterDidntSeeYou());
                MessagePlayer(message.SneakOrAttack);
                if(CollectMenuSelection(2) == 1)
                {
                    if(GotDetected() == true)
                    {
                        MessagePlayer(message.approachTooNoisy);
                        MessagePlayer(message.MonsterSeesYou());
                        Battle(whoStrikesFirst);
                    }
                    else
                    {
                        MessagePlayer(message.approachSuccessfull());
                        whoStrikesFirst = false;
                        Battle(whoStrikesFirst);
                    }
                }
                else
                {
                    if(GotDetected() == true)
                    {
                        MessagePlayer(message.sneakTooNoisy);
                        MessagePlayer(message.MonsterSeesYou());
                        Battle(whoStrikesFirst);
                    }
                    else
                    {
                        MessagePlayer(message.sneakSuccess);
                    }
                }
            }

        }

        public static void GoldFindEvent()
        {
            int amount = FoundGoldAmount();
            UpdateStaticIntClassField(typeof(Player), "gold", amount);
            MessagePlayer(message.foundGold(amount));
        }

        public static void TrapEvent()
        {
            MessagePlayer(message.trap());
            int chance = random.Next(1, 101);
            if(chance > 50)
            {
                int damage = -1 * DiceRoll(2);
                UpdateStaticIntClassField(typeof(Player), "health", damage);
                MessagePlayer(message.trapDamage(damage * -1));
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

        public static bool PlayAgainMenu()
        {
            method.MessagePlayer(message. newLine + message.playAgain);
            if(collectYorNselection() == "y")
            {
                return true;
            }
            return false;
        }
        public static void AssessPlayerHealth()
        {
            if(Player.health < 1)
            {
                FinishGame(Cause.death);
            }
        }
        public static void FinishGame(string cause)
        {
            switch(cause)
            {
                case "death":
                    MessagePlayer(message.death());
                    return;
                case "exit":
                    MessagePlayer(message.exit + message.newLine + message.backstab());
                    return;
                case "victory":
                    MessagePlayer(message.victory() + message.newLine + message.backstab());
                    return;
                default:
                    return;
            }
            throw new GameFinished();
        }

        public static void BattleMenu()
        {

        }
        public static void NewRoomOrQuitMenu()
        {
            MessagePlayer(message.askNextRoom);
            string choice = collectYorNselection();
            if(choice == "n")
            {
                FinishGame(Cause.exit);
            }
        }
        public static void DoCurrentRoom()
        {
            Room currentRoom = CreateNewRoom();
            Room.RoomEvent();
            AssessPlayerHealth();
            NewRoomOrQuitMenu();
        }
        public static void ProceedFromRoomToRoom()
        {
            bool isFirstRoom = true;
            int numberOfRooms = 10;
            do
            {
                if(isFirstRoom == true)
                {
                    MessagePlayer(message.goodLuck());
                    DoCurrentRoom();
                    isFirstRoom = false;
                    numberOfRooms -= 1;
                }
                else
                {
                    MessagePlayer(message.proceed);
                    DoCurrentRoom();
                    numberOfRooms -= 1;
                }
            }
            while(numberOfRooms > 0);
            FinishGame(Cause.victory);
        }
        public static void Game()
        {
            MessagePlayer(message.welcome);
            Player player = new Player();
            Player.name = CollectPlayerName();
            ProceedFromRoomToRoom();
        }

        

        
    }
}