using System;


namespace CyberSecurityChatBot
{
    /// <summary>
    /// Displays the ASCII art logo and title header when the application starts.
    /// </summary>
    static class AsciiArt
    {
        //clears the console and displays the ASCII art logo and title header
        public static void Display()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine(@"  ██████╗██╗   ██╗██████╗ ███████╗██████╗      ");
            Console.WriteLine(@" ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗     ");
            Console.WriteLine(@" ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝     ");
            Console.WriteLine(@" ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗     ");
            Console.WriteLine(@" ╚██████╗   ██║   ██████╔╝███████╗██║  ██║     ");
            Console.WriteLine(@"  ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝     ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(@"   ███████╗███████╗ ██████╗██╗   ██╗██████╗ ███████╗");
            Console.WriteLine(@"   ██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██╔════╝");
            Console.WriteLine(@"   ███████╗█████╗  ██║     ██║   ██║██████╔╝█████╗  ");
            Console.WriteLine(@"   ╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██╔══╝  ");
            Console.WriteLine(@"   ███████║███████╗╚██████╗╚██████╔╝██║  ██║███████╗");
            Console.WriteLine(@"   ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║       🔒 CYBERSECURITY AWARENESS ASSISTANT 🔒        ║");
            Console.WriteLine("  ║         Protecting South African Citizens            ║");
            Console.WriteLine("  ╚══════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.ResetColor();
        }
    }
}
