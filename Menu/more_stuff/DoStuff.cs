using MyMenuMessages;
using MyRetirementChecker;
using MyOrcVHuman;
using MyTimesTableGenerator;
using MyMedievalMagicalAdventure;

namespace MyMenuMethods
{
    public class MenuMethods
        {
            MenuMessages message = new MenuMessages();
            public void MessageUser(string message)
            {
                Console.WriteLine(message);
            }

            public string CollectUserInput(string message)
            {
                MessageUser(message);
                return Console.ReadLine();
            }

            
            (bool isNum, bool isValidChoice) CheckMenuChoice(string userInput, int[] menuRange)
            {
                bool isNum = false;
                bool isValidChoice = false;
                if(int.TryParse(userInput, out int choice))
                {
                    isNum = true;
                    for(int i = 0; i < menuRange.Length; i++)
                    {
                        if(choice == menuRange[i])
                        {
                            isValidChoice = true;
                        }
                    }
                }
                return (isNum, isValidChoice);
            }

            public int CollectMenuChoice()
            {
                int[] menuRange = [1, 2, 3, 4, 5];
                string userInput = CollectUserInput(message.newLine + message.makeAChoice + message.newLine + message.newLine + message.menu + message.newLine + message.newLine + message.typeAndEnter);
                while(CheckMenuChoice(userInput, menuRange).isNum == false || CheckMenuChoice(userInput, menuRange).isValidChoice == false)
                {
                    if(CheckMenuChoice(userInput, menuRange).isNum == false)
                    {
                        userInput = CollectUserInput(message.rejectNotNumber);
                    }
                    else
                    {
                        userInput = CollectUserInput(message.rejectNotAMenuChoice + message.newLine + message.typeAndEnter);
                    }
                }
                return int.Parse(userInput);
            }
            
            public void Exit()
            {
                MessageUser(message.newLine + message.goodBye + message.newLine);
                Environment.Exit(0);
            }

            public void Menu()
            {
                bool isFirstMenuAppearance = true;
                bool session = true;
                int menuChoice = 0;
                while(session)
                {
                    if(isFirstMenuAppearance == true)
                    {
                        MessageUser(message.newLine + message.helloThere);
                        isFirstMenuAppearance = false;
                    }
                    else
                    {
                        MessageUser(message.newLine + message.backAtMenu);
                    }
                    menuChoice = CollectMenuChoice();
                    switch(menuChoice)
                    {
                        case 1:
                            Console.WriteLine("\nmenu choice 1 : Times Table Generator");
                            TimesTableGenerator.RunTimesTableGenerator();
                            break;
                        case 2:
                            Console.WriteLine("\nmenu choice 2 : Orc v Dwarf Battle");
                            OrcVHuman.RunOrcVHuman();
                            break;
                        case 3:
                            Console.WriteLine("\nmenu choice 3 : Magical Medieval Adventure");
                            MedievalMagicalAdventure.RunMedievalMagicalAdventure();
                            break;
                        case 4:
                            Console.WriteLine("\nmenu choice 4 : Retirement Checker");
                            RetirementChecker.RunRetirementChecker();
                            break;
                        case 5:
                            Exit();
                            break;
                    }
                }
            }


            public void SayHelloThere()
            {
                MessageUser(message.helloThere);
            }
        }
}