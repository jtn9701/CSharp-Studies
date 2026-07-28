using System.Linq.Expressions;

class Fibonacci
{
    public static int GetNthValueIteratively(int nthNumber)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(nthNumber);
        int currentValue = 0;
        int firstValue = 0;
        int secondValue = 1;


        for (int i = 0; i < nthNumber; i++)
        {
            currentValue = firstValue + secondValue;
            secondValue = firstValue;
            firstValue = currentValue;
        }

        return currentValue;
    }

    public static void PrintFibonnaciSeries(int nthTerm)
    {
        for (int i = 0; i < nthTerm; i++)
        {
            Console.WriteLine(GetNthValueIteratively(i));
        }
    }
        

}
