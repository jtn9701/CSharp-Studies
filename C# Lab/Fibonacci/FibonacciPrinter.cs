class FibonacciPrinter
{
    public static void PrintFibonnaciSeries(int nthTerm, IFibonacci fibonacciCalculator)
    {
        for (int i = 0; i < nthTerm; i++)
        {
            Console.WriteLine(fibonacciCalculator.GetNthValue(i));
        }
    }
}