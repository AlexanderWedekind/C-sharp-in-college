// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace strings
{
    class Program
    {
        public static void Main()
        {
            String firstName = "";
            String lastName = "";
            String nickName = "";
            String nickNameInTheMiddle = "";
            String fullName = "";
            String abbreviatedName = "";

            String askFirstName = "Choose your character's first name...\n(type their name, then press ENTER)";
            String askLastName = "Thank you, now please choose your character's lastname...\n(type their lastname, then press ENTER)";
            String askNickName = "And finally, what is your character's nickname...\n(type their nickname, then press ENTER)";
            String rejectEmptyInput = "You can't leave this blank. Please choose something and press ENTER";

            Random random = new Random();


            

            static Boolean TestForEmptyString(string input)
            {
                if(input == "")
                {
                    //Console.WriteLine("TestForEmptyString: \n" + "(" + input + " == \"\"): " + (input == ""));
                   // Console.WriteLine("returning true");
                    return true;
                }
                //Console.WriteLine("TestForEmptyString: \n" + "(" + input + " == \"\"" + " :" + (input == ""));
                //Console.WriteLine("returning false");
                return false;
            }    

            static string TrimLeadingSpaces(string name)
            {   
                String trimmedName = name;
                //Console.WriteLine("TrimLeadingSpaces: \n" + "trimmedName: \"" + trimmedName + "\"");
                if(TestForEmptyString(trimmedName) == false)
                {
                    int count = 0;
                    //Console.WriteLine("in \"if\"\n trimmedName: \"" + trimmedName + "\" | count: " + count);
                    while(trimmedName.Substring(0, 1) == " ")
                    {
                        count += 1;
                        //Console.WriteLine("in \"while\": trimmedName: \"" + trimmedName + "\" | count: " + count);
                        //Console.WriteLine("in \"while\": trimmedName.Substring(0, 1): " + "\"" + trimmedName.Substring(0, 1) + "\"");
                        if(trimmedName.Length > 1)
                        {
                            //Console.WriteLine("(trimmedName.Length > 1): " + (trimmedName.Length > 1));
                            //Console.WriteLine("trimmedName.Substring(1, trimmedName.Length - 1): \"" + trimmedName.Substring(1, trimmedName.Length - 1) + "\"");
                            //Console.WriteLine("trimmedName: \"" + trimmedName + "\"");
                            trimmedName = trimmedName.Substring(1, trimmedName.Length - 1);
                            
                            
                            //Console.WriteLine("trimmedName: \"" + trimmedName + "\"");
                        }
                        else
                        {
                            //Console.WriteLine("(trimmedName.Length > 1): " + (trimmedName.Length > 1));
                            //Console.WriteLine("trimmedName.Substring(0, 0): " + "\"" + trimmedName.Substring(0, 0) + "\"");
                            //Console.WriteLine("trimmedName: " + trimmedName);
                            trimmedName = trimmedName.Substring(0, 0);
                            //Console.WriteLine("trimmedName: " + trimmedName);
                        }
                    }
                }
                //Console.WriteLine("returning: \"" + trimmedName + "\"");
                return trimmedName;
            }

            static string TrimTrailingSpaces(string name)
            {
                String trimmedName = name;
                if(TestForEmptyString(trimmedName) == false)
                {
                    while(trimmedName.Substring(trimmedName.Length - 1, 1) == " ")
                    {
                        trimmedName = trimmedName.Substring(0, trimmedName.Length - 1);
                    }
                }
                return trimmedName;
            }

            static void AskPlayer(string message)
            {
                Console.WriteLine(message);
            }

            static string CollectPlayerInput(string question)
            {               
                AskPlayer(question);
                return Console.ReadLine();
            }

            string SanitizedPlayerInput(string input)
            {
                String playerInput = input;
                while(TestForEmptyString(TrimTrailingSpaces(TrimLeadingSpaces(playerInput))) == true)
                {
                    playerInput = CollectPlayerInput(rejectEmptyInput);
                }
                return TrimTrailingSpaces(TrimLeadingSpaces(playerInput));
            }
           
            firstName = SanitizedPlayerInput(CollectPlayerInput(askFirstName));

            lastName = SanitizedPlayerInput(CollectPlayerInput(askLastName));

            nickName = SanitizedPlayerInput(CollectPlayerInput(askNickName));

            nickNameInTheMiddle = "\"" + nickName + "\"";

            fullName = firstName + " " + nickNameInTheMiddle + " " + lastName;

            Console.WriteLine("Welcome, " + fullName + "!");

            abbreviatedName = fullName.Substring(0, 1) + fullName.Substring(fullName.LastIndexOf(" "), fullName.Length - fullName.LastIndexOf(" "));

            
            int strength = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            int dexterity = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            int willpower = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);

            Console.WriteLine("Your stats are: \n Strength: " + strength + "\nDexterity: " + dexterity + "\nWillpower: " + willpower);

            

            



           

        }
    }
}
