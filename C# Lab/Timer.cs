using System.Diagnostics;
using System.Reflection;

class Timer
{
    public static void TimeFibonacci(string actionName, Stopwatch stopwatch, int nthValue, Func<int,int> function)
    {
        stopwatch.Start();
        function(nthValue);
        stopwatch.Stop();
        Console.WriteLine($"Elapsed Time {actionName}: {stopwatch.ElapsedMilliseconds}ms");
        stopwatch.Reset();
    }

    public static void TimeAllFibonacciActions() 
    {
        Stopwatch stopwatch = new Stopwatch();
        int nthValue = 100;
        List<Func<int, int>> fibonacciActions = new List<Func<int, int>>
        {
            (x) => new FibonacciIterative().GetNthValue(x),
            (x) => new FibonacciRecursive().GetNthValue(x),
            (x) => new FibonacciMemo().GetNthValue(x)
        };

        List<string> actionNames = new List<string>
        {
            "Iterative",
            "Recursive",
            "Memoization"
        };

        foreach ((Func<int, int> action, string actionName) in fibonacciActions.Zip(actionNames))
        {
            Timer.TimeFibonacci(actionName, stopwatch, nthValue, action);
        }
    }
}

