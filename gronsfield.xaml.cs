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
    /// <summary>
    /// Логика взаимодействия для winstonPage.xaml
    /// </summary>
    public partial class gronsfieldPage : Page
    {
        public gronsfieldPage()
        {
            InitializeComponent();
        }
        private static string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
        private void encryptClick(object sender, RoutedEventArgs e)
        {
            string orig_text = TextOriginal.Text.ToUpper();
            string square_key = Key.Text.ToUpper();
            var result_text = EncryptionGronsfeld(square_key, orig_text);
            //Square polib = new Square(square_key);
            //string result_text = polib.Encrypt(orig_text);
            TextEncrypted.Text = result_text.ToLower();
        }
        private void decryptClick(object sender, RoutedEventArgs e)
        {
            string orig_text = TextEncrypted.Text.ToUpper();
            string square_key = Key.Text.ToUpper();
            var grons = new gronsfieldPage();
            var result_text = Decryption(square_key, orig_text);
            //Square polib = new Square(square_key);
            //string result_text = polib.Decrypt(orig_text);
            TextDecrypted.Text = result_text.ToLower();
        }


        public static string EncryptionGronsfeld(string key, string text)
        {
            text = text.ToLower();
            string ciphertext = null;
            string fullKey = СreateFullKey(key, text);
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (text[i] == Alphabet[j])
                    {
                        var offset = j + Convert.ToInt32(fullKey[i]) - 48;
                        offset = CalculationOffset(offset);
                        if (offset < 0) { offset = 31; }
                        ciphertext += Convert.ToString(Alphabet[offset]);
                    }
                }

            }
            return ciphertext;
        }

        private static string СreateFullKey(string key, string inputText)
        {
            while (key.Length < inputText.Length)
            {
                key += key;
            }
            if (key.Length > inputText.Length)
            {
                key = key.Substring(0, key.Length - (key.Length - inputText.Length));
            }
            
            return key;
        }

        private static int CalculationOffset(int iputOffset)
        {
            while (iputOffset >= Alphabet.Length)
            {
                iputOffset = iputOffset - Alphabet.Length;
            }
            return iputOffset;
        }

        public static string Decryption(string key, string text)
        {
            text = text.ToLower();
            string decipheredText = null;
            string fullKey = СreateFullKey(key, text);
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (text[i] == Alphabet[j])
                    {
                        var offset = j - Convert.ToInt32(fullKey[i]) + '0';
                        
                        
                        if (offset < 0) { offset = 33 + offset;  }
                        
                        offset = CalculationOffset(offset);
                        

                        decipheredText += Convert.ToString(Alphabet[offset]);
                    }
                }

            }
            return decipheredText;
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
