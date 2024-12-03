// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

class Program
{
    public class Messages
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
        public string rejctNegativeAge = "Your age is not negative; please choose a positive number, then press ENTER.";
        public string announceAgeVerification = "This app requires age verification.";
        public string askAge = "Please enter your age.";
        public string denyAccessAge = "Based on your age, we determine that this app is too exciting for you.\nUnfortunately you won't be able to play.\nGoodbye.";
        public string announcePassAgeCheck = "We think you can handle the excitement.";
    }

    

    static void Main()
    {
        Messages message = new Messages();

        int chosenForTimesTables = 0;
        int startNumber = 0;
        int endNumber = 0;
        string[] table;
        int playerAge = 0;
        string age = "Age";
        string number = "Number";

        void MessagePlayer(string message)
        {
            Console.WriteLine(message);
        }

        string CollectPlayerInput(string message)
        {
            MessagePlayer(message);
            return Console.ReadLine();
        }
        /// <summary>
        /// assesses if a user input string can be parsed into int, and if
        /// </summary>
        /// <param name="convertMe">user chosen number. this will be a string</param>
        /// <returns>struct: (bool convertible, bool aboveZero)</returns>
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

        int SanitizedNumberChoice(string userInput, string ageOrNumber)
        {
            string toBeConverted = userInput;
            int convertedInput = 0;
            while(testInput(toBeConverted).convertible == false || testInput(toBeConverted).aboveZero == false)
            {
                if(testInput(toBeConverted).convertible == false)
                {
                    toBeConverted = CollectPlayerInput(message.newLine + message.rejectInvalidChoice);
                }else{
                    if(ageOrNumber =="Number")
                    {
                        toBeConverted = CollectPlayerInput(message.positiveTodayPlease + message.newLine + message.typeAndEnter);
                    }else{
                        toBeConverted = CollectPlayerInput(message.rejctNegativeAge);
                    }
                }
            }
            convertedInput = int.Parse(toBeConverted);
            MessagePlayer(message.newLine + message.thanks);
            return convertedInput;
        }

        bool verifyAge(int playerAge)
        {
            if(playerAge < 18 || playerAge > 65)
            {
                MessagePlayer(message.denyAccessAge);
                return false;
            }
            MessagePlayer(message.announcePassAgeCheck);
            return true;
        }
        /// <summary>
        /// will return and array of strings. Each array element contain a row in a times table, eg.: ["4 x 3 = 12", "4 x 4 = 16", ... ].
        /// Times Tables is generated bases on user-chosen parameters: Number to be multiplied; Range by choosing a starting number and an end number, 
        /// eg.: number = 4; startNumber = 3; endNumber = 7; return = ["4 x 3 = 12", ... , "4 x 7 = 28"] 
        /// </summary>
        /// <param name="number">the number the player has chose to be multiplied</param>
        /// <param name="startNumber">user chosen start number</param>
        /// <param name="endNumber">user chosen end number</param>
        /// <returns>Table</returns>
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



        
        MessagePlayer(message.newLine + message.announceAgeVerification);

        if(verifyAge(SanitizedNumberChoice(CollectPlayerInput(message. newLine + message.askAge), age)))
        {
            MessagePlayer(message.newLine + message.welcome);

            chosenForTimesTables = SanitizedNumberChoice(CollectPlayerInput(message.newLine + message.askForNumber + message.newLine + message.typeAndEnter), number);

            MessagePlayer(message.thanksForChoosingNumber(chosenForTimesTables));

            MessagePlayer(message.newLine + message.explainRangeChoice(chosenForTimesTables));

            startNumber = SanitizedNumberChoice(CollectPlayerInput(message.askStartNumber), number);

            endNumber = SanitizedNumberChoice(CollectPlayerInput(message.askForEndNumber), number);

            table = GenerateTimesTables(chosenForTimesTables, startNumber, endNumber);

            MessagePlayer(message.newLine + message.announceResults + message.newLine);

            PrintResults(table);

            MessagePlayer(message.newLine + message.goodbye + message.newLine);
        }

        
    }
}
