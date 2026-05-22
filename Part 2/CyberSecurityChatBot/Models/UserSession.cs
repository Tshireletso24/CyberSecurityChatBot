using CyberSecurityChatBot;
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

