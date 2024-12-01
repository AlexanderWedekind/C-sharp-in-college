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
            (string option1, string choiceKey1, string option2, string choiceKey2, string article) StartItemOptions()
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
                        choiceKey1 = "(A)";
                        item2 = "Sword";
                        choiceKey2 = "(S)";
                        article = "An";
                        break;
                    case "Thief":
                        item1 = "Bow";
                        choiceKey1 = "(B)";
                        item2 = "Dagger";
                        choiceKey2 = "(D)";
                        article = "A";
                        break;
                    default:
                        break;
                }
                return (item1, choiceKey1, item2, choiceKey2, article);
            }
            String startingItem = "";
            int strength = 0;
            int dexterity = 0;
            int willpower = 0;


            String askFirstName = "Choose your character's first name...\n(type their name, then press ENTER)";
            String askLastName = "Thank you, now please choose your character's lastname...\n(type their lastname, then press ENTER)";
            String askNickName = "And finally, what is your character's nickname...\n(type their nickname, then press ENTER)";
            String rejectEmptyInput = "You can't leave this blank. Please choose something and press ENTER";
            String rejectIncorrectSelection = "You have to choose trom one of the options given.\nPlease choose by typing one of the options given, then press ENTER";
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
            string AnnounceStartingItem()
            {
                if(startingItem == "Axe")
                {
                    return "You have chosen to start your adventure with an " + startingItem + " equipped.";
                }
                else
                {
                    return "You have chosen to start your adventure with a " + startingItem + " equipped.";
                }
            }
            string askStartingItem()
            {
                return "Choose your starting item.\nWould you like " 
                + StartItemOptions().article + " " + StartItemOptions().option1 + " " + StartItemOptions().choiceKey1 + 
                " or a " + StartItemOptions().option2 + " " + StartItemOptions().choiceKey2 + 
                " ?\nMake your choice by typing " + StartItemOptions().choiceKey1 + " or " + StartItemOptions().choiceKey2 + " and pressing ENTER";
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

            Boolean CheckStartingItemChoice(string choice)
            {
                String playerchoice = choice;
                switch(characterClass)
                {
                    case "Mage":
                        switch(playerchoice.ToLower())
                        {
                            case "s":
                                return true;
                            case "b":
                                return true;
                            default:
                                return false;
                        }
                    case "Warrior":
                        switch(playerchoice.ToLower())
                        {
                            case "a":
                                return true;
                            case "s":
                                return true;
                            default:
                                return false;
                        }
                    case "Thief":
                        switch(playerchoice.ToLower())
                        {
                            case "b":
                                return true;
                            case "d":
                                return true;
                            default:
                                return false;
                        }
                    default:
                        return false;
                }
            }

            string CollectStartingItemChoice()
            {
                String validChoice = "";
                String playerInput = SanitizedPlayerInput(CollectPlayerInput(askStartingItem()));
                while(CheckStartingItemChoice(playerInput) == false)
                {
                    playerInput = SanitizedPlayerInput(CollectPlayerInput(rejectIncorrectSelection));
                }
                switch(characterClass)
                {
                    case "Mage":
                        switch(playerInput.ToLower())
                        {
                            case "s":
                                validChoice = "Staff";
                                break;
                            case "b":
                                validChoice = "Spellbook";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Warrior":
                        switch(playerInput.ToLower())
                        {
                            case "a":
                                validChoice = "Axe";
                                break;
                            case "s":
                                validChoice = "Sword";
                                break;
                        }
                        break;
                    case "Thief":
                        switch(playerInput.ToLower())
                        {
                            case "b":
                                validChoice = "Bow";
                                break;
                            case "d":
                                validChoice = "Dagger";
                                break;
                        }
                        break;

                }
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

            startingItem = CollectStartingItemChoice();

            AskPlayer(AnnounceStartingItem());


        }
    }
}
