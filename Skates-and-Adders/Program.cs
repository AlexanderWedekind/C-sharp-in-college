// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

class Program
{
    public class Messages()
    {
        public string newLine = "\n";
        public string welcome = "Hello there!\nWelcome to:\nTimes Tables Generator 9001 (c)\n\nYou can use this tool to generate times tables, withing a range of your choosing.";
        public string askForNumber = "Pick a number to see the times-tables for it.";
        public string thanksForChoosingNumber(int chosenForTimesTables)
        {
            return "Great! Let see the times-tables for " + chosenForTimesTables + ".";
        }
        public string rejectInvalidChoice = "That wasn't a valid choice.\nYou have to type a number, using the number keys, then press ENTER.";
        public string positiveTodayPlease = "We're only doing positive numbers today. Choose again.";
        public string explainRangeChoice(int chosenForTimesTables)
        {
            return "You can choose where to start and where to end generating the times table.\nFor example: if you want to see the answers from '" 
            + chosenForTimesTables + " x 4 =' up to '" + chosenForTimesTables + " x 29 =' and all the ones inbetween,\n" 
            + "then you pick 4 as your starting number and 29 as your end number.";
        }
        public string typeAndEnter = "(Type a number, then press ENTER)";
        public string askStartNumber = "First, pick the starting number.";
        public string askForEndNumber = "Now, pick your end number.";
        public string thanks = "Thank you.";
        public string announceResults = "Here are the results:";
        public string goodbye = "Thank you for using Times Tables Generator 9001 (c)";
    }

    

    static void Main()
    {
        Messages message = new Messages();

        int chosenForTimesTables = 0;
        int startNumber = 0;
        int endNumber = 0;
        string[] table;

        void MessagePlayer(string message)
        {
            Console.WriteLine(message);
        }

        string CollectPlayerInput(string message)
        {
            MessagePlayer(message);
            return Console.ReadLine();
        }

        (bool convertible, bool aboveZero) testInput(string convertMe)
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

        int SanitizedNumberChoice(string userInput)
        {
            string toBeConverted = userInput;
            int convertedInput = 0;
            while(testInput(toBeConverted).convertible == false || testInput(toBeConverted).aboveZero == false)
            {
                if(testInput(toBeConverted).convertible == false)
                {
                    toBeConverted = CollectPlayerInput(message.newLine + message.rejectInvalidChoice);
                }else{
                    toBeConverted = CollectPlayerInput(message.positiveTodayPlease + message.newLine + message.typeAndEnter);
                }
            }
            convertedInput = int.Parse(toBeConverted);
            MessagePlayer(message.newLine + message.thanks);
            return convertedInput;
        }

        string[] GenerateTimesTables(int number, int startNumber, int endNumber)
        {
            int numberOfLines = endNumber - startNumber + 1;
            string[] Table = [];
            int lineInTable = startNumber;
            string currentLine = "";
            int answer = 0;
            for(int i = 0; i < numberOfLines; i++)
            {
                answer = lineInTable * number;
                currentLine = lineInTable + " x " + number + " = " + answer;
                // Table = Table + "\n" + currentLine;
                Table = Table.Append(currentLine).ToArray();
                lineInTable ++;
            }
            return Table;
        }

        void PrintResults(string[] table)
        {
            for(int i = 0; i < table.Length; i++)
            {
                MessagePlayer(table[i]);
            }
        }

        


        MessagePlayer(message.newLine + message.welcome);

        chosenForTimesTables = SanitizedNumberChoice(CollectPlayerInput(message.newLine + message.askForNumber + message.newLine + message.typeAndEnter));

        MessagePlayer(message.thanksForChoosingNumber(chosenForTimesTables));

        MessagePlayer(message.newLine + message.explainRangeChoice(chosenForTimesTables));

        startNumber = SanitizedNumberChoice(CollectPlayerInput(message.askStartNumber));

        endNumber = SanitizedNumberChoice(CollectPlayerInput(message.askForEndNumber));

        table = GenerateTimesTables(chosenForTimesTables, startNumber, endNumber);

        MessagePlayer(message.newLine + message.announceResults + message.newLine);

        PrintResults(table);

        MessagePlayer(message.newLine + message.goodbye);
    }
}
