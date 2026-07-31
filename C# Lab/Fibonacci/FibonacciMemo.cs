class FibonacciMemo : IFibonacci
{

    private Dictionary<int, int> memo;
    public FibonacciMemo()
    {
        this.memo = memo = new Dictionary<int, int>();
    }

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

        if (!memo.ContainsKey(nthValue))
        { 
            memo.Add(
                nthValue, 
                GetNthValue(nthValue - 1) + GetNthValue(nthValue - 2));
        }

        return memo[nthValue];

    }
}