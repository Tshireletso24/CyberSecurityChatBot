using System;
using System.Collections.Generic;

namespace CyberSecurityChatBot
{
    /// <summary>
    /// Handles all chatbot response logic including keyword recognition,
    /// random responses, sentiment detection, and memory/recall.
    /// </summary>
    public static class ResponseEngine
    {
        private static Random _random = new Random();

        // ── Memory ──────────────────────────────────────────────────
        // Stores things the user has told us during the session
        private static Dictionary<string, string> _userMemory = new Dictionary<string, string>();

        // Tracks the last topic discussed (for conversation flow)
        private static string _lastTopic = "";

        // ── Random response pools ────────────────────────────────────
        private static List<string> _phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
            "Always check the sender's email address carefully — one wrong letter can mean it's fake.",
            "Legitimate banks and companies will NEVER ask for your password via email.",
            "If an email creates urgency like 'Act now or your account will be closed', it's almost certainly a phishing attempt.",
            "Hover over links before clicking — the real URL shows at the bottom of your browser."
        };

        private static List<string> _passwordTips = new List<string>
        {
            "Use at least 12 characters mixing uppercase, lowercase, numbers and symbols.",
            "Never reuse the same password across different websites — one breach exposes all your accounts.",
            "A passphrase like 'Coffee!Sunset42Tree' is both strong and easier to remember.",
            "Enable two-factor authentication (2FA) wherever possible — it's your second line of defence.",
            "Use a reputable password manager like Bitwarden or 1Password to store passwords safely."
        };

        private static List<string> _browsingTips = new List<string>
        {
            "Always check for HTTPS and the padlock icon before entering any personal data.",
            "Avoid using public Wi-Fi for banking or anything sensitive — use a VPN if you must.",
            "Keep your browser and operating system updated — patches fix security holes.",
            "Clear your cookies and cache regularly to reduce tracking.",
            "Use a browser extension like uBlock Origin to block malicious ads and trackers."
        };

        // ── Sentiment keywords ───────────────────────────────────────
        private static List<string> _worriedWords = new List<string>
        { "worried", "scared", "afraid", "nervous", "anxious", "frightened", "terrified", "panic" };

        private static List<string> _frustratedWords = new List<string>
        { "frustrated", "angry", "annoyed", "confused", "lost", "helpless", "overwhelmed", "stuck" };

        private static List<string> _curiousWords = new List<string>
        { "curious", "interested", "want to know", "tell me more", "explain", "how does", "what is", "wondering" };

        // ── Main entry point ─────────────────────────────────────────
        /// <summary>
        /// Matches user input to a response. Checks sentiment first,
        /// then memory storage, then keywords, then falls back to default.
        /// </summary>
        public static string GetResponse(string input, string userName)
        {
            input = input.ToLower().Trim();

            // ── 1. Check for conversation flow follow-ups ────────────
            if (input.Contains("more") || input.Contains("another tip") ||
                input.Contains("tell me more") || input.Contains("explain more") ||
                input.Contains("give me another"))
            {
                return HandleFollowUp(userName);
            }

            // ── 2. Check for sentiment ───────────────────────────────
            string sentimentResponse = CheckSentiment(input, userName);
            if (sentimentResponse != null)
                return sentimentResponse;

            // ── 3. Check for memory storage ("I'm interested in X") ──
            if (input.Contains("i'm interested in") || input.Contains("i am interested in") ||
                input.Contains("my favourite topic") || input.Contains("i like"))
            {
                return HandleMemoryStorage(input, userName);
            }

            // ── 4. Check for memory recall ("what do you remember") ──
            if (input.Contains("what do you remember") || input.Contains("do you remember") ||
                input.Contains("what have you remembered"))
            {
                return HandleMemoryRecall(userName);
            }

            // ── 5. General questions ─────────────────────────────────
            if (input.Contains("how are you"))
            {
                return $"I'm doing great, {userName}! Always ready to help you stay cyber-safe. 😊";
            }

            if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                return $"My purpose is to educate South African citizens like you, {userName}, " +
                       "about cybersecurity threats and how to stay safe online.";
            }

