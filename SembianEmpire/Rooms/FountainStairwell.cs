using SembianEmpire.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SembianEmpire.Rooms
{
    public class FountainStairwell : RoomBase
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
                        return "You stand at the base of stairwell.";
                    }

                case Directions.North:
                    if (Globals.Instance.FountainStairwell_CandlesLit)
                    {
                        return "To the north you see a dimly lit hallway.";
                    }
                    break;


                case Directions.Up:
                    return "A stairwell leads up into the daylight";
            }

            return base.GetLookText(direction);
        }

        public override string GetConnectedRoom(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    return nameof(MarbleFountain);
                case Directions.North:
                    return nameof(MossyHall1);
            }

            return base.GetConnectedRoom(direction);
        }

    }
}
