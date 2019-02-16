using System;
using System.Collections.Generic;

namespace SembianEmpire.Rooms
{
    public class ForestGlaze : RoomBase
    {
        protected override string GetLookText(Directions direction)
        {
            switch (direction)
            {
                case Directions.Here:
                    return "You find yourself in a lush forest glaze full of vibrant green plants.";
                case Directions.North:
                    return string.Join(Environment.NewLine, new [] {
                        "A path extends through the forest to the north",
                        "Allthough it appears as though nobody has travelled along it for several years."
                    });
                case Directions.West:
                    return "Beyond a shallow pond to your west lies an old broken fountain.";
            }

            return base.GetLookText(direction);
        }

        public override string GetConnectedRoom(Directions direction)
        {
            switch (direction)
            {
                case Directions.North:
                    return nameof(ForestPath);
                case Directions.West:
                    return nameof(MarbleFountain);
            }

            return base.GetConnectedRoom(direction);
        }

    }
}
