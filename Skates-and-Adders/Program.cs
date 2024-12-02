// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

class Program
{
    public class Messages()
    {
        public String newLine = "\n";
        public String askForNumber = "Pick a number to see the times-tables for it, up to 12\nType a number, then press ENTER";
        public string thanksForChoosingNumber(int chosenForTimesTables)
        {
            return "Great! Let see the times-tables for " + chosenForTimesTables;
        }
        public String rejectInvalidChoice = "That wasn't a valid choice. You have to type a number, using the number keys, then press ENTER";
        public String positiveTodayPlease = "We're only doing positive numbers today. Choose again.";
    }

    static void Main()
    {
        Messages message = new Messages();
        int chosenForTimesTables = 0;

        
        

        void MessagePlayer(string message)
        {
            Console.WriteLine(message);
        }

        string CollectPlayerInput(string message)
        {
            MessagePlayer(message);
            return Console.ReadLine();
        }

        (bool convertible, Boolean aboveZero) testInput(string convertMe)
        {
            Boolean convertible = false;
            Boolean aboveZero = false;
            if(int.TryParse(convertMe, out int conversionResult))
            {
                convertible = true;
                if(conversionResult > 0)
                {
                    aboveZero = true;
                }
                return (convertible, aboveZero);
            }else{
                return (convertible, aboveZero);
            }
        }

        // int SanitizedNumberChoice(string input)
        // {
        //     String toBeConverted = input;
        //     int convertedInput = 0;
        //     while(int.TryParse(toBeConverted, out int result) == false)
        //     {
        //         toBeConverted = CollectPlayerInput(message.rejectInvalidChoice);
        //         while(int.TryParse(toBeConverted, out int num) && result < 0)
        //         {
        //             toBeConverted = CollectPlayerInput(message.positiveTodayPlease);
        //         }
        //     }
        //     convertedInput = int.Parse(toBeConverted);
        //     return convertedInput;
        // }


        int SanitizedNumberChoice(string userInput)
        {
            string toBeConverted = userInput;
            int convertedInput = 0;
            while(testInput(toBeConverted).convertible == false || testInput(toBeConverted).aboveZero == false)
            {
                if(testInput(toBeConverted).convertible == false)
                {
                    toBeConverted = CollectPlayerInput(message.rejectInvalidChoice);
                }else{
                    toBeConverted = CollectPlayerInput(message.positiveTodayPlease);
                }
            }
            convertedInput = int.Parse(toBeConverted);
            return convertedInput;
        }

        void ShowTimestables(int number, int startNumber, int endNumber)
        {
            int start = startNumber;

            int numberOfLines = endNumber - startNumber;
            String Table = "";
            int lineInTable = startNumber;
            String currentLine = "";
            for(int i = 0; i < numberOfLines; i++)
            {
                currentLine = 
            }
        }

        chosenForTimesTables = int.Parse(CollectPlayerInput(message.askForNumber));

        MessagePlayer(message.thanksForChoosingNumber(chosenForTimesTables));


    }
}
