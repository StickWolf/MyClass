using System.Collections.Generic;

namespace SembianEmpire
{
    public class Globals
    {
        private static Globals instance;
        public static Globals Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Globals();
                }
                return instance;
            }
        }

        public static List<Directions> AllDirections = new List<Directions>()
        {
            Directions.Here,
            Directions.East,
            Directions.North,
            Directions.South,
            Directions.West,
            Directions.Up,
            Directions.Down
        };

        public bool MarbleFountain_LeverSwitched = false;

        public bool FountainStairwell_CandlesLit = false;

        public static void Init()
        {
            instance = null;
        }
    }
}
