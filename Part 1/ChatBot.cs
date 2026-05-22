using CybersecurityChatbot;
using System;
using System.Threading;

namespace CyberSecurityChatBot
{
    /// <summary>
    ///  This will handle the main chat loop, user interaction 
    ///  and response logic
    ///  </summary>
    internal class ChatBot
    {
        private string userName;

        public ChatBot(string userName) 
        {
            this.userName = userName; 
        }

        public void Run()
        {
            DisplayTopicsMenu();

            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                string userInput = Console.ReadLine();
                Console.Write($" [{userInput}] >> ");
                Console.ResetColor();


                //input validation - if it's empty, prompt again
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleHelper.PrintBotResponse("I didn't recieve any input. Could you please type something?", ConsoleColor.Red);
                    continue;
                }
                userInput = userInput.Trim().ToLower();

                if (userInput == "exit" || userInput == "quit" || userInput == "bye)")
                {
                    Console.WriteLine();
                    ConsoleHelper.PrintDivider();
                    ConsoleHelper.TypeLine($" Goodbye, {userInput}! Stay safe online.", ConsoleColor.Green);
                    ConsoleHelper.PrintDivider();
                    Console.ResetColor();
                    break;
                }
                string response = ResponseEngine.GetResponse(userInput, this.userName);
                ConsoleHelper.PrintBotResponse(response, ConsoleColor.Cyan);
            }
        }
        private void DisplayTopicsMenu()
        {
            ConsoleHelper.PrintDivider();
            ConsoleHelper.TypeLine("  You can ask me about:", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    • Password Safety");
            Console.WriteLine("    • Phishing Scams");
            Console.WriteLine("    • Safe Browsing");
            Console.WriteLine("    • Suspicious Links");
            Console.WriteLine("    • Malware & Viruses");
            Console.WriteLine("    • Social Engineering & Scams");
            Console.WriteLine("    • How are you?");
            Console.WriteLine("    • What is your purpose?");
            Console.WriteLine("    • Type 'exit' to quit");
            ConsoleHelper.PrintDivider();
            Console.ResetColor();
        }
    }
}
