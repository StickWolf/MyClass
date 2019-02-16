using SembianEmpire.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SembianEmpire.Characters
{
    public static class CharacterManager
    {
        private static Random rnd = new Random();

        private static Dictionary<GameCharacters, Character> Characters = new Dictionary<GameCharacters, Character>();

        public static void Init()
        {
            // Create character instances to represent all characters
            Characters.Clear();
            Characters.Add(GameCharacters.Player, new Player());
            Characters.Add(GameCharacters.Jrimgolz, new Jrimgolz());
        }

        public static bool CharacterIsDead(GameCharacters character)
        {
            var attacker = Characters[character];
            return attacker.IsDead();
        }

        public static void CharacterAttacksCharacter(GameCharacters attackingPlayer, GameCharacters defendingPlayer)
        {
            var attacker = Characters[attackingPlayer];
            // If the attacker is dead then just don't do anything here.
            // If a message should be shown, then show it at the calling location
            if (attacker.IsDead())
            {
                return;
            }

            var defender = Characters[defendingPlayer];
            // The player can't be the defender at this point. 
            // A player death should have been processed before here.
            // This can only be a character target.
            if (defender.IsDead())
            {
                Console.WriteLine($"It would be pointless to attack {defender.Name}, they are already dead.");
                return;
            }

            // Now we know both characters are alive, process the attack

            // Determine the attacker attack value
            int damage = rnd.Next(0, attacker.Strength);
            // Apply the damage to the defender
            defender.Hit(damage);

            // Player is defending
            if (defendingPlayer == GameCharacters.Player)
            {
                Console.WriteLine(
                    damage == 0 ?
                    $"{attacker.Name} tries to attack you, but misses!" :
                    $"You are attacked by {attacker.Name} for {damage} damage!"
                    );

                // The player dying is processed globally by the main game loop
            }
            else
            {
                if (damage == 0)
                {
                    Console.WriteLine(
                        attackingPlayer == GameCharacters.Player ?
                        $"You attempt to attack {defender.Name} but miss!" :
                        $"{attacker.Name} tries to attack {defender.Name} but misses!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        attackingPlayer == GameCharacters.Player ?
                        $"You attack {defender.Name} for {damage} damage!" :
                        $"{attacker.Name} attacks {defender.Name} for {damage} damage!"
                    );
                }

                if (defender.IsDead())
                {
                    Console.WriteLine($"{defender.Name} has died.");
                }
            }
        }

        public static void ProcessAllCharacterTurns()
        {
            var player = Characters[GameCharacters.Player];

            // Currently the game just goes through the characters as they were added initially
            // Though we may want to somehow determine which characters are faster and let them go first
            foreach (var gameCharacter in Characters.Keys)
            {
                ProcessCharacterTurn(gameCharacter);
                // If the player is dead, it's game over and we don't need to process any more turns
                if (player.IsDead())
                {
                    break;
                }
            }
        }

        public static void ProcessCharacterTurn(GameCharacters gameCharacter)
        {
            var character = Characters[gameCharacter];

            // If a character is dead, they don't get a turn
            if (character.IsDead())
            {
                return;
            }

            character.ProcessCharacterTurn();
        }

        public static void WriteCharacterStats(GameCharacters gameCharacter)
        {
            var characterRoom = RoomManager.GetCharacterCurrentRoom(gameCharacter);
            var character = Characters[gameCharacter];
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"[{characterRoom.RoomName}] {character.Name} HP: {character.HitPoints} / {character.MaxHitPoints}");
        }
    }
}
