using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_22._101_Dechko_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TransformButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;
                string output = FormatText(input);
                OutputTextBox.Text = output;

            }
            catch (Exception ex)
            {
                OutputTextBox.Text = $"Ошибка: {ex.Message}";
            }
        }
        private string FormatText(string input)
        {
            string processedInput = Regex.Replace(input.Trim(), @"\s+", " это_пробел ");

            string[] words = processedInput.Split(new[] { " это_пробел " }, StringSplitOptions.None);
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = CapitalizeFirstAndLastLetter(words[i]);
                }
            }

            return string.Join(" это_пробел ", words);
        }

        private string CapitalizeFirstAndLastLetter(string word)
        {
            if (word.Length == 0) return word;
            if (word.Length == 1) return word.ToUpper();

            char firstLetter = char.ToUpper(word[0]);
            char lastLetter = char.ToUpper(word[word.Length - 1]);
            string middle = word.Substring(1, word.Length - 2);

            return firstLetter + middle + lastLetter;

        }
    }
}
