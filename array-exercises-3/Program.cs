

namespace arrayExarcises3
{
    class Program
    {
        static int[] numbers = {15, 23, 6, 67, 13, 15, 12, 99, 67, 45, 22, 67, 96, 2, 85, 15};
        static int target = 0;
        static int count = 0;
        static string typeNumPlusEnterInstructions = "(type a number, then press ENTER)";

        public static int retrieveUserTargetChoice()
        {
            int choice = 0;

            Console.WriteLine("To see how many times a number occurs in our array, first please choose a number to search for.\nThe range you can choose from is from 1 to 99.\n" + typeNumPlusEnterInstructions);

            do
            {
                try
                {
                    choice = Int32.Parse(Console.ReadLine());

                    if(choice < 1 || choice > 99)
                    {
                        Console.WriteLine("That choice wasn't within the range of available choices.\nPlease choose again, and stay within the range from 1 to 99." + typeNumPlusEnterInstructions);
                        choice = 0;
                    }
                    
                }
                catch
                {
                    Console.WriteLine("That was not in the correct format! To choose a number, use the number keys on your keyboard.\n(type your choice, then press ENTER)");
                    choice = 0;
                }
            }
            while(choice == 0);
            Console.WriteLine($"Thank you, we will count the number of occurences of ' {choice} ',  your chosen number.");
            return choice;
        }

        static int FindMax(int[] numbers)
        {
            int max = numbers[0];

            foreach(int num in numbers)
            {
                if(num > max)
                {
                    max = num;
                }
            }
            return max;
        }
        
        static int FindMin(int[] numbers)
        {
            int min = numbers[0];

            foreach(int num in numbers)
            {
                if(num < min)
                {
                    min = num;
                }
            }
            return min;
        }

        static int CountOccurences(int[] numbers, int target)
        {
            int count = 0;

            foreach(int num in numbers)
            {
                if(num == target)
                {
                    count ++;
                }
            }
            return count;
        }
        public static void Main()
        {
            Console.WriteLine("Hello there!");
            target = retrieveUserTargetChoice();
            Console.WriteLine($"The largest number in the array is: {FindMax(numbers)}");
            Console.WriteLine($"The smallest number in the array is: {FindMin(numbers)}");
            Console.WriteLine($"Your chosen number ' {target} ' occurs a total of {CountOccurences(numbers, target)} times in the array.");
            Console.WriteLine("\nThank you for using the application.");
        }
    }
}