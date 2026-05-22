using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatBot
{
    public partial class NamePromptDialog : Window
    {
        // This is how MainWindow will read the name back
        public string EnteredName { get; private set; }

        public NamePromptDialog()
        {
            InitializeComponent();
            // Focus the text box immediately so the user can type right away
            Loaded += (s, e) => NameInputBox.Focus();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ValidateAndClose();
        }

        // Allow pressing Enter to confirm
        private void NameInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ValidateAndClose();
        }

        private void ValidateAndClose()
        {
            if (string.IsNullOrWhiteSpace(NameInputBox.Text))
            {
                // Show the error message, don't close
                ErrorLabel.Visibility = Visibility.Visible;
                NameInputBox.Focus();
                return;
            }

            EnteredName = NameInputBox.Text.Trim();
            DialogResult = true;
            Close();
        }
    }
}