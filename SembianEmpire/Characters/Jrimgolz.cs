using SembianEmpire.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SembianEmpire.Characters
{
    public class Jrimgolz : Character
    {
        public Jrimgolz()
            : base(nameof(Jrimgolz), 12, 8) { }

        public override void ProcessCharacterTurn()
        {
            // Jrimgols does nothing if he is in a different room
            if (!RoomManager.CharacterIsInPlayersRoom(GameCharacters.Jrimgolz))
            {
                return;
            }

            // Which room are we in?
            var currentRoom = RoomManager.GetCharacterCurrentRoom(GameCharacters.Jrimgolz);

            // When the candles are not lit Jrimgolz runs around in a circle
            if (!Globals.Instance.FountainStairwell_CandlesLit)
            {
                // Do different actions depending on which room it is
                switch (currentRoom.RoomName)
                {
                    case nameof(FountainStairwell):
                        Console.WriteLine("You sense a small creature lurking around your feet.");
                        CharacterManager.CharacterAttacksCharacter(GameCharacters.Jrimgolz, GameCharacters.Player);
                        Console.WriteLine($"{GameCharacters.Jrimgolz} runs down a darkened hallway.");
                        RoomManager.EnterRoom(GameCharacters.Jrimgolz, nameof(MossyHall1));
                        break;
                    case nameof(MossyHall1):
                        Console.WriteLine($"{GameCharacters.Jrimgolz} runs down a darkened hallway.");
                        RoomManager.EnterRoom(GameCharacters.Jrimgolz, nameof(MossyHall2));
                        break;
                    case nameof(MossyHall2):
                        Console.WriteLine($"{GameCharacters.Jrimgolz} runs down a darkened hallway.");
                        RoomManager.EnterRoom(GameCharacters.Jrimgolz, nameof(MossyHall3));
                        break;
                    case nameof(MossyHall3):
                        Console.WriteLine($"{GameCharacters.Jrimgolz} runs down a darkened hallway.");
                        RoomManager.EnterRoom(GameCharacters.Jrimgolz, nameof(FountainStairwell));
                        break;
                }

                return;
            }

            // TODO: in the case when the candles are lit, Jrimgolz will be trying to pry a golden cup out
            // TODO: of a locked safe embedded in the wall in the fountainstairwell.
            // TODO: The act of lighting the candles at the top of the stairwell should
            // TODO: place jrimgolz in the correct room. Somewhere else the player needs to find the key
            // TODO: to this safe before visiting this location. Jrimgolz will be obsessed with the 
            // TODO: safe and won't pay attention to the player during this time. When the player opens
            // TODO: up the safe Jrimgolz will become a loyal servant, healing the player when needed.
            // TODO: the healing will be needed in a different location, such as a tougher battle that is
            // TODO: pretty close to impossible to beat without Jrimgolz.

        }
    }
}
