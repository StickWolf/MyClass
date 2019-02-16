using SembianEmpire.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SembianEmpire.Rooms
{
    public class MossyHall1 : RoomBase
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

                case Directions.South:
                    if (Globals.Instance.FountainStairwell_CandlesLit)
                    {
                        return "To the south you see a stairwell lit with candles.";
                    }
                    break;

                case Directions.West:
                    if (Globals.Instance.FountainStairwell_CandlesLit)
                    {
                        return "To the west the hallway continues.";
                    }
                    break;
            }

            return base.GetLookText(direction);
        }

        public override string GetConnectedRoom(Directions direction)
        {
            switch (direction)
            {
                case Directions.South:
                    return nameof(FountainStairwell);
                case Directions.West:
                    return nameof(MossyHall2);
            }

            return base.GetConnectedRoom(direction);
        }

    }
}
