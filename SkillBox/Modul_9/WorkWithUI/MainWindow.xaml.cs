using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WorkWithUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void splitButton_Click(object sender, RoutedEventArgs e)
        {
            listBoxWords.Items.Clear();
            // Разбивка текста на слова и добавление их в ListBox
            var words = inputTextBox.Text.Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                listBoxWords.Items.Add(word);
            }
        }

        private void reverseButton_Click(object sender, RoutedEventArgs e)
        {
            outputTextBlock.Text = "";
            // Получение слов из ListBox и их реверс
            var words = inputTextBox.Text.Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Reverse();
            outputTextBlock.Text = string.Join(" ", words);
        }

    }
}
