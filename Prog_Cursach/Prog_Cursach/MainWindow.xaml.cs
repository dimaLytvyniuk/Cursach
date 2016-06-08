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
using System.Diagnostics;

namespace Prog_Cursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int n = 0,//кількість елементів
            max = 0,//максимальне значення
            min = 0;//мінімальне значення

        //мітки для надання можливості використовувати кнопки
        bool canMake = false, canMergeShow = false,
            canNatureShow = false,
            canMultiShow = false,
            canMerge = false,
            canNature = false,
            canMulti = false;

        Main_Sort sort;

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            buttonStart.Cursor = Cursors.Wait;


            try {
                n = Convert.ToInt32(textBoxN.Text);//зчитування кількості елементів
                max = Convert.ToInt32(textBoxMax.Text);//зчитування максивмального елемента
                min = Convert.ToInt32(textBoxMin.Text);//зчитування мінімального елементу

                if (min > max)//якщо мінімальний буде більший за максимальний
                {
                    MessageBox.Show("Ви ввели не коректні дані, повторіть запис", "Error");
                }
                else
                {
                    if (n > 0 && n < 20000000)
                    {
                        sort = new Main_Sort(n, max, min);
                        canMake = true;

                        canNature = true;
                        canMerge = true;
                        canMulti = true;

                        sort.GenerateFiles();//генерація файлу с використанням вхідних даних

                    }
                    else
                        MessageBox.Show("Ви ввели не коректні дані, повторіть запис", "Error");
                }

            }
            catch(Exception e1)
            {
                MessageBox.Show("Ви ввели не коректні дані, повторіть запис", "Error");
            }

            buttonStart.Cursor = Cursors.Arrow;
        }


        private void button_showNature_Click(object sender, RoutedEventArgs e)//демонстрація відсортованого файлу методом природнього злиття
        {
            if (canNatureShow)
                sort.ShowNature();
            else
                MessageBox.Show("Ви не виконали сортування природнім злиттям", "Error");
        }


        private void button_resMerge_Click_1(object sender, RoutedEventArgs e)//сортування методом прямого злиття
        {
            if (canMerge)
            {
                Stopwatch mergeWatch = new Stopwatch();
                button_resMerge.Cursor = Cursors.Wait;//переведення курсора в режим очікування

                mergeWatch.Start();//початок відліку часу
                sort.Create_Merge();//сортування
                mergeWatch.Stop();//зупинка відліку часу

                TimeSpan ts = mergeWatch.Elapsed;
                timeMerge.Text = String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд";//час роботи

                pereMerge.Text = sort.PereMerge.ToString();//кількість порівнянь
                porMerge.Text = sort.PorMerge.ToString();//кількість перестановок

                button_resMerge.Cursor = Cursors.Arrow;
                canMergeShow = true;
                canMerge = false;

                MessageBox.Show("Сортування прямим злиттям виконано","Message");
            }
            else
                MessageBox.Show("Ви не маєте можливість виконати сортування", "Error");
        }

        private void button_showMerge_Click(object sender, RoutedEventArgs e)//демонстрація відсортованого файлу прямим злиттям
        {
            if (canMergeShow)
                sort.ShowMerge();
            else
                MessageBox.Show("Ви не виконали сортування прямим злиттям", "Error");

        }

        private void buttonStartShow_Click(object sender, RoutedEventArgs e)//демонстрація початкового файлу
        {
            if (canMake)
                sort.ShowStart();
            else
                MessageBox.Show("Ви не згенерували файл", "Error");
        }

        private void button_resMulti_Click(object sender, RoutedEventArgs e)//сортування методом збалансованого багатошляхового злиття
        {
            if (canMulti)
            {
                Stopwatch multiWatch = new Stopwatch();
                button_resMulti.Cursor = Cursors.Wait;

                multiWatch.Start();
                sort.CreateMulti();//сортування
                multiWatch.Stop();

                TimeSpan ts = multiWatch.Elapsed;
                timeMulti.Text = String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд";

                porMulti.Text = sort.PorMulti.ToString();
                pereMulti.Text = sort.PereMulti.ToString();

                button_resMulti.Cursor = Cursors.Arrow;
                canMultiShow = true;
                canMulti = false;

                MessageBox.Show("Сортування збалансованим багатошляховим злиттям виконано", "Message");
            }
            else
                MessageBox.Show("Ви не маєте можливість виконати сортування");
        }

        private void button_showMulti_Click(object sender, RoutedEventArgs e)//демонстрація файлу відсортованого багатошляховим злиттям
        {
            if (canMultiShow)
                sort.ShowMulti();
            else
                MessageBox.Show("Ви не виконали сортування збалансованим багатошляховим злиттям", "Error");
        }

        private void button_resNature_Click(object sender, RoutedEventArgs e)//виконання сортування природнім злиттям
        {
            if (canNature)
            {
                Stopwatch natureWatch = new Stopwatch();
                button_resNature.Cursor = Cursors.Wait;

                natureWatch.Start();
                sort.CreateNature();//сортування
                natureWatch.Stop();

                TimeSpan ts = natureWatch.Elapsed;
                timeNature.Text = String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд";

                porNature.Text = sort.PorNature.ToString();
                pereNature.Text = sort.PereNature.ToString();

                button_resNature.Cursor = Cursors.Arrow;
                canNatureShow = true;
                canNature = false;

                MessageBox.Show("Сортування природнім злиттям виконано", "Message");
            }
            else
                MessageBox.Show("Ви не маєте можливість виконати сортування", "Error");
        }

        private void button_ShowRes_Click(object sender, RoutedEventArgs e)
        {

        }

        public MainWindow()
        {
 
            InitializeComponent();
            labelMax.Content ="<  2 147 483 647";
            labelMin.Content = "> -2 147 483 647";
            labelN.Content = "0  <";
            labelNmax.Content = "<  20 000 000";
            
        }

    }
}
