//Fibonacci Sequence – Enter a number and have the program generate the Fibonacci sequence to that number or to the Nth number.
//Max number 18,446,744,073,709,551,615. Cant go higher than 93th place before overflow
using System;
using System.Collections.Generic;

namespace FibonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
           

            int index = -1;
            bool checkedInputs = true;

            while (checkedInputs)
            {
                Console.Clear();
                Console.Write("How many numbers would you like to gerenate:");
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int n);
                if (!isNumber)
                {
                    Console.WriteLine("Not a number");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                index = Convert.ToInt32(input);

                if (index > 93)
                {
                    Console.WriteLine("Too high. Max 93");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                if (index < 0)
                {
                    Console.WriteLine("Invaild number. Try again");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                checkedInputs = false;
            }
            
            List<ulong> fib = GenerateFibSequence(index);
            for (int i =0; i < fib.Count; i++)
            {
                Console.WriteLine(i + ":" + fib[i].ToString("N0"));
            }
        }

        static List<ulong> GenerateFibSequence(int index)
        {
            List<ulong> seq = new List<ulong>();
            seq.Add(0);
            seq.Add(1);
            for (int i = 2; i <= index; i++)
            {
                ulong newNum = seq[i - 1] + seq[i - 2];
                seq.Add(newNum);
            }

            return seq;
        }

        //Not accurate
        static decimal GetSeq(int index)
        {
            decimal num1 = ((Power((decimal)1.618034, index)) - (Power((decimal)1 - (decimal)1.618034f, index))) / ((decimal)MathF.Sqrt(5));
            ulong num = (ulong)num1;
            return num;
        }
        static decimal Power(decimal x, int y)
        {
            decimal num = x;
            for (int i = 1; i < y; i++)
            {
                num *= x;
            }
            return num;
        }
    }
}
