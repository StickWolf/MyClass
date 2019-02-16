using System;
using System.Collections.Generic;
using System.Linq;
using wolf_project.ProgrammingTests;
using System.Text;
using System.Threading.Tasks;
using SoundUtils;

namespace wolf_project.Creatures
{
    public abstract class Creature
    {
        public int Hp { get; private set; }
        public string Name { get; private set; }
        private int Strength;
        private CreatureWeapon Weapon;

        public Creature(int hit, string profile, int power, CreatureWeapon threaten)
        {
            Hp = hit;
            Strength = power;
            Name = profile;
            Weapon = threaten;
        }

        //public void PrintDetails()
        //{
        //    //int[] foo = new int[] { 1, 5, 34, 72, 77 };

        //    //foreach(int x in foo)
        //    //{
        //    //    Console.WriteLine(x.ToString());
        //    //}

        //    Console.WriteLine($"Approch: name  IS {Name}. IT HAS {Hp} HP.");
        //    Console.WriteLine($"SPECIES IS {this.GetType().Name}");
        //    ABunchaSounds.CreatureIntroBeeps();
        //}

        //public bool IsDead()
        //{
        //    return Hp == 0;
        //}

        //public void Hit(Creature attackingCreature)
        //{
        //    int attackDamage = attackingCreature.GetAttackDamage();
        //    Console.WriteLine($"{attackingCreature.Name} is attacking {Name} with {Weapon}!");
        //    Hit(attackDamage);
        //}

        //public void Hit(int damage)
        //{
        //    if ((Hp - damage) <= 0)
        //    {
        //        Hp = 0;
        //        Console.WriteLine($"{Name} is dead. ");
        //        ABunchaSounds.CreatureVictoryBeeps();              
        //    }

        //    else
        //    {
        //        Hp -= damage;
        //        Console.WriteLine($"{Name} is damaged! it has {Hp} hp left!");
        //        ABunchaSounds.CreatureAttackBeeps();
        //    }
        //    if (Hp != 0)
        //    {
        //        ShowSound();        
        //    }
        //}

        public int GetAttackDamage()
        {
            return Strength;
        }

        protected virtual void ShowSound()
        {
            Console.WriteLine("aag!");
        }
    }
}
    


























































































































































