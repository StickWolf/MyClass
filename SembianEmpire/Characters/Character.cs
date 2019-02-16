using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SembianEmpire.Characters
{
    public abstract class Character
    {
        public int MaxHitPoints { get; private set; }

        public int HitPoints { get; private set; }

        public string Name { get; private set; }

        public int Strength { get; private set; }

        public Character(string name, int maxHitPoints, int strength)
        {
            Name = name;
            HitPoints = maxHitPoints;
            MaxHitPoints = maxHitPoints;
            Strength = strength;
        }

        /// <summary>
        /// Does the specified amount of damage to the character
        /// </summary>
        /// <param name="damage"></param>
        public virtual void Hit(int damage)
        {
            if ((HitPoints - damage) <= 0)
            {
                HitPoints = 0;
            }
            else
            {
                HitPoints -= damage;
            }
        }

        public virtual bool IsDead()
        {
            return HitPoints == 0;
        }

        public abstract void ProcessCharacterTurn();
    }
}
