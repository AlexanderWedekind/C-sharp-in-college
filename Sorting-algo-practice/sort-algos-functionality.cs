namespace sortAlgosFunctionality;

class SortAlgos
{
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
}