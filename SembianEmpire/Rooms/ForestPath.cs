namespace SembianEmpire.Rooms
{
    public class ForestPath : RoomBase
    {
        protected override string GetLookText(Directions direction)
        {
            switch (direction)
            {
                case Directions.Here:
                    return "The forest path you are on hasn't been travelled in years.";
                case Directions.North:
                    return "The path continues on to the north. You can barely make out what appears to be a house a ways further.";
                case Directions.East:
                    return "A marsh of quicksand lies to the east. There does not seem to be any way through.";
                case Directions.South:
                    return "To the south you see a beautiful forest glaze with a glimmering pool.";
            }

            return base.GetLookText(direction);
        }

        public override string GetConnectedRoom(Directions direction)
        {
            switch (direction)
            {
                case Directions.South:
                    return nameof(ForestGlaze);
            }

            return base.GetConnectedRoom(direction);
        }
    }
}
