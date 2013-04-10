using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using Microsoft.Win32;

namespace lab3_7
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            int itemCount = 10;
            Random rnd1 = new Random();
            int number, kolich = 0;
            lbMain.Items.Clear();
            lbMain.Items.Add("Исходный массив");
            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
                lbMain.Items.Add(number);
            }
            for (index = 1; index < itemCount - 1; index++)
            {
                if ((Convert.ToInt32(myAL[index]) > Convert.ToInt32(myAL[index - 1])) && (Convert.ToInt32(myAL[index]) > Convert.ToInt32(myAL[index + 1]))) kolich += 1;
            }
            lbMain.Items.Add("Количество элементов массива, которые больше своих 'соседей'");
            lbMain.Items.Add(kolich);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog myDialog = new Microsoft.Win32.SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbMain.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            int index;
            int itemCount = 10;
            Random rnd1 = new Random();
            int number;
            bool flag = false;
            lbMain.Items.Clear();
            lbMain.Items.Add("Исходный массив");
            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
                lbMain.Items.Add(number);
            }
            for (index = 0; (index < itemCount) && (flag == false); index++)
            {
                if ((Convert.ToInt32(myAL[index])) > 25) flag = true;
            }
            if (flag == true)
            {
                lbMain.Items.Add("Номер первого элемента массива, значение которого больше 25(начиная с единицы)");
                lbMain.Items.Add(index);
            }
            else lbMain.Items.Add("В массиве не содержится элемент, значение которого больше 25");
        }
    }
}
