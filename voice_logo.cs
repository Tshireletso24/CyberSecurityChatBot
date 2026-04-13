using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Security.Policy;

namespace CyberSecurityChatBot
{
    internal class voice_logo
    {
        private string full_path = AppDomain.CurrentDomain.BaseDirectory;

        public voice_logo()
        {
            greetings();
            asci();
        }

        private void greetings()
        {
        string correct_path = full_path.Replace(@"\bin\Debug\" , @"\greeting.wav");
    

            SoundPlayer greet = new SoundPlayer(correct_path);
            greet.Play();
        }

        private void asci()
        {
            string path = Path.Combine(full_path, "logo.png");


            Bitmap image = new Bitmap(Image.FromFile(path));
            int width = Console.WindowWidth - 1;
            int height = width/2;
            Bitmap resizedImage = new Bitmap(image, new Size(width, height));

            string asciiChars = "@%#*+;:,. ";

            for (int y = 0; y < resizedImage.Height; y++)
            {
                for (int x = 0; x < resizedImage.Width; x++)
                {
                    Color pixelColor = resizedImage.GetPixel(x, y);  
                    int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int charIndex = grayValue * (asciiChars.Length - 1) / 255;

                    if (grayValue < 85)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (grayValue < 170)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(asciiChars[charIndex]);
                }
                Console.WriteLine();
            }
            // Reset console color after displaying the logo
        
            Console.ResetColor();
        }
    }
}