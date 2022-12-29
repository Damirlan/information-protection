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
    /// Логика взаимодействия для polibPage.xaml
    /// </summary>
    public partial class polibPage : Page
    {

        public polibPage()
        {
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
        private void encryptClick(object sender, RoutedEventArgs e)
        {
            string orig_text = TextOriginal.Text.ToUpper();
            string square_key = Key.Text.ToUpper();
            var polybius = new polibPage();
            var result_text = polybius.PolibiusEncrypt(orig_text, square_key);
            //Square polib = new Square(square_key);
            //string result_text = polib.Encrypt(orig_text);
            TextEncrypted.Text = result_text.ToLower();
        }
        private void decryptClick(object sender, RoutedEventArgs e)
        {
            string orig_text = TextEncrypted.Text.ToUpper();
            string square_key = Key.Text.ToUpper();
            var polybius = new polibPage();
            var result_text = polybius.PolybiusDecrypt(orig_text, square_key);
            //Square polib = new Square(square_key);
            //string result_text = polib.Decrypt(orig_text);
            TextDecrypted.Text = result_text.ToLower();
        }


        char[,] square;
        string alphabet;
        char[,] GetSquare(string key)
        {
            alphabet = alphabet ?? "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            var newAlphabet = alphabet;

            //удаляем из алфавита все символы которые содержит ключ
            for (int i = 0; i < key.Length; i++)
            {
                newAlphabet = newAlphabet.Replace(key[i].ToString(), "");
            }

            //добавляем пароль в начало алфавита, а в конец дополнительные знаки
            //для того чтобы избежать пустых ячеек
            newAlphabet = key + newAlphabet + "0123456789!@#$%^&*)_+-=<>?,.";

            //получаем размер стороны квадрата
            //округлением квадратного корня в сторону большего целого числа

            //создаем и заполняем массив
            square = new char[6, 6];
            var index = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (index < newAlphabet.Length)
                    {
                        square[i, j] = newAlphabet[index];
                        index++;
                    }
                }
            }
            return square;
        }

        //поиск символа в двухмерном массиве
        bool FindSymbol(char[,] symbolsTable, char symbol, out int column, out int row)
        {
            var l = symbolsTable.GetUpperBound(0) + 1;
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (symbolsTable[i, j] == symbol)
                    {
                        //значение найдено
                        row = i;
                        column = j;
                        return true;
                    }
                }
            }

            //если ничего не нашли
            row = -1;
            column = -1;
            return false;
        }

        public string PolibiusEncrypt(string text, string password)
        {
            var outputText = "";
            var square = GetSquare(password);
            /*switch (encryptMethod)
            {
                case Method.Method1:*/
            for (int i = 0; i < text.Length; i++)
            {
                if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                {
                    var newRowIndex = rowIndex == square.GetUpperBound(1)
                        ? 0
                        : rowIndex + 1;
                    outputText += square[newRowIndex, columnIndex].ToString();
                }
            }
            //break;
            /*
                            case Method.Method2:
                                var m = text.Length;
                                var coordinates = new int[m * 2];
                                for (int i = 0; i < m; i++)
                                {
                                    if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                                    {
                                        coordinates[i] = columnIndex;
                                        coordinates[i + m] = rowIndex;
                                    }
                                }

                                for (int i = 0; i < m * 2; i += 2)
                                {
                                    outputText += square[coordinates[i + 1], coordinates[i]];
                                }
                                break;
            */
            //}

            return outputText;
        }

        public string PolybiusDecrypt(string text, string password)
        {
            var outputText = "";
            var square = GetSquare(password);
            var m = text.Length;
            /*switch (encryptMethod)
            {
                case Method.Method1:*/
            for (int i = 0; i < m; i++)
            {
                if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                {
                    var newRowIndex = rowIndex == 0
                        ? square.GetUpperBound(1)
                        : rowIndex - 1;
                    outputText += square[newRowIndex, columnIndex].ToString();
                }
            }
            // break;
            /*
                            case Method.Method2:
                                var coordinates = new int[m * 2];
                                var j = 0;
                                for (int i = 0; i < m; i++)
                                {
                                    if (FindSymbol(square, text[i], out int columnIndex, out int rowIndex))
                                    {
                                        coordinates[j] = columnIndex;
                                        coordinates[j + 1] = rowIndex;
                                        j += 2;
                                    }
                                }

                                for (int i = 0; i < m; i++)
                                {
                                    outputText += square[coordinates[i + m], coordinates[i]];
                                }
                                break;
                        }*/

            return outputText;
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
