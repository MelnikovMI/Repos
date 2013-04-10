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
using System.Windows.Shapes;
using System.Collections;
using Microsoft.Win32;
using System.Windows.Controls.DataVisualization.Charting;

namespace lab3_7
{
    /// <summary>
    /// Логика взаимодействия для Gistogramma.xaml
    /// </summary>
    public partial class Gistogramma : Window
    {
        public Gistogramma(int itemCount, ArrayList myAL)
        {
            InitializeComponent();
            showColumnChart(itemCount, myAL);
        }

        private void showColumnChart(int itemCount, ArrayList myAL)
        {
            int index, maxEl, minEl, prirost, nextChislo, prevChislo, kolich, j;
            maxEl = Convert.ToInt32(myAL[0]);
            minEl = Convert.ToInt32(myAL[0]);
            for (index = 1; index < itemCount; index++)
            {
                if (Convert.ToInt32(myAL[index]) > maxEl) maxEl = Convert.ToInt32(myAL[index]);
                else if (Convert.ToInt32(myAL[index]) < minEl) minEl = Convert.ToInt32(myAL[index]);
            }
            prirost = Convert.ToInt32(Math.Truncate(Convert.ToDouble((maxEl - minEl) / itemCount))) + 1;
            prevChislo = minEl;
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            for (j = 0; j < itemCount; j++)
            {
                nextChislo = prevChislo + prirost;
                kolich = 0;
                for (index = 0; index < itemCount; index++)
                {
                    if (Convert.ToInt32(myAL[index]) >= prevChislo && Convert.ToInt32(myAL[index]) < nextChislo) kolich += 1;
                }
                valueList.Add(new KeyValuePair<string, int>(Convert.ToString(prevChislo) + " - " + Convert.ToString(nextChislo), kolich));
                prevChislo = nextChislo;
            }
            columnChart.DataContext = valueList;
        }
    }
}
