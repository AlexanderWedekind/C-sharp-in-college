// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Collections;

namespace string_exercises
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
            String characterClass = "";
            (string option1, string option2, string article) StartItemOptions(string characterClass)
            {
                String article = "";
                String item1 = "";
                String item2 = "";
                String choiceKey1 = "";
                String choiceKey2 = "";
                switch(characterClass)
                {
                    case "Mage":
                        item1 = "Staff" ;
                        choiceKey1 = "(S)";
                        item2 = "Spellbook";
                        choiceKey2 = "(B)";
                        article = "A";
                        break;
                    case "Warrior":
                        item1 = "Axe";
                        choice
                        item2 = "Sword";
                        article = "An";
                        break;
                    case "Thief":
                        item1 = "Bow";
                        item2 = "Dagger";
                        article = "A";
                        break;
                }
                return (item1, item2, article);
            }
            String startingItem = "";
            int strength = 0;
            int dexterity = 0;
            int willpower = 0;


            String askFirstName = "Choose your character's first name...\n(type their name, then press ENTER)";
            String askLastName = "Thank you, now please choose your character's lastname...\n(type their lastname, then press ENTER)";
            String askNickName = "And finally, what is your character's nickname...\n(type their nickname, then press ENTER)";
            String rejectEmptyInput = "You can't leave this blank. Please choose something and press ENTER";
            string welcomeMessage()
            {
                return "Welcome, " + fullName + "!";
            }
            string announceStats()
            {
                return "Your stats are: \n Strength: " + strength + "\nDexterity: " + dexterity + "\nWillpower: " + willpower;
            }
            String askCharacterClass = "Choose the class you want to play as; Mage (M), Warrior (W) or Thief (T). \n(Type \"m\", \"w\" or \"t\", then press ENTER)";
            String rejectInvalidClassChoice = "You must choose either Mage (M), Warrior (W) or Thief (T)\nPlease type \"m\", \"w\" or \"t\" to choose your class, then press ENTER";
            string announceclassChoice()
            {
                return "You have chosen to play the " + characterClass + " class.";
            }
            string askStartingItem()
            {
                return "Choose your starting item.\nWould you like " + StartItemOptions(characterClass).article + " " + StartItemOptions(characterClass).option1 + " or "
            }

            Random random = new Random();


            
 
            static Boolean TestForEmptyString(string input)
            {
                if(input == "")
                {
                    return true;
                }
                return false;
            }    

            static string TrimLeadingSpaces(string name)
            {   
                String trimmedName = name;
                while(TestForEmptyString(trimmedName) == false && trimmedName.Substring(0, 1) == " ")
                {
                    if(trimmedName.Length > 1)
                    {
                        trimmedName = trimmedName.Substring(1, trimmedName.Length - 1);
                    }
                    else
                    {
                        trimmedName = trimmedName.Substring(0, 0);
                    }
                }
                return trimmedName;
            }

            static string TrimTrailingSpaces(string name)
            {
                String trimmedName = name;
                while(TestForEmptyString(trimmedName) == false && trimmedName.Substring(trimmedName.Length - 1, 1) == " ")
                {
                    if(trimmedName.Length > 1)
                    {
                        trimmedName = trimmedName.Substring(0, trimmedName.Length - 1);
                    }
                    else
                    {
                        trimmedName = trimmedName.Substring(0, 0);
                    }
                }
                return trimmedName;
            }

            static void AskPlayer(string message)
            {
                Console.WriteLine("\n" + message);
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

            Boolean CheckClassChoice(string choice)
            {
                Boolean judgedChoice = true;
                switch(choice.ToLower())
                {
                    case "m":
                        judgedChoice = true;
                        break;
                    case "w":
                        judgedChoice = true;
                        break;
                    case "t":
                        judgedChoice = true;
                        break;
                    default:
                        judgedChoice = false;
                        break;
                }
                return judgedChoice;
            }

            string CollectClassChoice()
            {
                String returnChosenClass = "";
                String chosenClass = SanitizedPlayerInput(CollectPlayerInput(askCharacterClass));
                while(CheckClassChoice(chosenClass) == false)
                {
                    chosenClass = SanitizedPlayerInput(CollectPlayerInput(rejectInvalidClassChoice));
                }
                switch(chosenClass)
                {
                    case "m":
                        returnChosenClass = "Mage";
                        break;
                    case "w":
                        returnChosenClass = "Warrior";
                        break;
                    case "t":
                        returnChosenClass = "Thief";
                        break;
                }
                return returnChosenClass;
            }

            string CollectStartingItemChoice()
            {
                String validChoice = "";
                String playerInput = SanitizedPlayerInput(CollectPlayerInput(askStartingItem()));
                return validChoice;
            }
           
            firstName = SanitizedPlayerInput(CollectPlayerInput(askFirstName));

            lastName = SanitizedPlayerInput(CollectPlayerInput(askLastName));

            nickName = SanitizedPlayerInput(CollectPlayerInput(askNickName));

            nickNameInTheMiddle = "\"" + nickName + "\"";

            fullName = firstName + " " + nickNameInTheMiddle + " " + lastName;

            AskPlayer(welcomeMessage());

            abbreviatedName = fullName.Substring(0, 1) + fullName.Substring(fullName.LastIndexOf(" "), fullName.Length - fullName.LastIndexOf(" "));

            
            strength = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            dexterity = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            willpower = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);

            AskPlayer(abbreviatedName + "\n" + announceStats());

            characterClass = CollectClassChoice();

            AskPlayer(announceclassChoice());

        }
    }
}
