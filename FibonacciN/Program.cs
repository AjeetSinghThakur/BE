using System;

namespace FibonacciN
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter Limit:");
            string input = Console.ReadLine();
            int a = 0, b = 1, c;

            if(Int32.TryParse(input, out int n)){
                for (int i = 0; i <= n; i++)
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine("{0}\n", "XXX");
                    }
                    else
                    {
                        Console.WriteLine("{0}\n", a);
                    }
                    c = a + b;
                    a = b;
                    b = c;
                }
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
            Console.ReadKey();
        }
    }
}
