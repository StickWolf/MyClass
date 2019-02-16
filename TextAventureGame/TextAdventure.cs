using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAventureGame
{
    public static class TextAdventure
    {
        private static void Main()
        {
            TextGame();
            Console.ReadLine();
        }

        public static void TextGame()
        {
            string girlName = "Midnight";
            string bratName = "Rosyania";
            string bratFriendName = "Lilac";
            int girlAge = 12;

            Console.WriteLine("there was a girl,");
            Console.ReadLine();
            Console.WriteLine("she was half wolf half human");
            Console.ReadLine();
            Console.WriteLine("she had no friends because everybody thought she was a weirdo");
            Console.ReadLine();
            Console.WriteLine("her name was " + girlName);
            Console.ReadLine();
            Console.WriteLine("all of the spoiled brats were jelous of her name");
            Console.ReadLine();
            Console.WriteLine("so they bullied her hard each day");
            Console.ReadLine();
            Console.WriteLine("the person who bullied her the most was " + bratName);
            Console.ReadLine();
            Console.WriteLine(girlName + " was very sad. But even worse, " + bratName + " was her stepsister");
            Console.ReadLine();
            Console.WriteLine(girlName + " was " + girlAge);
            Console.ReadLine();
            Console.WriteLine("soon " + bratName + "got a friend to help bully" + girlName);
            Console.ReadLine();
            Console.WriteLine("her name was" + bratFriendName);
            Console.ReadLine();
            Console.WriteLine("Now...");
            Console.ReadLine();
            Console.WriteLine("YOU are " + girlName);
            Console.ReadLine();
            Console.WriteLine("you have to have to live following these three rules:");
            Console.WriteLine("1: don't die");
            Console.WriteLine("2: be happy");
            Console.WriteLine("3: it's up to you.");

            Console.ReadLine();

            string reply, s1;

            Console.WriteLine("NONONONONO DO NOT PRESS ANYTHING ON THE KEYBOARD");
            reply = Console.ReadLine();
            Console.WriteLine($"I TOLD YOU NOT TO PRESS ANYTHING AND YOU PRESSED {reply}!");
            s1 = Console.ReadLine();
            Console.WriteLine($"GO SAY {s1} TO THAT RANDOM PERSON STANDING RIGHT THERE!");
            Console.WriteLine("Random Person: hey, watch where your going!");
            Console.WriteLine("so, if this is how it goes, give me the passord and let you go....");
        
            var secretanswer = "uno";
            var currentanswer = "";
            while (!currentanswer.Equals(secretanswer))
            {
                Console.WriteLine("Enter the secret passord");
                currentanswer = Console.ReadLine();
            }

            Console.WriteLine("okeyMCdokey.That'll do.");
        
            string name, yellingName, blindName, name2;

            Console.WriteLine("OKAY, SO YOU CAME BACK. AND BESIDES, I'M THE YELLING MAN.");
            Console.WriteLine("OKAY, NOW YOU CAN TELL ME WHAT YOUR NAME IS!");
            name = Console.ReadLine();
            Console.WriteLine($"OKAY, {name}, THAT GIRL OVER THERE THAT YOU JUST TALKED TO WAS THE BLINFOLDED GIRL.");
            Console.WriteLine("BLINDFOLDED GIRL: and besides, i'm sick of the yelling man calling me the blindfolded girl.");
            Console.WriteLine("wait a minute...");
            Console.WriteLine($"Hey {name}! how abouit YOU give us new names!");
            yellingName = Console.ReadLine();
            blindName = Console.ReadLine();
            Console.WriteLine($"huh. {blindName} and {yellingName}. pretty good names!");
            Console.WriteLine("SERIOUSLY? I DON'T LIKE MY NEW NAME. DO SOMETHING DIFFERENT! SOMETHING...STRONG AND BOLD.");
            name2 = Console.ReadLine();
            Console.WriteLine($"ALRIGHT! {name2}, I LIKE IT!");
            Console.WriteLine($"Okay, maybe just start a band? like {name} would be singing, I got my electric drums, and {name2}?");
            Console.WriteLine($"{yellingName}, ");
        }
    }
}
