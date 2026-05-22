using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace CyberSecurityChatBot
{
    public partial class MainWindow : Window
    {
        private string _userName = "User";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Step 1: Play voice greeting
            PlayVoiceGreeting();

            // Step 2: Ask for the user's name
            NamePromptDialog dialog = new NamePromptDialog();
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _userName = dialog.EnteredName;
            }
            else
            {
                // If they close the dialog without a name, shut the app
                Application.Current.Shutdown();
                return;
            }

            AddBotMessage($"Hello, {_userName}! Welcome to your Cybersecurity Awareness Assistant. 🛡");
            AddBotMessage("I'm here to help you stay safe online. You can ask me about:");
            AddBotMessage("• Password Safety\n• Phishing Scams\n• Safe Browsing\n• Suspicious Links\n• Malware & Viruses\n• Social Engineering & Scams");
            AddBotMessage("Type your question below and press Enter or click Send!");
        }
        private void PlayVoiceGreeting()
        {
            try
            {
                // Look for greeting.wav next to the exe
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
                if (File.Exists(path))
                {
                    SoundPlayer player = new SoundPlayer(path);
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                // Don't crash the app if audio fails — just skip it
                Console.WriteLine("Audio error: " + ex.Message);
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
                return;

            // Show what the user typed
            AddUserMessage(input);
            UserInputBox.Clear();

            // Get response from the engine
            string response = ResponseEngine.GetResponse(input, _userName);
            AddBotMessage(response);

            // If user said bye, disable input
            if (input.ToLower() == "exit" || input.ToLower() == "quit" || input.ToLower() == "bye")
            {
                UserInputBox.IsEnabled = false;
                SendButton.IsEnabled = false;
            }
        }

        private void UserInputBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                SendButton_Click(sender, e);
        }

        // ── Chat bubble helpers ──────────────────────────────────────

        /// <summary>Adds a user message bubble (right-aligned, teal)</summary>
        public void AddUserMessage(string message)
        {
            // Outer border acts as the bubble
            var border = new System.Windows.Controls.Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0, 60, 50)),
                CornerRadius = new CornerRadius(12, 2, 12, 12),
                Margin = new Thickness(80, 4, 8, 4),
                Padding = new Thickness(12, 8, 12, 8),
                HorizontalAlignment = HorizontalAlignment.Right,
                MaxWidth = 550
            };

            var tb = new System.Windows.Controls.TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 204)),
                FontSize = 13,
                TextWrapping = TextWrapping.Wrap
            };

            border.Child = tb;
            ChatPanel.Children.Add(border);
            ChatScroller.ScrollToBottom();
        }

        /// <summary>Adds a bot message bubble (left-aligned, light blue)</summary>
        public void AddBotMessage(string message)
        {
            // Wrapper holds the icon + bubble side by side
            var wrapper = new System.Windows.Controls.StackPanel
            {
                Orientation = System.Windows.Controls.Orientation.Horizontal,
                Margin = new Thickness(8, 4, 80, 4),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            // Bot icon label
            var icon = new System.Windows.Controls.TextBlock
            {
                Text = "🤖",
                FontSize = 16,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 4, 6, 0)
            };

            // Bubble border
            var border = new System.Windows.Controls.Border
            {
                Background = new SolidColorBrush(Color.FromRgb(17, 17, 50)),
                CornerRadius = new CornerRadius(2, 12, 12, 12),
                Padding = new Thickness(12, 8, 12, 8),
                BorderBrush = new SolidColorBrush(Color.FromRgb(42, 42, 90)),
                BorderThickness = new Thickness(1),
                MaxWidth = 550
            };

            // Split message on newlines — each line gets its own TextBlock
            var innerStack = new System.Windows.Controls.StackPanel();
            string[] lines = message.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // First line gets the "CyberBot:" prefix styling
                if (i == 0)
                {
                    var firstLine = new System.Windows.Controls.StackPanel
                    {
                        Orientation = System.Windows.Controls.Orientation.Horizontal
                    };

                    var prefix = new System.Windows.Controls.TextBlock
                    {
                        Text = "CyberBot:  ",
                        Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 204)),
                        FontSize = 13,
                        FontWeight = FontWeights.SemiBold
                    };

                    var content = new System.Windows.Controls.TextBlock
                    {
                        Text = line,
                        Foreground = new SolidColorBrush(Color.FromRgb(126, 184, 247)),
                        FontSize = 13,
                        TextWrapping = TextWrapping.Wrap
                    };

                    firstLine.Children.Add(prefix);
                    firstLine.Children.Add(content);
                    innerStack.Children.Add(firstLine);
                }
                else
                {
                    // Subsequent lines — indented to align under the message
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var tb = new System.Windows.Controls.TextBlock
                        {
                            Text = line,
                            Foreground = new SolidColorBrush(Color.FromRgb(126, 184, 247)),
                            FontSize = 13,
                            TextWrapping = TextWrapping.Wrap,
                            Margin = new Thickness(0, 2, 0, 0)
                        };
                        innerStack.Children.Add(tb);
                    }
                    else
                    {
                        // Empty line = small spacer
                        innerStack.Children.Add(new System.Windows.Controls.TextBlock
                        { Margin = new Thickness(0, 4, 0, 0) });
                    }
                }
            }

            border.Child = innerStack;
            wrapper.Children.Add(icon);
            wrapper.Children.Add(border);
            ChatPanel.Children.Add(wrapper);
            ChatScroller.ScrollToBottom();
        }
    }
}