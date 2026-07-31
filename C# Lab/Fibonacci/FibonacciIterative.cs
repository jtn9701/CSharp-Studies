class FibonacciIterative : IFibonacci
{
    public int GetNthValue(int nthValue)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(nthValue);
        int currentValue = 0;
        int firstValue = 0;
        int secondValue = 1;


        for (int i = 0; i < nthValue; i++)
        {
            currentValue = firstValue + secondValue;
            secondValue = firstValue;
            firstValue = currentValue;
        }

        return currentValue;
    }
}