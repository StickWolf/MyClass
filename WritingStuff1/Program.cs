using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingStuff
{
    public class Program
    {
        private static void Main()
        {
            Arrays();
            Tests();
            example2();
            MyMath();
            Tests();
            Mumbo();
            
            Console.ReadLine();
        }

        private static void Arrays()
        {
            int[] intRay = { 9, 72, 2, 150 };
            //Console.WriteLine(intRay[1]);

            string[] sitRay = { " mango", " ice cream", "I like" };
            Console.Write(sitRay[2]);
            Console.Write(sitRay[0]);
            Console.Write(sitRay[1]);
        }

        private static void Tests()
        {
            int answer = DoMathStuff(5, 6);
            int answer2 = DoMathStuff(7, 3);
            Console.WriteLine(
                (answer == 30 && answer2 == 21)
                ? "Correct" : "Wrong!"
                );
            return;
        }

        private static int DoMathStuff(int stuff1, int stuff2)
        {
            return stuff1 * stuff2;
        }

        private static string StringManipulator(string w1, string w2, string w3)
        {
            string answer = "I like " + w1 + " " + w2 + " with " + w3 + " ice cream.";
            answer = answer.Replace("Banana", "Turkey");
            answer = answer.Replace("Purple", "Flavorful");
            return answer;
        }

        private static void example2()
        {
            int answer = 5 + 7;
            int answer2 = MyMath();
            int answer3 = MyMathA(5, 7);

            Console.WriteLine(answer);
        }

        private static int MyMath()
        {
            return 5 + 7;
        }

        private static int MyMathA(int a, int b)
        {
            return a + b;
        }

        public void Test()
        {
            // Orange = Orange
            // Banana = Turkey
            // Purple = Flavorful

            string answer1 = StringManipulator("Orange", "Banana", "Purple");
            string answer2 = StringManipulator("SmokeyPurpleHaze", "Gorilla", "YellowBananaSurprise");

            if (answer1 == "I like Orange Turkey with Flavorful ice cream.")
            {
                Console.WriteLine("Answer 1 is correct!");
            }
            else
            {
                Console.WriteLine($"Answer 1 is not correct. You got: {answer1}");
            }

            if (answer2 == "I like SmokeyFlavorfulHaze Gorilla with YellowTurkeySurprise ice cream.")
            {
                Console.WriteLine("Answer 2 is correct!");
            }
            else
            {
                Console.WriteLine($"Answer 2 is not correct. You got: {answer2}");
            }
        }

        public static void Mumbo()
        {
            bool result1 = TestIt(true, true, true);
            bool result2 = TestIt(true, false, true);
            bool result3 = TestIt(false, false, false);

            // result1 == true
            // result2 == false
            // result3 == true

            if (result1 && result3 == result1 && !result2)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Try again!");
            }
        }

        public static bool TestIt(bool s1, bool s2, bool s3)
        {
            //bool result = (s1 == s2) == s3;
            //1    true == s3      True
            //2    false == true     (false)
            //3    true == false     (false)

            return s1 == s2 && s2 == s3;

            //return result;
        }
    }
}
