using MyNewPlayer;

namespace MyDungeonCrawlerMethods
{
    public class DungeonCrawlerMethods
    {
        public Random random = new Random();
        public int OneD6()
        {
            int throwResult = 0;
            throwResult = random.Next(1, 7);
            return throwResult;
        }

        public int DiceRoll(int numberOfDice)
        {
            int roll = 0;
            for(int i = 0; i < numberOfDice; i++)
            {
                roll = roll + OneD6();
            }
            return roll;
        }

        public int GoldFind()
        {   
            return OneD6() * 100;
        }

        public void ItemFind()
        {
            int find = random.Next(1, 4);
            switch(find)
            {
                case 1:
                    currentPlayer.attack += 2;
                    break;
                case 2:
                    
            }

        }




    }

    
}