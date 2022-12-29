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

namespace Encryption
{
    public partial class magicPage : Page
    {
        public magicPage()
        {
            InitializeComponent();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
        public void encrypt(object sender, RoutedEventArgs e)
        {
            int count = Numbers.Text.Length; //9
            int len = 0;
            if (count == 9)
            {
                len = 3;
            }
            int[,] defaultSquare = new int[len, len];
            char[,] encryptedText = new char[len, len];
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            int c = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    defaultSquare[i, j] = Numbers.Text[c] - '0';
                    c++;
                    encryptedText[i, j] = ' ';
                }
            }
            int index = 0;
            while (index != TextOriginal.Text.Length)
            {
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        if ((defaultSquare[i, j] == index + 1) && (index != TextOriginal.Text.Length))
                        {
                            encryptedText[i, j] = TextOriginal.Text[index];
                            index++;
                        }
                    }
                }
            }

            string s = "";
            int ij = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    ij = i + j;
                    s = encryptedText[i, j].ToString();
                    TextEncrypted.Text += s;
                }

            }
        }

        public void decrypt(object sender, RoutedEventArgs e)
        {
            string encText = TextEncrypted.Text;
            int index = 0;
            string decipheredText = null;
            string s1 = Numbers.Text;
            while (index != TextEncrypted.Text.Length)
            {
                for (int i = 0; i < 9; i++)

                    if ((s1[i] - '0' == index + 1) && (index != TextEncrypted.Text.Length))
                    {
                        decipheredText += encText[i];
                        index++;
                    }
            }
            TextDecrypted.Text = decipheredText;

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged2(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged3(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
        private void TextBox_TextChanged4(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
