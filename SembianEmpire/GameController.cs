using SembianEmpire.Characters;
using SembianEmpire.Rooms;
using System;

namespace SembianEmpire
{
    public static class GameController
    {
        public static void ExecuteGameEngine()
        {
            while (true)
            {
                // Show some game intro text
                Console.WriteLine("Welcome to the Sembian Empire. A simple text adventure game.");
                Console.WriteLine("You can look or move and you can also specify a direction (North, South, West, East).");
                Console.WriteLine("For example, type 'look' to see what is around you. Then type 'go west' to move west.");
                Console.WriteLine();

                // Initilize the various managers
                // These need to be after the above text because the room manager
                // will show text when the player enters the initial room.
                Globals.Init();
                RoomManager.Init();
                CharacterManager.Init();

                // Most games have a main game loop, here is ours. It's a very basic one, 
                // there are more advanced versions of game loops
                while (true)
                {
                    // Give all the players a chance to perform an action
                    CharacterManager.ProcessAllCharacterTurns();

                    if (CharacterManager.CharacterIsDead(GameCharacters.Player))
                    {
                        Console.WriteLine("You have died.");
                        break;
                    }
                }

                Console.WriteLine("Press a key to start a new game.");
                Console.ReadKey();
            }
        }


    }
}
