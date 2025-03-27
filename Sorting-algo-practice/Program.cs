﻿namespace sortAlgoPractice;

using sortAlgosFunctionality;

class Program
{
    static SortAlgos sortAlgos = new SortAlgos();
    static string algoChoice ="Choose your sorting algorithm:\n\n[1] Bubble Sort\n[2] Selection Sort\n[3] Insert Sort\n\n(use number keys to make your choice, then press ENTER)\n";
    static string arrChoice = $"Do you want to:\n[1] use the preset array : {{ {unsortedArray} }}?\n[2] make your own array\n(use number keys to make your choice, then press ENTER)";
    static int[] unsortedArray = {3,6,2,7,1,4,8,5};
    static int[] sortedArray;

    static int[] BuildArray()
    {
        int[] userChosenArr = {};
        Console.WriteLine();
        return userChosenArr;
    }

    static int Menu(int nrOfChoices, string message)
    {
        int userInput;
        Console.WriteLine(message);
        do
        {
            if(Int32.TryParse(Console.ReadLine(), out int result))
            {
                userInput = result;
                if(userInput > 0 && userInput < nrOfChoices)
                {

                    return userInput;
                }
                else
                {
                    Console.WriteLine("That wasn't one of the available choices.\nChoose again, and try to stay withing the range of choices offered.");
                }
            }
            else
            {
                Console.WriteLine("Oops! That wasn't the correct format.\nUse only the number keys on your keyboard to make your choice, then press ENTER.");
            }
        }
        while(true);
        return userInput;
    }

    public static void Main()
    {
        Console.WriteLine("we're sorting arrays today.");
        int choice = Menu(3, algoChoice);
        switch(choice)
        {
            case 1:
                sortedArray = sortAlgos.BubbleSort(unsortedArray);
                break;
            case 2:
                sortedArray = sortAlgos.SelectionSort(unsortedArray);
                break;
            case 3:
                sortedArray = sortAlgos.InsertSort(unsortedArray);
                break;
        }
        Console.WriteLine($"The sorted array is: {{ {(string() => {string arrStr = ""; foreach(int num in sortedArray){if(arrStr.Length > 0){arrStr += ", ";}arrStr+=num;} return arrStr;})} }}");
    }
}