using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
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
using System.IO;
using System.Threading;
using System.Drawing;
using System.Timers;
using ZedGraph;
namespace WpfApplication1
{


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {

            InitializeComponent();
            if (SS.Text == "")
                Pusk.IsEnabled = false;
            else Pusk.IsEnabled = true;
            but1.IsChecked = true;

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Pusk_Click(object sender, RoutedEventArgs e)
        {
            if ((but1.IsChecked == false) && (but2.IsChecked == false) && (but3.IsChecked == false))
                but1.IsChecked = true;
            massiv();
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pusk.IsEnabled = true;
            switch (SS.SelectedIndex)
            {
                case (0):
                    S.Content = "  Дан массив из 10 чисел. Сколько элементов массива \nбольше своих «соседей»,­ т.е. предыдущег­о и \nпоследующе­го. Первый и  последний элементы \nне рассматрив­ать. ";
                    break;
                case (1):
                    S.Content = "Для массива из 10 чисел найти номер первого элемента, \nбольшего 25. ";
                    break;
                case (2):
                    S.Content = "В массиве из 10 чисел найти сумму элементов больших, \nчем второй элемент этого массива";
                    break;
                case (3):
                    S.Content = "Определить­, превосходи­т ли первый элемент массива из \nдесяти чисел среднее значение элементов этого \nмассива.";
                    break;
                case (4):
                    S.Content = "Дан массив из 10 чисел. Определить­ сколько раз меняется \nзнак у его элементов.";
                    break;
                case (5):
                    S.Content = "Найти, сколько   элементов массива из 10 чисел больше, \nчем четвертый элемент этого массива.";
                    break;
                case (6):
                    S.Content = "Найти сумму элементов массива из 10 чисел, меньших, \nчем 21.";
                    break;
                case (7):
                    S.Content = "Дан массив из 10 чисел. Увеличить на единицу значения \nвсех элементов кратных 5.";
                    break;
                case (8):
                    S.Content = "Для массива из 10 целых чисел подчитать сумму элементов,­ \nзначения которых не кратны 3.";
                    break;
                case (9):
                    S.Content = "Для массива из десяти чисел подсчитать­, сколько чисел \nменьше первого элемента массива и одновремен­но больше последнего­ элемента.";
                    break;
                case (10):
                    S.Content = "Дан массив из 10 чисел. Подсчитать­ количество­ не \nотрицатель­ных nэлементов массива.";
                    break;
                case (11):
                    S.Content = "Дан массив из 10 разных чисел. Найти элемент, \nменьше всего отличающий­ся от второго. Указание: \nфункция абсолютной­ величины – ABS.";
                    break;
                case (12):
                    S.Content = "Дан массив из 10 чисел. Подсчитать­ количество­ не \nнулевых элементов массива.";
                    break;
                case (13):
                    S.Content = "В массиве из 10 целых чисел подсчитать­ количество­ \nэлементов,­ кратных 3.";
                    break;
                case (14):
                    S.Content = "Найти сумму элементов массива из 10 чисел, меньших, \nчем 5-й элемент этого массива.";
                    break;
                case (15):
                    S.Content = "Отобразить массив виде гистораммы.";
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult lol = MessageBox.Show("вы уверены", "подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.None);
            if (lol == MessageBoxResult.OK) this.Close();
        }
        void massiv()
        {
            int[] array = new int[10];
            int N, M;

            if (but1.IsChecked == true)
            {

                Random Rand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    array[i] = Rand.Next(-100, 100);
                }
                vibor(array);
            }
            else
            {
                if (but2.IsChecked == true)
                {
                    if ((min.Text != "") && (max.Text != ""))
                    {
                        N = Convert.ToInt32(min.Text);
                        M = Convert.ToInt32(max.Text);
                        Random Rand = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            array[i] = Rand.Next(N, M);
                        }
                        vibor(array);
                    }

                    else
                    {
                        MessageBoxResult lol = MessageBox.Show("Поле ввода пусты.", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    }
                }
                else
                {
                    var inputString = File.ReadAllText(FELE());

                    var strNumbers = inputString.Split();
                    var numbers = new List<int>();

                    if (numbers != null)
                    {
                        numbers.AddRange(strNumbers.Select(number => Int32.Parse(number)));
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        array[i] = numbers[i];
                    }
                    vibor(array);
                }
            }

        }

        void vibor(int[] array)
        {
            string vib = SS.Text;
            switch (vib)
            {
                case ("1"):
                    OneZadan(array);
                    break;
                case ("2"):
                    twoZadan(array);
                    break;
                case ("3"):
                    triZadan(array);
                    break;
                case ("4"):
                   
                    break;
                case ("5"):
                    
                    break;
                case ("6"):
                    sixZadan(array); 
                    break;
                case ("7"):
                    sevenZadan(array);
                    break;
                case ("8"):
                    etZadan(array);
                    break;
                case ("9"):
                    niynZadan(array);
                    break;
                case ("10"):
                    tenZadan(array);
                    break;
                case ("11"):
                    
                    break;
                case ("12"):
                    
                    break;
                case ("13"):
                   
                    break;
                case ("14"):
                    
                    break;
                case ("15"):
                    
                    break;
                case ("16"):
                    
                    break;
            }
        }

        void Pasd(string s)
        {

            StreamReader F = File.OpenText(s);
            string read = null;
            while ((read = F.ReadLine()) != null)
            {
                Console.WriteLine(read);
            }
            F.Close();
        }
        void OneZadan(int[] arr)
        {
            otvet.Text = "Массив:";
            for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";
            }

            int temp1, temp2, n = 0;
            for (int i = 1; i < 9; i++)
            {
                temp1 = arr[i - 1];
                temp2 = arr[i + 1];
                if (temp1 < arr[i])
                    if (temp2 < arr[i]) n += 1;
            }
            otvet.Text += "\n ответ:" + n;
        }
      
        private void S_TextChanged(object sender, TextChangedEventArgs e)
        {


        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
        void file()
        {

        }

        string FELE()
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Текстовый документ|*.txt";


            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {

                return (dlg.FileName);

            }
            return ("");
        }


        private void button_Click_1(object sender, RoutedEventArgs e)
        {

        }


        private void but1_Checked(object sender, RoutedEventArgs e)
        {
            PR();

        }

        private void but2_Checked(object sender, RoutedEventArgs e)
        {
            PR();

        }

        private void but3_Checked(object sender, RoutedEventArgs e)
        {
            PR();
        }
        void PR()
        {
            if (but3.IsChecked == true) { PO.Text = 3.ToString(); max.IsEnabled = false; min.IsEnabled = false; ZZ.IsEnabled = false; XX.IsEnabled = false; }
            else if (but2.IsChecked == true) { PO.Text = 2.ToString(); max.IsEnabled = true; min.IsEnabled = true; ZZ.IsEnabled = true; XX.IsEnabled = true; }
            else { PO.Text = 1.ToString(); max.IsEnabled = false; min.IsEnabled = false; ZZ.IsEnabled = false; XX.IsEnabled = false; }
            }

        void twoZadan(int[] arr)
        {
            otvet.Text = "Массив:";
            for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";
            }
            for (int i = 0; i < 10; i++)
            {
                if (arr[i] > 25) { otvet.Text += "\n Ответ:" + (i + 1); break; }
            }
        }
        void triZadan(int[] arr)
        {
            otvet.Text = "Массив:"; for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";
            }
            otvet.Text += "\n Ответ:";
            for (int j = 0; j < 9; j++)
                for (int i = j + 1; i < 10; i++)
                {
                    if (arr[1] < (arr[j] + arr[i])) otvet.Text += arr[j] + "+" + arr[i] + "=" + (arr[j] + arr[i] + "; ");
                }
        }





























        void sixZadan(int[] arr)
        {
            otvet.Text = "Массив:"; for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";
            }
            otvet.Text += "\n Ответ";
            for (int i = 0; i < 10; i++)
            {
                if (arr[i] > arr[3]) otvet.Text += " " + arr[i] + "; ";
            }

        }
        void sevenZadan(int[] arr)
        {
            otvet.Text = "Массив:"; for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";
            }
            otvet.Text += "\n Ответ:";
            int temp;
            for (int j = 0; j < 9; j++)
                for (int i = j + 1; i < 10; i++)
                {

                    if (21 > (arr[j] + arr[i])) otvet.Text += arr[j] + "+" + arr[i] + "=" + (arr[j] + arr[i] + "; ");
                }
        }
        void etZadan(int[] arr)
        {
            otvet.Text = "Массив:"; for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";
                if (arr[i] % 5 == 0) arr[i] += 1;
            }
            otvet.Text += "\n Ответ:";
            for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";

            }
        }
        void niynZadan(int[] arr)
        {
            otvet.Text = "Массив:"; for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";

            }
            otvet.Text += "\n Ответ:";
            int temp = 0;
            for (int i = 0; i < 10; i++)
            {
                if (arr[i] % 3 != 0)
                {
                    if (temp == 0) otvet.Text += arr[i];
                    temp += arr[i];
                    otvet.Text += "+" + arr[i];
                }

            }
            otvet.Text += " = " + temp;

        }
        void tenZadan(int[] arr)
        {
            otvet.Text = "Массив:"; for (int i = 0; i < 10; i++)
            {
                otvet.Text += arr[i] + " ";

            }
            otvet.Text += "\n Ответ:";
            int temp = 0;
            for (int i = 1; i < 9; i++)
            {
                if ((arr[0] > arr[i]) && (arr[9] < arr[i])) { otvet.Text += arr[i] + " "; temp += 1; }

            }
            otvet.Text += "; \n" + temp + " элементов";
        }


    }



}
