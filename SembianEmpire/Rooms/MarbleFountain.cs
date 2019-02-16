using System;
using System.Collections.Generic;
using System.Linq;

namespace SembianEmpire.Rooms
{
    public class MarbleFountain : RoomBase
    {
        protected override string GetLookText(Directions direction)
        {
            switch (direction)
            {
                case Directions.Here:
                    var text = new List<string>();
                    text.Add("You stand in front of an old marble fountain covered in moss.");
                    text.Add("The fountain has stopped working long ago.");
                    if (Globals.Instance.MarbleFountain_LeverSwitched)
                    {
                        text.Add("The fountain statue is shifted to the side.");
                    }
                    else
                    {
                        text.Add("You notice a small lever on the side of the fountain.");
                    }

                    return string.Join(Environment.NewLine, text);

                case Directions.Down:
                    if (Globals.Instance.MarbleFountain_LeverSwitched)
                    {
                        if (Globals.Instance.FountainStairwell_CandlesLit)
                        {
                            return "A staircase leads down into a hallway. A number of lit candles line the stairway.";
                        }
                        else
                        {
                            return "A staircase leads down into the darkness. A number of unlit candles line the stairway.";
                        }
                    }
                    break;

                case Directions.East:
                    return "To the east you see a beautiful forest glaze.";
            }

            return base.GetLookText(direction);
        }

        public override string GetConnectedRoom(Directions direction)
        {
            switch (direction)
            {
                case Directions.East:
                    return nameof(ForestGlaze);
                case Directions.Down:
                    if (Globals.Instance.MarbleFountain_LeverSwitched)
                    {
                        return nameof(FountainStairwell);
                    }
                    break;
            }

            return base.GetConnectedRoom(direction);
        }

        public override bool ProcessUserInput(string userInput)
        {
            if (userInput.Contains("lever"))
            {
                var validVerbs = new List<string>() { "use", "press", "toggle", "flip", "pull", "push" };
                if (validVerbs.Any(v => userInput.Contains(v)))
                {
                    ToggleLever();
                    return true;
                }
            }

            if (userInput.Contains("light") && userInput.Contains("candle"))
            {
                LightCandles();
                return true;
            }

            return false;
        }

        private void LightCandles()
        {
            if (!Globals.Instance.FountainStairwell_CandlesLit)
            {
                Globals.Instance.FountainStairwell_CandlesLit = true;
                Console.WriteLine("You light the candles on the side of the stairwell and glimpse a small creature sneak down the hallway below.");
                // TODO: Jrimgolz should move to the next room
            }
            else
            {
                Console.WriteLine("The candles are already lit.");
            }
        }

        private void ToggleLever()
        {
            if (!Globals.Instance.MarbleFountain_LeverSwitched)
            {
                Globals.Instance.MarbleFountain_LeverSwitched = true;
                Console.WriteLine("The lever clicks down.");
                Console.WriteLine("The mechanical clicking and whirring of a machine can be heard coming from underground.");
                Console.WriteLine("You watch as the fountain's center statue moves to the side.");
                Console.WriteLine("A hidden staircase lined with unlit candles has been revealed. It circles down into the darkness.");
            }
            else
            {
                Console.WriteLine("The lever appears to be stuck.");
            }
        }
    }
}
