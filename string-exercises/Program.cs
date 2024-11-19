// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace strings
{
    class Program
    {
        public static void Main()
        {
            String firstName;
            String lastName;
            String nickName;
            String nickNameInTheMiddle;
            String abbreviatedName = " ";

            Console.WriteLine("Choose your character's first name...\n(type their name, then press ENTER)");
            firstName = Console.ReadLine();

            Console.WriteLine("Thank you, now please choose your character's lastname...\n(typr their lastname, then press ENTER)");
            lastName = Console.ReadLine();

            Console.WriteLine("And finally, what is your character's nickname...\n(type their nickname, then press ENTER)");
            nickName = Console.ReadLine();

            nickNameInTheMiddle = "\"" + nickName + "\"";

            Console.WriteLine("Okay, your character is called: " + firstName + " " + nickNameInTheMiddle + " " + lastName );

           

        }
    }
}
