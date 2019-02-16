using SembianEmpire.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SembianEmpire.Rooms
{
    public static class RoomManager
    {
        /// <summary>
        /// Keeps track of the state of each room
        /// </summary>
        private static Dictionary<string, RoomBase> roomStates = new Dictionary<string, RoomBase>();

        /// <summary>
        /// Keeps track of what room each character is in
        /// </summary>
        private static Dictionary<GameCharacters, string> characterRoomLocations = new Dictionary<GameCharacters, string>();

        public static void Init()
        {
            // Create all rooms
            roomStates.Clear();
            roomStates.Add(nameof(ForestGlaze), new ForestGlaze());
            roomStates.Add(nameof(ForestPath), new ForestPath());
            roomStates.Add(nameof(FountainStairwell), new FountainStairwell());
            roomStates.Add(nameof(MarbleFountain), new MarbleFountain());
            roomStates.Add(nameof(MossyHall1), new MossyHall1());
            roomStates.Add(nameof(MossyHall2), new MossyHall2());
            roomStates.Add(nameof(MossyHall3), new MossyHall3());

            // Place characters in their initial starting rooms
            EnterRoom(GameCharacters.Player, nameof(ForestGlaze));
            EnterRoom(GameCharacters.Jrimgolz, nameof(FountainStairwell));
        }

        public static void EnterRoom(GameCharacters character, string roomName)
        {
            RoomBase characterCurrentRoom;

            // Only the player should trigger Exit and Enter events (which show text on the console)
            // Other characters should move around freely without triggering events or showing text
            if (character == GameCharacters.Player)
            {
                // Exit the existing room, if there is one set
                characterCurrentRoom = GetCharacterCurrentRoom(character);
                if (characterCurrentRoom != null)
                {
                    characterCurrentRoom.Exit();
                }
            }

            // Take note of where the character is now
            characterRoomLocations[character] = roomName;

            if (character == GameCharacters.Player)
            {
                characterCurrentRoom = GetCharacterCurrentRoom(character);

                // Enter the new room
                characterCurrentRoom.Enter();

                // Take a look around
                characterCurrentRoom.Look();
            }
        }

        public static RoomBase GetCharacterCurrentRoom(GameCharacters character)
        {
            // If this character is nowhere
            if (!characterRoomLocations.ContainsKey(character))
            {
                return null;
            }

            string roomName = characterRoomLocations[character];
            var room = roomStates[roomName];
            return room;
        }

        public static bool CharacterIsInRoom(GameCharacters character, string roomName)
        {
            // If this character is nowhere
            if (!characterRoomLocations.ContainsKey(character))
            {
                return false;
            }

            string characterRoomName = characterRoomLocations[character];
            return characterRoomName.Equals(roomName);
        }

        public static List<GameCharacters> GetCharactersInPlayersRoom()
        {
            var playerRoomName = characterRoomLocations[GameCharacters.Player];
            var charactersInRoom = characterRoomLocations
                // Choose only characters that are in the same room
                .Where(kvp => kvp.Value.Equals(playerRoomName))
                .Select(kvp => kvp.Key)
                // Except the player, who is always in the same room as the player
                .Except(new[] { GameCharacters.Player })
                .ToList();
            return charactersInRoom;
        }

        public static bool CharacterIsInPlayersRoom(GameCharacters character)
        {
            if (!characterRoomLocations.ContainsKey(character))
            {
                return false;
            }

            string characterRoomName = characterRoomLocations[character];
            string playersRoomName = characterRoomLocations[GameCharacters.Player];
            return characterRoomName.Equals(playersRoomName);
        }

        public static T GetRoom<T>() where T : RoomBase
        {
            string roomName = typeof(T).Name;
            return roomStates[roomName] as T;
        }
    }
}
