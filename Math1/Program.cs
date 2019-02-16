using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Smart();
            Console.ReadLine();
        }

        private static void Smart()
        {
            Console.WriteLine("hello, welcome to the calculator. so you don't get confused, + is equal to plus, - is equal to minus, / is equal to division, and * is equal to multiplication.");

            Console.Write("Enter a Number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Operator:");
            string op = Console.ReadLine();

            Console.Write("Enter a Number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            if (op == "+")
            {
                Console.WriteLine(num1 + num2);
            }
            else if (op == "-")
            {
                Console.WriteLine(num1 - num2);

            }
            else if (op == "/")
            {
                Console.WriteLine(num1 / num2);

            }
            else if (op == "*")
            {
                Console.WriteLine(num1 * num2);
            }
            else
            {
                Console.WriteLine("Invalid Operator");
            }
        }
    }
}
