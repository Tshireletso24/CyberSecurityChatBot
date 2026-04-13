using System;
using System.Threading;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Provides reusable console UI helper methods for colours,
    /// typing effects, dividers, and formatted output.
    /// </summary>
    static class ConsoleHelper
    {
        /// <summary>
        /// Prints a message with a typing effect, character by character.
        /// </summary>
        public static void TypeLine(string text, ConsoleColor color, int delayMs = 20)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a bot response prefixed with [CyberBot] and a typing effect.
        /// </summary>
        public static void PrintBotResponse(string message, ConsoleColor color)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("  [CyberBot] >> ");
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(12);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a decorative horizontal divider line.
        /// </summary>
        public static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ══════════════════════════════════════════════════════");
            Console.ResetColor();
        }
    }
}