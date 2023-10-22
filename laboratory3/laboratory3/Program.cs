using System;

public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                int num = ReadNumber(1, 100);
                Console.WriteLine("Square root of the number is: " + Math.Sqrt(num));
            }
            catch (CustomException cx)
            {
                Console.WriteLine("Custom Exception: " + cx.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("General Exception: " + x.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }

    static int ReadNumber(int start, int end)
    {
        int num;
        Console.Write($"Enter an integer between {start} and {end}: ");
        if (int.TryParse(Console.ReadLine(), out num))
        {
            if (num >= start && num <= end)
            {
                return num;
            }
            else
            {
                throw new CustomException("Invalid number");
            }
        }
        else
        {
            throw new FormatException("Invalid input. Please enter a valid integer.");
        }
    }
}
