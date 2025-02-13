

namespace arrayExercises2
{
    struct Message
    {
        public static string NewLine = "\n";
        public static string welcome = "Welcome!\nWe are going to find the largest number in a collection of numbers.\nYou can define the collection yourself, or have it generated randomly.";
        
    }

    class Program
    {
        public static void MessageUser(string message)
        {
            Console.WriteLine(message);
        }



        public static void Main()
        {
            
            MessageUser(Message.welcome);
        }
    }
}