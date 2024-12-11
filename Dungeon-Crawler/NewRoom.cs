namespace MyNewRoom
{
    using MyDungeonCrawlerMethods;

    public class Room
    {
        //DungeonCrawlerMethods method = new DungeonCrawlerMethods();
        public int num = 0;
        public int randomRoomEvent = 0;

        public Room()
        {
            randomRoomEvent = method.random.Next(1, 6);
            switch(randomRoomEvent)
            {
                case 1:
                    num = method.OneD6();
                    break;
                case 2:
                    num = method.DiceRoll(7);
                    break;
                default:
                    num = 0;
                    break;
            }

        }
    }
}