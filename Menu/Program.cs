// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

using MyMenuMessages;

using MyMenuMethods;

namespace Menu
{
    class Program
    {
        // public class MenuMessages
        // {
        //     public string helloThere = "Hello there!";
        //     public string welcome = "Choose what you want to do";
        //     public string newLine = "\n";
        //     public string rejectNotAMenuChoice = "Please pick one of the options on the menu";
        //     public string typeAndEnter = "(choose by typing a number, then press ENTER)";
        //     public string rejectNotNumber = "That wasn't a valid choice; pick an option by using the NUMBER keys";
        //     public string menu = "Options:\n"
        //     + "1) Times Table Generator\n"
        //     + "2) Orc v Dwarf Battle\n"
        //     + "3) Magical Medieval Adventure\n"
        //     + "4) Quit";
        //     public string goodBye = "Thank you. See you next time.";
        // }

        // public class MenuMethods
        // {
        //     MenuMessages message = new MenuMessages();
        //     public void MessageUser(string message)
        //     {
        //         Console.WriteLine(message);
        //     }

        //     public string CollectUserInput(string message)
        //     {
        //         MessageUser(message);
        //         return Console.ReadLine();
        //     }

            
        //     (bool isNum, bool isValidChoice) CheckMenuChoice(string userInput, int[] menuRange)
        //     {
        //         bool isNum = false;
        //         bool isValidChoice = false;
        //         if(int.TryParse(userInput, out int choice))
        //         {
        //             isNum = true;
        //             for(int i = 0; i < menuRange.Length; i++)
        //             {
        //                 if(choice == menuRange[i])
        //                 {
        //                     isValidChoice = true;
        //                 }
        //             }
        //         }
        //         return (isNum, isValidChoice);
        //     }

        //     public int CollectMenuChoice()
        //     {
        //         int[] menuRange = [1, 2, 3, 4];
        //         string userInput = CollectUserInput(message.welcome + message.newLine + message.menu + message.newLine + message.typeAndEnter);
        //         while(CheckMenuChoice(userInput, menuRange).isNum == false || CheckMenuChoice(userInput, menuRange).isValidChoice == false)
        //         {
        //             if(CheckMenuChoice(userInput, menuRange).isNum == false)
        //             {
        //                 userInput = CollectUserInput(message.rejectNotNumber);
        //             }
        //             else
        //             {
        //                 userInput = CollectUserInput(message.rejectNotAMenuChoice + message.newLine + message.typeAndEnter);
        //             }
        //         }
        //         return int.Parse(userInput);
        //     }
            
        //     public void Exit()
        //     {
        //         MessageUser(message.goodBye);
        //         Environment.Exit(0);
        //     }

        //     public void Menu()
        //     {
        //         bool session = true;
        //         int menuChoice = 0;
        //         while(session)
        //         {
        //             MessageUser(message.helloThere);
        //             menuChoice = CollectMenuChoice();
        //             switch(menuChoice)
        //             {
        //                 case 1:
        //                     Console.WriteLine("menu choice 1 : Times Table Generator");
        //                     break;
        //                 case 2:
        //                     Console.WriteLine("menu choice 2 : Orc v Dwarf Battle");
        //                     break;
        //                 case 3:
        //                     Console.WriteLine("menu choice 3 : Magical Medieval Adventure");
        //                     break;
        //                 case 4:
        //                     Exit();
        //                     break;
        //             }
        //         }
        //     }


        //     public void SayHelloThere()
        //     {
        //         MessageUser(message.helloThere);
        //     }
        // }
        
        static void Main()
        {
            MenuMessages message = new MenuMessages();

            MenuMethods method = new MenuMethods();

            method.Menu();


        }
    }
}
