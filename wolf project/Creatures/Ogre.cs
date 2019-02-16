﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wolf_project.ProgrammingTests;

namespace wolf_project.Creatures
{
    class Ogre : Creature
    {
        public Ogre(int hit, string profile, int power, CreatureWeapon threaten)
            : base(hit, profile, power, threaten)
        {
        }

        protected override void ShowSound()
        {
            Console.WriteLine("Arrgh!");
        }
    }
}
