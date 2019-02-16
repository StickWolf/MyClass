using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterDict
{
    class Monster
    {
        private string info;
        private int care;

        public Monster(string info, int care)
        {
            this.info = info;
            this.care = care;
        }

        static void Main(string[] args)
        {
            SomeMethod();
            Console.ReadLine();
        }

        static void SomeMethod()
        {
            Dictionary<string, Monster> MonsterDict = new Dictionary<string, Monster>();
            Console.WriteLine("type in add, list, show, or end");
            string answer;
            int c = 0;
            while (c < 100)
            {
                answer = Console.ReadLine();
                if (answer == "add")
                {
                    string Info;
                    int Care;
                    Console.Write("Your making a new Monster! Enter a name:");
                    Info = Console.ReadLine();
                    Console.Write($"Now enter the health amount for {Info}!");
                    Care = int.Parse(Console.ReadLine());
                    var qx = new Monster(Info, Care);
                    MonsterDict.Add(Info, qx);
                    Console.WriteLine($"{Info} is now added to your collection of monsters");
                }
                else if (answer == "list")
                {
                    foreach (var creature in MonsterDict.Values)
                    {
                        creature.DisplayStats();
                    }
                }
                else if (answer == "show")
                {
                    answer = answer.Remove(0, 5);
                    if (MonsterDict.ContainsKey(answer))
                    {
                        MonsterDict[answer].DisplayStats();
                    }
                    else
                    {
                        Console.WriteLine($"{answer} is not available");
                    }
                }
                else if (answer == "end")
                {
                    break;
                }
                else
                {
                   
                }

            }
        }

        private void DisplayStats()
        {

        }
    }
}
