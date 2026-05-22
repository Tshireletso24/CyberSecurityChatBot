using System;
using System.Speech.Synthesis;



namespace CyberSecurityChatBot
{
    /// <summary>
    /// This will handle the voice greeting that will bve played when the application launches. It will use the System.Speech.Synthesis namespace to convert text to speech and play a welcome message to the user.
    ///use built in text to speech engine
    /// </summary>
    static class VoiceGreeting
    {
        //plays welcome voice using System.Speech TTS
        // Must continue silently if theres an error with the TTS engine
        public static void Play()
        {
            try
            {
                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.Volume = 100;
                    synthesizer.Rate = 0;
                    synthesizer.Speak("Hello! Welcome to the Cybersecurity awerenss assistant. " +
                        "I am here to help you stay safe online. Let's get started!");

                }
            }
            catch (Exception)
            {
                // TTS may not be available in all environments — fail silently


            }
        }
    } 
}
