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

            static string TrimLeadingSpaces(string name)
            {   
                String trimmedName = name;
                while(trimmedName.Substring(0, 1) == " ")
                {
                    trimmedName = trimmedName.Substring(1, trimmedName.Length - 1);
                }
                return trimmedName;
            }

            Console.WriteLine("Choose your character's first name...\n(type their name, then press ENTER)");
            firstName = TrimLeadingSpaces(Console.ReadLine());

            Console.WriteLine("Thank you, now please choose your character's lastname...\n(typr their lastname, then press ENTER)");
            lastName = TrimLeadingSpaces(Console.ReadLine());

            Console.WriteLine("And finally, what is your character's nickname...\n(type their nickname, then press ENTER)");
            nickName = TrimLeadingSpaces(Console.ReadLine());

            nickNameInTheMiddle = "\"" + nickName + "\"";

            fullName = firstName + " " + nickNameInTheMiddle + " " + lastName;

            Console.WriteLine(fullName);

            abbreviatedName = fullName.Substring(0, 1) + fullName.Substring(fullName.LastIndexOf(" "), fullName.Length - fullName.LastIndexOf(" "));

            Console.WriteLine(abbreviatedName);

            



           

        }
    }
}
