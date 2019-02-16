using SembianEmpire.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SembianEmpire.Rooms
{
    public class MossyHall3 : RoomBase
    {
        protected override string GetLookText(Directions direction)
        {
            switch (direction)
            {
                case Directions.Here:
                    if (!Globals.Instance.FountainStairwell_CandlesLit)
                    {
                        return string.Join(Environment.NewLine, new[] {
                            "You stand in darkness.",
                        });
                    }
                    else
                    {
                        return string.Join(Environment.NewLine, new[] {
                            "You stand in a dimly lit hallway. Water seeps through the walls and the floor is damp.",
                            "The walls are covered with moss here."
                        });
                    }

                case Directions.East:
                    if (Globals.Instance.FountainStairwell_CandlesLit)
                    {
                        return "To the east you see a dimly lit hallway.";
                    }
                    break;

                case Directions.North:
                    if (Globals.Instance.FountainStairwell_CandlesLit)
                    {
                        return "To the north you see a dimly lit hallway.";
                    }
                    break;
            }

            return base.GetLookText(direction);
        }

        public override string GetConnectedRoom(Directions direction)
        {
            switch (direction)
            {
                case Directions.East:
                    return nameof(FountainStairwell);
                case Directions.North:
                    return nameof(MossyHall2);

            }

            return base.GetConnectedRoom(direction);
        }

    }
}
