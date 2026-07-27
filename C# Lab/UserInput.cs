class UserInput
{
    public static string GetUserName()
    {
        string? userName;

        do
        {
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(userName));

        return userName.Trim();
            
    }

    public static int GetUserAge()
    {
        int userAge;
        bool isValid;

        do
        {
            Console.WriteLine("What is your age?");
            isValid = int.TryParse(Console.ReadLine(), out userAge) && userAge is >= 0 and <= 120;

            if (!isValid)
            {
                Console.WriteLine("Please enter a valid age");
            }

        } while (!isValid);

        return userAge;
    }

    public static void WriteGreeting(string name, int age)
    {
        Console.WriteLine($"Hi, {name}! Your age is {age}.");
    }
}
