class FibonacciRecursive : IFibonacci
{
    public int GetNthValue(int nthValue)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(nthValue);
        
        if (nthValue == 0)
        {
            return nthValue;
        }
        else if (nthValue == 1)
        {
            return nthValue;
        }

        return GetNthValue(nthValue - 1) + GetNthValue(nthValue - 2);

    }
}