using MyPlayer;

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

        

        public static void UpdateStaticPlayerField(Type classType, string fieldName, int updateValue)
        {
            var staticPlayerField = classType.GetField(fieldName);
            int currentStaticFieldValue = Convert.ToInt32(classType.GetField(fieldName));
            int newValue = currentStaticFieldValue + updateValue;
            staticPlayerField.SetValue(null, newValue);
        }

        public static void ItemFind()
        {   
            int find = random.Next(1, 4);
            switch(find)
            {
                case 1:
                    UpdateStaticPlayerField(typeof(Player), "attack", 2);
                    break;
                case 2:
                    UpdateStaticPlayerField(typeof(Player), "defence", 2);
                    break;
                case 3:
                    UpdateStaticPlayerField(typeof(Player), "healingPotion", 1);
                    break;
            }
        }

        public static void HealingFountain()
        {

        }
    }
}