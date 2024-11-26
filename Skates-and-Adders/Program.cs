// See https://aka.ms/new-console-template for more information
class Program
    {
        static void Main()
        {
            int chosenForTimesTables = 0;

            String viewTimestables = "Pick a number to see the times-tables for it, up to 12\nType a number, then press ENTER";
            string thankYouTimesTables()
            {
                return "Great! Let see the times-tables for " + chosenForTimesTables;
            }

            void MessagePlayer(string message)
            {
                Console.WriteLine("\n" + message);
            }

            string CollectPlayerInput(string message)
            {
                MessagePlayer(message);
                return Console.ReadLine();
            }

            // Boolean ValidateInput(string userInput)
            // {
            //     if(userInput ==)
            // }

            void ShowTimestables(int number)
            {
                int currentTable = 1;
                int lineInTable = 1;
                for(int i = 0; i < 12; i++)
                {

                }
            }

            chosenForTimesTables = int.Parse(CollectPlayerInput(viewTimestables));

            MessagePlayer(thankYouTimesTables());


        }
    }
