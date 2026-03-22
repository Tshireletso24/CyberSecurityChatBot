namespace CybersecurityChatbot
{
    /// <summary>
    /// Contains all predefined chatbot responses for cybersecurity topics.
    /// </summary>
    static class ResponseEngine
    {
        /// <summary>
        /// Matches user input to a predefined response. Returns a default
        /// fallback message if no match is found (input validation).
        /// </summary>
        public static string GetResponse(string input, string userName)
        {
            // General conversational questions
            if (input.Contains("how are you"))
                return $"I'm doing great, {userName}! Ready to help you stay cyber-safe today. 😊";

            if (input.Contains("purpose") || input.Contains("what do you do"))
                return $"My purpose is to educate South African citizens like yourself, {userName}, " +
                       "about cybersecurity threats and how to stay safe online.";

            if (input.Contains("what can i ask") || input.Contains("help") || input.Contains("topics"))
                return "You can ask me about:\n" +
                       "    • Password Safety\n" +
                       "    • Phishing Scams\n" +
                       "    • Safe Browsing\n" +
                       "    • Suspicious Links\n" +
                       "    • Malware & Viruses\n" +
                       "    • Social Engineering & Scams";

            // Cybersecurity topics
            if (input.Contains("password"))
                return $"Great question, {userName}! Here are key password safety tips:\n" +
                       "    • Use at least 12 characters mixing letters, numbers & symbols.\n" +
                       "    • Never reuse the same password across different sites.\n" +
                       "    • Use a reputable password manager to store passwords safely.\n" +
                       "    • Enable two-factor authentication (2FA) wherever possible.\n" +
                       "    • Never share your password with anyone, even trusted contacts.";

            if (input.Contains("phishing"))
                return $"Phishing is a serious threat, {userName}! Here's what to watch for:\n" +
                       "    • Emails asking urgently for personal info or login credentials.\n" +
                       "    • Sender addresses that look slightly 'off' (e.g. support@amaz0n.com).\n" +
                       "    • Links that don't match the expected website URL.\n" +
                       "    • Unexpected attachments — never open them without verifying.\n" +
                       "    • When in doubt, go directly to the website rather than clicking links.";

            if (input.Contains("browsing") || input.Contains("safe browsing") || input.Contains("internet"))
                return $"Here are safe browsing tips for you, {userName}:\n" +
                       "    • Always look for HTTPS (padlock icon) before entering any data.\n" +
                       "    • Keep your browser and operating system up to date.\n" +
                       "    • Avoid using public Wi-Fi for banking or sensitive activities.\n" +
                       "    • Use a VPN on public networks for an added layer of security.\n" +
                       "    • Clear your browser cache and cookies regularly.";

            if (input.Contains("suspicious") || input.Contains("link") || input.Contains("url"))
                return $"Spotting suspicious links is crucial, {userName}!\n" +
                       "    • Hover over links to preview the actual URL before clicking.\n" +
                       "    • Shortened URLs (bit.ly etc.) can hide malicious destinations.\n" +
                       "    • Look for misspellings in domain names (e.g. faceb00k.com).\n" +
                       "    • Use a link checker like VirusTotal.com to verify suspicious URLs.";

            if (input.Contains("malware") || input.Contains("virus"))
                return $"Malware protection is essential, {userName}!\n" +
                       "    • Install reputable antivirus software and keep it updated.\n" +
                       "    • Never download software from untrusted websites.\n" +
                       "    • Be cautious of 'free' software that bundles unwanted programs.\n" +
                       "    • Regularly back up your important files to an external drive or cloud.";

            if (input.Contains("social engineering") || input.Contains("scam"))
                return $"Social engineering tricks people into giving away info, {userName}!\n" +
                       "    • Be sceptical of unsolicited calls, texts or emails.\n" +
                       "    • No legitimate company will ask for your password over the phone.\n" +
                       "    • Verify the identity of anyone requesting sensitive information.\n" +
                       "    • Trust your instincts — if something feels wrong, it probably is.";

            // Default fallback — Input Validation
            return $"I didn't quite understand that, {userName}. Could you rephrase?\n" +
                   "    Try asking about: password safety, phishing, safe browsing, or suspicious links.";
        }
    }
}