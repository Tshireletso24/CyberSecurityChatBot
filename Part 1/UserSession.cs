using CybersecurityChatbot;
using System;


namespace CyberSecurityChatBot
{
    /// <summary>
    /// Manages the user session by capturing user's name
    /// and displays a personalised welcome message.
    /// </summary>
   class UserSession

    {
        public string UserName { get; private set; }

        //prompts the user for their name with input validation
        //then displays a personalised text greeting
         
        public void StartSession()
        {
            ConsoleHelper.PrintDivider();

            ConsoleHelper.TypeLine(" Welcome to your Cybersecurity Awareness Assistant! ", ConsoleColor.Green);

            ConsoleHelper.TypeLine(" I am here to help you stay safe online. ", ConsoleColor.Green);
            
            ConsoleHelper.PrintDivider();
            Console.WriteLine();

            UserName = PromptForName();

            Console.WriteLine();

            ConsoleHelper.TypeLine($" Hello, {UserName}! Great to have you here. 😊", ConsoleColor.Cyan);

            ConsoleHelper.TypeLine(" I will be guiding you on how to protect yourself from cyber threats. ", ConsoleColor.Cyan);
            Console.WriteLine();

        }
        // Repeatedly prompts the user until a non-empty name is entered
        private string PromptForName()
        {
            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(" >> Please enter your name: ");

                Console.ResetColor();

                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  ⚠  Name cannot be empty. Please enter your name.");
                    Console.ResetColor();
                }

            } while (string.IsNullOrWhiteSpace(name));

            return name.Trim();

        }
            
        }
    }

