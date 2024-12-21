namespace MyNewRoom
{
    using System.Security.Cryptography.X509Certificates;
    using MyDungeonCrawlerMethods;
    using MyPlayer;

    public class Room
    {
        //DungeonCrawlerMethods method = new DungeonCrawlerMethods();
        public  static int number = 0;
        public delegate void ThisRoomEvent();
        public static ThisRoomEvent RoomEvent;
        


        public Room(ThisRoomEvent roomEvent1, ThisRoomEvent roomEvent2, ThisRoomEvent roomEvent3, ThisRoomEvent roomEvent4, ThisRoomEvent roomEvent5)
        {
            number = method.random.Next(1, 8);
            switch(number)
            {
                case 1:
                    RoomEvent = roomEvent1;
                    break;
                case 2:
                    RoomEvent = roomEvent2;
                    break;
                case 3:
                    RoomEvent = roomEvent3;
                    break;
                case 4:
                    RoomEvent = roomEvent4;
                    break;
                case 5:
                case 6:
                case 7:
                    RoomEvent = roomEvent5;
                    break;
                default:
                    break;
            }

        }
    }
}