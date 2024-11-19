// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace first
{
    class Program
    {
        public static void Main()
        {
            string employeeName = "";
            int employeeAge = 0;

            static void WaitMessageToConsole()
            {
                int dots = 0;

                Console.WriteLine("Please wait while we calculate your answer...");

                static void wait()
                {
                    int tic = 0;
                    for(int i = 0; tic < 50000000; i++)
                    {
                        tic ++;
                    }
                }
                
                while(dots < 4)
                {
                    wait();
                    Console.WriteLine(".");
                    dots ++;
                };                          
            }

            static Boolean RetirementCheck(int age)
            {
                if(age > 64)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            static string YearsEligible(int age)
            {
                int years = 0;
                years = age - 64;
                if(years == 1)
                {
                    return "this year.";
                }
                else
                {
                    return years.ToString() + " years ago.";
                }
            }

            static string YearsLeft(int age)
            {
                int years = 0;
                years = 65 - age;
                if(years == 1)
                {
                    return "at the end of this year.";
                }
                else
                {
                    return "in " + years.ToString() + " years.";
                }
            }

            Console.WriteLine("Hello there!\nWelcome to: Retirement Checker 92000 (tm)\nPlease enter the name of the employee you want to check:\n(type thier name and press ENTER)");

            employeeName = Console.ReadLine();

            Console.WriteLine("Thank you.\nNow please provide thier age:\n(type the age and press ENTER)");

            employeeAge = Int32.Parse(Console.ReadLine());

            WaitMessageToConsole();

            if(RetirementCheck(employeeAge) == true)
            {
                Console.WriteLine("Yes, " + employeeName + " can retire if they wish.\nThey became eligible " + YearsEligible(employeeAge));
            }
            else
            {
                Console.WriteLine("No, " + employeeName + " is not yet eligible to retire. They will become eligible " + YearsLeft(employeeAge));
            }

            Console.WriteLine("Thank you for using Retirement Checker 92000 (tm)");
            
        }
    }
}