            if (input.Contains("help") || input.Contains("topics") || input.Contains("what can i ask"))
            {
                return "You can ask me about:\n• Password Safety\n• Phishing Scams\n" +
                       "• Safe Browsing\n• Suspicious Links\n• Malware & Viruses\n• Social Engineering & Scams";
            }

            // ── 6. Cybersecurity keywords ────────────────────────────
            if (input.Contains("password"))
            {
                _lastTopic = "password";
                // Check if we have a memory of their interest
                string extra = _userMemory.ContainsKey("interest") && _userMemory["interest"].Contains("password")
                    ? $"\n\nSince you're interested in password safety, here's a bonus tip: consider using a password manager!"
                    : "";
                return $"Great question, {userName}! Here's a password tip:\n\n" +
                       _passwordTips[_random.Next(_passwordTips.Count)] + extra;
            }

            if (input.Contains("phishing"))
            {
                _lastTopic = "phishing";
                return $"Phishing is a serious threat, {userName}! Here's what to watch for:\n\n" +
                       _phishingTips[_random.Next(_phishingTips.Count)];
            }

            if (input.Contains("browsing") || input.Contains("safe browsing") || input.Contains("internet"))
            {
                _lastTopic = "browsing";
                return $"Here's a safe browsing tip for you, {userName}:\n\n" +
                       _browsingTips[_random.Next(_browsingTips.Count)];
            }

            if (input.Contains("suspicious") || input.Contains("link") || input.Contains("url"))
            {
                _lastTopic = "links";
                return $"Spotting suspicious links is crucial, {userName}!\n\n" +
                       "• Hover over links to preview the real URL before clicking.\n" +
                       "• Shortened URLs (bit.ly etc.) can hide malicious destinations.\n" +
                       "• Look for misspellings in domain names (e.g. faceb00k.com).\n" +
                       "• Use VirusTotal.com to verify any suspicious URL.";
            }

            if (input.Contains("malware") || input.Contains("virus"))
            {
                _lastTopic = "malware";
                return $"Malware protection is essential, {userName}!\n\n" +
                       "• Install reputable antivirus software and keep it updated.\n" +
                       "• Never download software from untrusted websites.\n" +
                       "• Regularly back up your important files to an external drive or cloud.";
            }

            if (input.Contains("social engineering") || input.Contains("scam"))
            {
                _lastTopic = "scam";
                return $"Social engineering tricks people into giving away info, {userName}!\n\n" +
                       "• Be sceptical of unsolicited calls, texts or emails.\n" +
                       "• No legitimate company will ask for your password over the phone.\n" +
                       "• Trust your instincts — if something feels wrong, it probably is.";
            }

            if (input.Contains("privacy"))
            {
                _lastTopic = "privacy";
                StoreMemory("interest", "privacy");
                return $"Privacy is a crucial part of staying safe online, {userName}!\n\n" +
                       "• Review your social media privacy settings regularly.\n" +
                       "• Limit the personal information you share publicly.\n" +
                       "• Use encrypted messaging apps like Signal for sensitive conversations.\n\n" +
                       "I'll remember that you're interested in privacy! 🔒";
            }

