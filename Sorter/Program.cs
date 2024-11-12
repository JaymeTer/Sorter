using System.Diagnostics;

Stopwatch stopwatch = Stopwatch.StartNew();




// I asked chat gpt questions throughout this process and used it as a tutor along with the websites listed below, no code was written by gpt let me know if you need the conversation log.

// usage 100 thousand values
int[] largeArr = GenerateRandomArray(100000, 1, 1000);

// Write your function to test each algorithm here
stopwatch.Start();
Bubblesort(largeArr);
stopwatch.Stop();
Console.WriteLine("Bubblesort");
DisplayRuntime(stopwatch);
stopwatch.Reset();
largeArr = GenerateRandomArray(100000, 1, 1000);
stopwatch.Start();
Mergesort(largeArr, 0, largeArr.Length - 1);
stopwatch.Stop();
Console.WriteLine("Mergesort");
DisplayRuntime(stopwatch);
stopwatch.Reset();
largeArr = GenerateRandomArray(100000, 1, 1000);
stopwatch.Start();
Insertionsort(largeArr);
stopwatch.Stop();
Console.WriteLine("Insertion");
DisplayRuntime(stopwatch);
stopwatch.Reset();
largeArr = GenerateRandomArray(100000, 1, 1000);
stopwatch.Start();
Quicksort(largeArr, 0, largeArr.Length - 1);
stopwatch.Stop();
Console.WriteLine("Quicksort");
DisplayRuntime(stopwatch);
Console.WriteLine("MergeSort and Quicksort are way faster with huge databases based on how they break down and process the numbers!");



// Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)


// Bubble, used  https://code-maze.com/csharp-bubble-sort/ as guideline.

static int[] Bubblesort(int[] largeArr)
{
    int n = largeArr.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (largeArr[j] > largeArr[j + 1])
            {
                int temp = largeArr[j];
                largeArr[j] = largeArr[j + 1];
                largeArr[j + 1] = temp;
            }
        }
    }

    return largeArr;

}//Mergesort used https://code-maze.com/csharp-merge-sort/ as reference
static int[] Mergesort(int[] largeArr, int left, int right)
{
    if (left < right)
    {
        int middle = left + (right - left) / 2;
        Mergesort(largeArr, left, middle);
        Mergesort(largeArr, middle + 1, right);
        MergeArray(largeArr, left, middle, right);
    }

    return largeArr;
}

static void MergeArray(int[] array, int left, int middle, int right)
{
    var leftArrayLength = middle - left + 1;
    var rightArrayLength = right - middle;
    var leftTempArray = new int[leftArrayLength];
    var rightTempArray = new int[rightArrayLength];
    int i, j;
    for (i = 0; i < leftArrayLength; ++i)
        leftTempArray[i] = array[left + i];
    for (j = 0; j < rightArrayLength; ++j)
        rightTempArray[j] = array[middle + 1 + j];
    i = 0;
    j = 0;
    int k = left;
    while (i < leftArrayLength && j < rightArrayLength)
    {
        if (leftTempArray[i] <= rightTempArray[j])
        {
            array[k++] = leftTempArray[i++];
        }
        else
        {
            array[k++] = rightTempArray[j++];
        }
    }
    while (i < leftArrayLength)
    {
        array[k++] = leftTempArray[i++];
    }
    while (j < rightArrayLength)
    {
        array[k++] = rightTempArray[j++];
    }
}

//Insertionsort used https://www.geeksforgeeks.org/insertion-sort-algorithm/ for reference

static void Insertionsort(int[] largeArr)
{
    int n = largeArr.Length;
    for (int i = 1; i < n; ++i)
    {
        int key = largeArr[i];
        int j = i - 1;

        /* Move elements of arr[0..i-1], that are
           greater than key, to one position ahead
           of their current position */
        while (j >= 0 && largeArr[j] > key)
        {
            largeArr[j + 1] = largeArr[j];
            j = j - 1;
        }
        largeArr[j + 1] = key;
    }
}

// Quicksort used https://www.geeksforgeeks.org/quick-sort-algorithm/ as reference.

static int Partition(int[] arr, int low, int high)
{

    // Choose the pivot
    int pivot = arr[high];

    // Index of smaller element and indicates 
    // the right position of pivot found so far
    int i = low - 1;

    // Traverse arr[low..high] and move all smaller
    // elements to the left side. Elements from low to 
    // i are smaller after every iteration
    for (int j = low; j <= high - 1; j++)
    {
        if (arr[j] < pivot)
        {
            i++;
            Swap(arr, i, j);
        }
    }

    // Move pivot after smaller elements and
    // return its position
    Swap(arr, i + 1, high);
    return i + 1;
}

// Swap function
static void Swap(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

// The QuickSort function implementation
static void Quicksort(int[] arr, int low, int high)
{
    if (low < high)
    {

        // pi is the partition return index of pivot
        int pi = Partition(arr, low, high);

        // Recursion calls for smaller elements
        // and greater or equals elements
        Quicksort(arr, low, pi - 1);
        Quicksort(arr, pi + 1, high);
    }
}

static void Main(string[] args)
{
    int[] arr = { 10, 7, 8, 9, 1, 5 };
    int n = arr.Length;

    Quicksort(arr, 0, n - 1);
    foreach (int val in arr)
    {
        Console.Write(val + " ");
    }
}

// function
static int[] GenerateRandomArray(int length, int minValue, int maxValue)
{
    Random rand = new Random();
    int[] array = new int[length];

    for (int i = 0; i < length; i++)
    {
        array[i] = rand.Next(minValue, maxValue); // Generates a random integer within the specified range
    }

    return array;
}

static void DisplayRuntime(Stopwatch stopwatch)
{
    TimeSpan ts = stopwatch.Elapsed;

    // Format and display the TimeSpan value.
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine(elapsedTime);
}
