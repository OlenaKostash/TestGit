using System;
using System.Net.Security;


namespace TestProject
{
    public enum SortAlgorithmType
    {
        Selection,
        Bubble,
        Insertion
    }

    public enum OrderBy
    { 
        Asc,
        Desc
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 10, 14, 4, 12, 53 };
            Console.WriteLine("array before sort:");
            PrintArray(array);

            var sortOrder = default(OrderBy);
            Console.WriteLine("select a sorting direction: -a (Ascending order) or -d (Descending order)");
            var inputString = Console.ReadLine();
            if(inputString == "-a")
                sortOrder = OrderBy.Asc;
            else if (inputString == "-d")
                sortOrder = OrderBy.Desc;
            else
                Console.WriteLine("incorrect sorting parameter, array will be sort by Ascending order");

            var array1 = CopyArray(array);
            Console.WriteLine("array sort Selection:");
            Sort(array1, SortAlgorithmType.Selection, sortOrder);
            PrintArray(array1);

            var array2 = CopyArray(array);
            Console.WriteLine("array sort Bubble:");
            Sort(array2, SortAlgorithmType.Bubble, sortOrder);
            PrintArray(array2);

            var array3 = CopyArray(array);
            Console.WriteLine("array sort Insertion:");
            Sort(array3, SortAlgorithmType.Insertion, sortOrder);
            PrintArray(array3);

            Console.ReadKey();
        }

        public static void Sort(int[] array, SortAlgorithmType algorithm, OrderBy sortOrder)
        { 
            switch(algorithm)
            {
                case SortAlgorithmType.Selection:
                    SelectionSort(array, sortOrder);
                    break;
                case SortAlgorithmType.Bubble:
                    BubbleSort(array, sortOrder);
                    break;
                case SortAlgorithmType.Insertion:
                    InsertionSort(array, sortOrder);
                    break;
            }
        }

        public static void PrintArray(int[] array)
        {
            foreach (int item in array)
                Console.WriteLine(item);
        }

        private static int[] CopyArray(int[] array) 
        {
            var arrayLength = array.Length;
            int[] copyArray = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
                copyArray[i] = array[i];

            return copyArray;
        }
        private static void SelectionSort(int[] array, OrderBy sortOrder)
        {
            var arrayLength = array.Length;
            for (int i = 0; i < arrayLength - 1; i++)
            {
                var index = i;
                for (int j = i + 1; j < arrayLength; j++)
                {
                    if(sortOrder == OrderBy.Asc)
                    {
                        if (array[j] < array[index])
                            index = j;
                    }
                    else
                    {
                        if (array[j] > array[index])
                            index = j;
                    }      
                }
                var tempVar = array[index];
                array[index] = array[i];
                array[i] = tempVar;
            }
        }
        private static void BubbleSort(int[] array, OrderBy sortOrder)
        {
            int temp = 0;
            var arrayLength = array.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = 0; j < arrayLength - 1; j++)
                {
                    if (sortOrder == OrderBy.Asc)
                    { if (array[j] > array[j + 1])
                        {
                            temp = array[j + 1];
                            array[j + 1] = array[j];
                            array[j] = temp;
                        }
                    }
                    else
                    {
                        if (array[j] < array[j + 1])
                        {
                            temp = array[j + 1];
                            array[j + 1] = array[j];
                            array[j] = temp;
                        }
                    }
                }     
            }
        }
        private static void InsertionSort(int[] array, OrderBy sortOrder)
        {
            var arrayLength = array.Length;
            int key, j;
            for (int i = 1; i < arrayLength; i++)
            {
                key = array[i];
                j = i - 1;

                if (sortOrder == OrderBy.Asc)
                {
                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }
                }
                else
                {
                    while (j >= 0 && array[j] < key)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }
                }
                
                array[j + 1] = key;
            }
        }
    }
       
}
 
