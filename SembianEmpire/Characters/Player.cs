using SembianEmpire.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SembianEmpire.Characters
{
    public class Player : Character
    {
        public Player()
            : base(nameof(Player), 25, 12) { }

        public override void ProcessCharacterTurn()
        {
            ProcessPlayerUserInput();
        }

        private static void ProcessPlayerUserInput()
        {
            // This is a simple parser, it only understand basic commands and can be easily confused.

            // Write the player current stats right before prompting them
            CharacterManager.WriteCharacterStats(GameCharacters.Player);

            // Write this at the beginning of the prompt line.
            Console.WriteLine();
            Console.Write(">");

            // We convert the userInput to lowercase to make comparing strings easier
            // This is because "LOOK" is not the same as "look"
            string userInput = Console.ReadLine().ToLower();

            Console.Clear();

            // Split up the user input by spaces
            var userInputParts = userInput.Split(' ');

            // The main action is always the first word
            var mainAction = userInputParts[0];

            // Do different things based on what the main action is
            switch (mainAction)
            {
                case "look":
                    ProcessPlayerLookCommand(userInputParts);
                    break;
                case "go":
                    ProcessPlayerGoCommand(userInputParts);
                    break;
                case "attack":
                    ProcessPlayerAttackCommand(userInputParts);
                    break;

                // The room itself may process the input if no global actions are recognized
                default:
                    bool processedByRoom = RoomManager.GetCharacterCurrentRoom(GameCharacters.Player).ProcessUserInput(userInput);
                    if (!processedByRoom)
                    {
                        Console.WriteLine($"I do not understand '{userInput}'");
                    }
                    break;
            }
        }

        private static void ProcessPlayerLookCommand(string[] userInputParts)
        {
            // Show look information from the room
            RoomManager.GetCharacterCurrentRoom(GameCharacters.Player).Look();

            // Also show any characters that are in this same room
            var charactersInRoom = RoomManager.GetCharactersInPlayersRoom();
            foreach (var character in charactersInRoom)
            {
                if (CharacterManager.CharacterIsDead(character))
                {
                    Console.WriteLine($"You notice {character} is here, dead.");
                }
                else
                {
                    Console.WriteLine($"{character} is here.");
                }
            }
        }

        private static void ProcessPlayerGoCommand(string[] userInputParts)
        {
            if (userInputParts.Length > 1)
            {
                var userSpecifiedDirection = userInputParts[1];

                foreach (var direction in Globals.AllDirections)
                {
                    // enum values are not strings, convert the enum direction to a string we can compare against
                    string directionLowercaseName = direction.ToString().ToLower();
                    if (userSpecifiedDirection.Equals(directionLowercaseName))
                    {
                        // If the direction is here, then ignore it, they are already here.
                        if (direction == Directions.Here)
                        {
                            return;
                        }
                        else
                        {
                            // Check to see if there is a room in the direction they want to move
                            string connectedRoomName = RoomManager.GetCharacterCurrentRoom(GameCharacters.Player).GetConnectedRoom(direction);
                            // And if there is, enter that room
                            if (connectedRoomName != null)
                            {
                                RoomManager.EnterRoom(GameCharacters.Player, connectedRoomName);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("You are unable to move in this direction at this time.");
                                return;
                            }
                        }
                    }
                }
            }

            // Unable to determine the direction to move
            Console.WriteLine("Move where?");
        }

        private static void ProcessPlayerAttackCommand(string[] userInputParts)
        {
            // There must be at-least 2 parts
            if (userInputParts.Length > 1)
            {
                // If the string that the user typed was recognized as a valid character
                if (Enum.TryParse(userInputParts[1], true, out GameCharacters targetCharacter))
                {
                    CharacterManager.CharacterAttacksCharacter(GameCharacters.Player, targetCharacter);
                    return;
                }
            }

            // Unable to determine the character to attack
            Console.WriteLine("Attack who?");
        }

    }
}
