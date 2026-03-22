using System;

namespace CyberSecurityChatBot
{
    /// <summary>
    /// This will be my main program file for the CyberSecurityChatBot project.
    /// it will run across dedicated classes.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Step 1: Play voice greeting + Show ASCII art logo
            voice_logo intro = new voice_logo();

            // Step 2: Capture user's name and display personalized welcome
            UserSession session = new UserSession();
            session.StartSession();

            // Step 3: Run main chatbot loop
            ChatBot bot = new ChatBot(session.UserName);
            bot.Run();
        }
    }
}