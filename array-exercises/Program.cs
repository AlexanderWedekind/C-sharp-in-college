using System;

namespace arrayExercises
{
    class Program
    {
        public static string intOrfloatChoiceInstructions = "(type \"1\" for whole numbers, or \"2\" for floating points, then press ENTER)";
        public static string intChoiceInstructions = "(type your choice using the number keys, then press ENTER)";
        //public static string floatchoiceInstructions = "(type your choice using the number keys and the . on your keyboard, \neg: \" 3.5 \", or \" 2.4 \" , then press ENTER)";
        public static string numberChoiceInstructions()
        {
            string instructions = "";
            if(intOrFloat == 1)
            {
                instructions = "(choose using the number keys on your keyboard, then press ENTER)";
            }
            if(intOrFloat == 2)
            {
                instructions = "(choose using the number keys and the . key, eg: '3.1' or '5.7', then press ENTER)";
            }
            return instructions;
        }
        public static int count = 1;
        public static int howMany = 0;
        public static string numAppend = "";
        public static int intOrFloat = 0;

        public static void Main()
        {

            Console.WriteLine($"We'll work with a series of numbers of your choosing.\nDo you want to use whole numbers only, or are you happy to include floating point numbers (eg: 5.8 or 1.3)?\n(type \"1\" for whole numbers, or \"2\" for floating points, then press ENTER)");
            do
            {
                try
                {
                    intOrFloat = Int32.Parse(Console.ReadLine());
                }
                catch(Exception exception)
                {
                    Console.WriteLine($"Use the number keys to make a choice\n{intOrfloatChoiceInstructions}");
                }
                if(intOrFloat < 1 || intOrFloat > 2)
                {
                    Console.WriteLine($"That wasn't one of the available options! Please stick to the range of choices.\n{intOrfloatChoiceInstructions}");
                    intOrFloat = 0;
                }
            }
            while(intOrFloat == 0);
            
            Console.WriteLine("How many numbers do you want to work with?\n(choose using number keys, then press ENTER)");

            do
            {
                try
                {
                    howMany = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine($"Oops, not the correct format.\n{intChoiceInstructions}");
                }
            }
            while(howMany < 1);

            int[] userChosenNumbers = new int[howMany];

            Console.WriteLine("Thank you. ");
            do
            {
                switch(count < 10)
                {
                    case true:
                        switch(count)
                        {
                            case 1:
                                numAppend = "st";
                                break;
                            case 2:
                                numAppend = "nd";
                                break;
                            case 3:
                                numAppend = "rd";
                                break;
                            default:
                                numAppend = "th";
                                break;
                        }
                        break;
                    case false:
                        switch(count % 10)
                        {
                            case 0:
                                numAppend = "th";
                                break;
                            case 1:
                                numAppend = "st";
                                break;
                            case 2:
                                numAppend = "nd";
                                break;
                            case 3:
                                numAppend = "rd";
                                break;
                            case 4:
                                numAppend = "th";
                                break;
                            case 5:
                                numAppend = "th";
                                break;
                        }

                        break;
                }
                
                if(count > 100)
                {
                    if(count % 100 == 11)
                    {
                        numAppend = "th";
                    }
                }

                try
                {
                    Console.WriteLine($"Choose your {count}{numAppend} number.\n{numberChoiceInstructions()}");
                    userChosenNumbers[count - 1] = Int32.Parse(Console.ReadLine());
                    count += 1;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Whoops! Couldn't read that, it wasn't the correct format.");
                }
            }
            while(count <= userChosenNumbers.Length);

            Console.WriteLine("Your Array of chose numbers: ");
            for(int i = 0; i < userChosenNumbers.Length; i++)
            {
                if(userChosenNumbers.Length == 1)
                {
                    Console.Write($"{{ {userChosenNumbers[0]}}}");
                }
                else
                {
                    if(i == userChosenNumbers.Length - 1)
                    {
                        Console.Write($" , {userChosenNumbers[i]} }}");
                    }
                    else if(i == 0)
                    {
                        Console.Write($"{{ {userChosenNumbers[i]}");
                    }
                    else
                    {
                        Console.Write($" , {userChosenNumbers[i]}");
                    }
                }
            }
        }
    }
}