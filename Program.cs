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
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Set the output encoding to UTF-8qq

            //Step 1: Play voice greeting using text-to-speech
            VoiceGreeting.Play();

            //Step 2: Show ASCII art logo
            AsciiArt.Display();

            //Step 3: Capture user's name and disolay personalized welcome
            UserSession session = new UserSession();
            session.StartSession();

            //Final Step: Run main chatbot loop
            ChatBot bot = new ChatBot(session.UserName);
            bot.Run();
        }
    }
}