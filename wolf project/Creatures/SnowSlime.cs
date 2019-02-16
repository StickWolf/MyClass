using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wolf_project.ProgrammingTests;

namespace wolf_project.Creatures
{
    class SnowSlime : Creature
    {
        public SnowSlime(int hit, string profile, int power, CreatureWeapon threaten)
            : base(hit, profile,  power, threaten)
        {
        }
    }
}