            if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("two-factor"))
            {
                _lastTopic = "2fa";
                return $"Two-Factor Authentication (2FA) is one of the best things you can do, {userName}!\n\n" +
                       "• It adds a second layer of security beyond just your password.\n" +
                       "• Use an authenticator app like Google Authenticator or Authy.\n" +
                       "• Enable it on your email, banking, and social media accounts first.";
            }

            // ── 7. Exit ──────────────────────────────────────────────
            if (input == "exit" || input == "quit" || input == "bye")
            {
                return $"Goodbye, {userName}! Stay safe online. 🔒";
            }

            // ── 8. Default fallback ──────────────────────────────────
            _lastTopic = "";
            return $"I didn't quite understand that, {userName}. Could you rephrase?\n" +
                   "Try asking about: password safety, phishing, safe browsing, or suspicious links.";
        }

        // ── Helper methods ───────────────────────────────────────────

        /// <summary>Handles follow-up requests like "tell me more"</summary>
        private static string HandleFollowUp(string userName)
        {
            if (string.IsNullOrEmpty(_lastTopic))
                return $"Sure, {userName}! What topic would you like to know more about? " +
                       "Try asking about phishing, passwords, or safe browsing.";

            switch (_lastTopic)
            {
                case "password":
                    return $"Here's another password tip for you, {userName}:\n\n" +
                           _passwordTips[_random.Next(_passwordTips.Count)];
                case "phishing":
                    return $"Here's another phishing tip, {userName}:\n\n" +
                           _phishingTips[_random.Next(_phishingTips.Count)];
                case "browsing":
                    return $"Here's another safe browsing tip, {userName}:\n\n" +
                           _browsingTips[_random.Next(_browsingTips.Count)];
                default:
                    return $"Here's a general cybersecurity reminder, {userName}: " +
                           "Always keep your software updated — most attacks exploit outdated systems!";
            }
        }

        /// <summary>Detects emotional tone and responds empathetically</summary>
        private static string CheckSentiment(string input, string userName)
        {
            foreach (string word in _worriedWords)
            {
                if (input.Contains(word))
                {
                    string tip = _phishingTips[_random.Next(_phishingTips.Count)];
                    return $"It's completely understandable to feel that way, {userName}. " +
                           $"Cyber threats can be scary, but knowledge is your best defence!\n\n" +
                           $"Here's a tip to help ease your worry:\n{tip}";
                }
            }

            foreach (string word in _frustratedWords)
            {
                if (input.Contains(word))
                {
                    return $"I hear you, {userName} — cybersecurity can feel overwhelming at first. " +
                           "Let's take it one step at a time. 💪\n\n" +
                           "Start with the basics: make sure your passwords are strong and unique, " +
                           "and enable 2FA on your most important accounts.";
                }
            }

            foreach (string word in _curiousWords)
            {
                if (input.Contains(word) && !input.Contains("tell me more"))
                {
                    return $"Love the curiosity, {userName}! 🔍 Ask me about any specific topic — " +
                           "password safety, phishing, safe browsing, malware, or social engineering.";
                }
            }

            return null; // No sentiment detected
        }

        /// <summary>Stores user interest in memory</summary>
        private static string HandleMemoryStorage(string input, string userName)
        {
            string topic = "";

            if (input.Contains("password")) topic = "password safety";
            else if (input.Contains("phishing")) topic = "phishing";
            else if (input.Contains("privacy")) topic = "privacy";
            else if (input.Contains("browsing")) topic = "safe browsing";
            else if (input.Contains("malware") || input.Contains("virus")) topic = "malware";
            else if (input.Contains("scam")) topic = "scams";

            if (!string.IsNullOrEmpty(topic))
            {
                StoreMemory("interest", topic);
                _lastTopic = topic.Split(' ')[0]; // store first word as last topic
                return $"Got it, {userName}! I'll remember that you're interested in {topic}. " +
                       $"It's a crucial part of staying safe online. 🔒\n\n" +
                       $"Here's something relevant to {topic} for you right away:\n" +
                       GetResponse(topic, userName);
            }

            return $"Thanks for sharing that, {userName}! I'll keep that in mind as we chat.";
        }

        /// <summary>Recalls stored memory about the user</summary>
        private static string HandleMemoryRecall(string userName)
        {
            if (_userMemory.Count == 0)
                return $"I don't have anything stored about you yet, {userName}. " +
                       "Tell me what topics you're interested in and I'll remember!";

            string memories = $"Here's what I remember about you, {userName}:\n";
            foreach (var entry in _userMemory)
            {
                memories += $"• {entry.Key}: {entry.Value}\n";
            }
            return memories;
        }

        /// <summary>Stores a key-value pair in user memory</summary>
        public static void StoreMemory(string key, string value)
        {
            _userMemory[key] = value;
        }

        /// <summary>Resets memory and topic tracking (call on new session)</summary>
        public static void ResetSession()
        {
            _userMemory.Clear();
            _lastTopic = "";
        }
    }
}