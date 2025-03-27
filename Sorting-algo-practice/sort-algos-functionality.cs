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
        int[] sorted = {};
        return sorted;
    }

    public int[] InsertSort(int[] arr)
    {
        int[] sorted = {};
        return sorted;
    }
}