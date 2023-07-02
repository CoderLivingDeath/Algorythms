using System.Collections.Generic;
using System.Diagnostics;
using AlgorythmsSort;
using AlgorythmsSerch;
public class Program
{
    public static void Main(string[] args)
    {


        for (int i = 1; i <= 8; i++)
        {
            var sizeScale = (int)Math.Pow(10, i);
            SearchsSpeedTest(sizeScale);
        }
    }

    public static void SearchsSpeedTest(int size)
    {
        Console.WriteLine("===========================");
        Console.WriteLine("===>  Search speed test. <===");
        Console.WriteLine("ArraySize: " + size.ToString());
        Console.WriteLine();
        var time = 0L;

        time = SearchSpeedTest((x, y) =>
        {
            var num = Search.BinarySearch(x, y, 0, x.Length - 1);
            if (num == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }, size, SearchTestType.last, true);
        Console.Write("BinarySearch(LastIndex): ");
        Console.WriteLine(time);
        time = SearchSpeedTest((x, y) =>
        {
            var num = Search.BinarySearch(x, y, 0, x.Length - 1);
            if (num == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }, size, SearchTestType.midle, true);
        Console.Write("BinarySearch(MiddleIndex): ");
        Console.WriteLine(time);
        time = SearchSpeedTest((x, y) =>
        {
            var num = Search.BinarySearch(x, y, 0, x.Length - 1);
            if (num == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }, size, SearchTestType.first,true);
        Console.Write("BinarySearch(FirstIndex): ");
        Console.WriteLine(time);

        Console.WriteLine();
        //----------------------------------------------------------------------------
        time = SearchSpeedTest((x, y) =>
        {
            var num = Search.LinearSearch(x, y);
            if (num == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }, size, SearchTestType.last);
        Console.Write("LinearSearch(LastIndex): ");
        Console.WriteLine(time);
        time = SearchSpeedTest((x, y) =>
        {
            var num = Search.LinearSearch(x, y);
            if (num == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }, size, SearchTestType.midle);
        Console.Write("LinearSearch(MiddleIndex): ");
        Console.WriteLine(time);
        time = SearchSpeedTest((x, y) =>
        {
            var num = Search.LinearSearch(x, y);
            if (num == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }, size, SearchTestType.first);
        Console.Write("LinearSearch(FirstIndex): ");
        Console.WriteLine(time);

        Console.WriteLine("---------------------------^");
    }

    public static void SortsSpeedTest(int size)
    {
        Console.WriteLine("===========================");
        Console.WriteLine("===>  Sort speed test. <===");
        Console.WriteLine("ArraySize: " + size.ToString());
        Console.WriteLine();
        var time = 0L;

        time = SpeedTestSort((x) => Sort.QuickSort(x, 0, x.Length - 1), size, out var sortedArray);
        Console.Write("QuickSort: ");
        Console.WriteLine(time);

        time = SpeedTestSort(Sort.InsertionSort, size, out var sortedArray2);
        Console.Write("InsertionSort: ");
        Console.WriteLine(time);

        time = SpeedTestSort(Sort.BubbleSort, size, out var sortedArray1);
        Console.Write("BubbleSort: ");
        Console.WriteLine(time);
        Console.WriteLine("---------------------------^");
    }

    public static long SearchSpeedTest(Func<int[], int, bool> searchMenthod, int size, SearchTestType typeTest, bool sorting = false)
    {
        List<int> array = GetRandomArray(size).ToList();

        var rnd = new Random();
        var num = rnd.Next();

        switch (typeTest)
        {
            case SearchTestType.first:
                array.Insert(0, num);
                break;
            case SearchTestType.last:
                array.Insert(array.Count, num);
                break;
            case SearchTestType.midle:
                array.Insert((array.Count()) / 2, num);
                break;
        }
        if (sorting)
        {
            array.Sort();
        }

        return SpeedTestMethod(() =>
        {
            if(!searchMenthod(array.ToArray(), num))
            {
                Console.WriteLine("===Bug===Bug===Bug===Bug===Bug===Bug===Bug===Bug===Bug===Bug===Bug===Bug");
            }
        });
    }

    public enum SearchTestType
    {
        first, midle, last
    }

    public static long SpeedTestMethod(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        action.Invoke();
        stopwatch.Stop();

        return stopwatch.ElapsedMilliseconds;
    }

    public static long SpeedTestSort(Func<int[], int[]> sortMenthod, int size, out int[] sortedArray)
    {
        var NonSortedArray = GetRandomArray(size).ToArray();
        int[] temp = { -1 };
        var time = SpeedTestMethod(() => temp = sortMenthod(NonSortedArray));

        sortedArray = temp;
        return time;
    }

    public static IEnumerable<int> GetRandomArray(int size)
    {
        Random rnd = new Random();

        for (int i = 0; i < size; i++)
        {
            yield return rnd.Next();
        }
    }

}

