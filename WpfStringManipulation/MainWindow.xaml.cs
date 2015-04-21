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

namespace WpfStringManipulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //remove punctuation and capitalisation from given string
        public string cleanString(string input)
        {
            //TODO: solve the apostrophe problem
            string str = input.Trim().ToLower();

            if (str.Contains("."))
            {
                str = str.Replace(".", " ");
            }
            if (str.Contains(","))
            {
                str = str.Replace(",", " ");
            }
            if (str.Contains(";"))
            {
                str = str.Replace(";", " ");
            }
            if (str.Contains(":"))
            {
                str = str.Replace(":", " ");
            }
            if (str.Contains("?"))
            {
                str = str.Replace("?", " ");
            }
            if (str.Contains("!"))
            {
                str = str.Replace("!", " ");
            }
            if (str.Contains("("))
            {
                str = str.Replace("(", " ");
            }
            if (str.Contains(")"))
            {
                str = str.Replace(")", " ");
            }

            if (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }

            return str;
        }

        //transform string into array
        public string[] strToArray(string input)
        {
            string str = cleanString(input);
            char[] charSeparators = new char[] { ' ' };
            string[] arr = str.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            return arr;

        }

        //reverse a word
        //used for Palindrome
        //TODO: move it to palindrome check if no other function uses it
        public string Reverse(string text)
        {
            if (text == null) return null;

            // this was posted by petebob as well 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        #region Button Events
        private void wordCount_Button_Click(object sender, RoutedEventArgs e)
        {
            result_TextBox.Text = "The text contains " + strToArray(initialString_TextBox.Text).Length.ToString() + " words.";
        }

        private void Palindrome_Count_Click(object sender, RoutedEventArgs e)
        {
            string[] words = strToArray(initialString_TextBox.Text);
            int counter = 0;
            StringBuilder resultSb = new StringBuilder();
            foreach (var item in words)
            {
                string reversedStr = Reverse(item);
                if (item.Equals(reversedStr))
                {
                    counter += 1;
                    resultSb.Append(item + ", ");
                }
            }

            if (counter == 1)
            {
                result_TextBox.Text = "There is " + counter.ToString() + " palindrome in the text:" + Environment.NewLine + resultSb.Remove(resultSb.Length - 2, 2);
            }
            else if (counter > 1)
            {
                result_TextBox.Text = "There are " + counter.ToString() + " palindromes in the text:" + Environment.NewLine + resultSb;

            }
            else
            {
                result_TextBox.Text = "There are no palindromes in the text";
            }

        }

        private void findWord_Button_Click(object sender, RoutedEventArgs e)
        {
            string[] words = strToArray(initialString_TextBox.Text);
            string searchTerm = searchTerm_TextBox.Text.Trim();
            int counter = 0;

            foreach (var item in words)
            {
                if (item.Equals(searchTerm))
                {
                    counter += 1;
                }
            }

            if (counter == 1)
            {
                result_TextBox.Text = counter + " instance of '" + searchTerm + "' was found.";

            }
            else if (counter > 1)
            {
                result_TextBox.Text = counter + " instances of '" + searchTerm + "' were found.";

            }
            else
            {
                result_TextBox.Text = "No Match!";
            }


        }




        #endregion

        //enable buttons that require a search term
        private void searchTerm_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            findWord_Button.IsEnabled = true;
        }




















    }//end of class
}
