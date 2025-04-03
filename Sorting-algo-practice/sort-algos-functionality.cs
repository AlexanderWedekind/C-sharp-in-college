namespace sortAlgosFunctionality;

using sortAlgoPractice;

class SortAlgos
{
    delegate string ShowArray(int[] arr);
    ShowArray showArray = sortAlgoPractice.Program.BuildStringRepresentationOfArray;
    public int[] BubbleSort(int[] arr)
    {
        int[] unsorted = arr;
        bool changed = false;
        int num;
        do
        {
            changed = false;
            for(int i = 0; i < unsorted.Length - 1; i++)
            {
                num = unsorted[i];
                if(unsorted[i] > unsorted[i+1])
                {
                    unsorted[i] = unsorted[i+1];
                    unsorted[i+1] = num;
                    changed = true;    
                }
            }
        }
        while(changed);
        
        return unsorted;
    }

    public int[] SelectionSort(int[] arr)
    {
        int[] unsorted = arr;
        int min;
        int index = 0;
        int num;
        for(int i = 0; i < unsorted.Length; i++)
        {
            min = unsorted[i];
            for(int j = i+1; j < unsorted.Length; j++)
            {
                if(unsorted[j] < min)
                {
                    index = j;
                    min = unsorted[j];
                }
            }
            if(min < unsorted[i])
            {
                num = unsorted[i];
                unsorted[i] = min;
                unsorted[index] = num;
            }
        }
        return unsorted;
    }

    public int[] InsertSort(int[] arr)
    {
        int[] unsorted = arr;
        int num;
        //int index = 0;
        // bool swapped = false;
        for(int i = 1; i < unsorted.Length; i++)
        {
            for(int j = 0; j < i; j++)
            {
                if(unsorted[i] < unsorted[j])
                {
                    num = unsorted[j];
                    //index = j;
                    unsorted[j] = unsorted[i];
                    unsorted[i] = num;
                    //swapped = true;
                }
                // if(swapped)
                // {
                //     break;
                // }
            }
        }
        return unsorted;
    }

    public int[] MergeSort(int[] arr)
    {
        //Console.WriteLine($"mergesort: {showArray(arr)}");
        if(arr.Length < 2)
        {
            return arr;
        }

        List<int> finished = new List<int>();
        int halfway;
        List<int> left = new List<int>();
        List<int> right = new List<int>();

        //Console.WriteLine($"arr length: {arr.Length}");
        if(arr.Length % 2 == 0)
        {
            halfway = (arr.Length / 2) - 1;
        }
        else
        {
            halfway = arr.Length / 2;
        }
        //Console.WriteLine($"halfway: {halfway}");
        for(int i = 0; i < arr.Length; i++)
        {
            if(i <= halfway)
            {
                left.Add(arr[i]);
            }
            else
            {
                right.Add(arr[i]);
            }
        }
        //Console.WriteLine($"left: {showArray(left.ToArray())}\nright: {showArray(right.ToArray())}");

        int[] leftUp = MergeSort(left.ToArray());
        int[] rightUp = MergeSort(right.ToArray());

        int lindex = 0;
        int rindex = 0;

        for(int i = 0; i < leftUp.Length + rightUp.Length; i++)
        {
            if(lindex < leftUp.Length && rindex < rightUp.Length)
            {
                if(leftUp[lindex] < rightUp[rindex])
                {
                    finished.Add(leftUp[lindex]);
                    lindex++;
                }
                else if(leftUp[lindex] > rightUp[rindex])
                {
                    finished.Add(rightUp[rindex]);
                    rindex++;
                }
                else if(leftUp[lindex] == rightUp[rindex])
                {
                    finished.Add(leftUp[lindex]);
                    lindex++;
                    finished.Add(rightUp[rindex]);
                    rindex++;
                }
            }
            else if(lindex >= leftUp.Length)
            {
                while(rindex < rightUp.Length)
                {
                    finished.Add(rightUp[rindex]);
                    rindex++;
                }
            }
            else if(rindex >= rightUp.Length)
            {
                while(lindex < leftUp.Length)
                {
                    finished.Add(leftUp[lindex]);
                    lindex++;
                }
            }
        }

        return finished.ToArray();
    }

    public int[] QuickSort(int[] arr)
    {
            List<int> leftOntheWayDown = new List<int>();
            int[] leftOnTheWayUp;
            int pivot;
            List<int> rightOnTheWayDown = new List<int>();
            int[] rightOnTheWayUp;
            List<int> finished = new List<int>();
            
            if(arr.Length < 2)
            {
                return arr;
            }

            pivot = arr[0];

            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] <= pivot)
                {
                    leftOntheWayDown.Add(arr[i]);
                }
                else
                {
                    rightOnTheWayDown.Add(arr[i]);
                }
            }

            if(leftOntheWayDown.Count > 0)
            {
                leftOnTheWayUp = QuickSort(leftOntheWayDown.ToArray());
                foreach(int num in leftOnTheWayUp)
                {
                    finished.Add(num);
                }
            }
            
            finished.Add(pivot);

            if(rightOnTheWayDown.Count > 0)
            {
                rightOnTheWayUp = QuickSort(rightOnTheWayDown.ToArray());
                foreach(int num in rightOnTheWayUp)
                {
                    finished.Add(num);
                }
            }

            return finished.ToArray();
    }
}