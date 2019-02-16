using System;
using System.Linq;

namespace SembianEmpire.Rooms
{
    public abstract class RoomBase
    {
        /// <summary>
        /// Number of times the room has been visited
        /// </summary>
        public int VisitCount { get; private set; }

        public string RoomName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public virtual void Enter()
        {
            VisitCount++;
        }

        public virtual void Exit()
        {

        }

        public virtual void Look()
        {
            Globals.AllDirections
                    .Select(dir => GetLookText(dir))
                    .Where(text => text != null).ToList()
                    .ForEach(text => Console.WriteLine(text));
        }

        //public void Look(Directions direction)
        //{
        //    string lookText = GetLookText(direction);
        //    if (string.IsNullOrWhiteSpace(lookText))
        //    {
        //        switch (direction)
        //        {
        //            case Directions.Down:
        //                lookText = "You don't see anything of interest below you";
        //                break;
        //            case Directions.Up:
        //                lookText = "You don't see anything of interest above you";
        //                break;
        //            case Directions.Here:
        //                lookText = "You don't see anything of interest";
        //                break;
        //            default:
        //                lookText = $"You don't see anything of interest to the {direction}";
        //                break;
        //        }
        //    }

        //    Console.WriteLine(lookText);
        //}

        protected virtual string GetLookText(Directions direction)
        {
            return null;
        }

        public virtual string GetConnectedRoom(Directions direction)
        {
            return null;
        }

        public virtual bool ProcessUserInput(string userInput)
        {
            return false;
        }
    }
}
