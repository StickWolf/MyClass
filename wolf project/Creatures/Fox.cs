using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wolf_project.ProgrammingTests;

namespace wolf_project.Creatures
{
    public class Fox : Creature
    {
        public Fox(int hit, string profile, int power, CreatureWeapon threaten)
            : base(hit, profile, power, threaten)
        {
        }

        protected override void ShowSound()
        {
            Console.WriteLine("Yelp!");
        }

        public void WhatDasTheFoxSay()
        {
            Console.WriteLine("the fox das not say");
            base.ShowSound();
            Console.WriteLine("but the fox das say");
            this.ShowSound();
        }
    }
}
