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

        int n = 0,
            max = 0,
            min = 0;

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            label_Finish.Visibility = Visibility.Hidden;

            try {
                n = Convert.ToInt32(textBoxN.Text);
                max = Convert.ToInt32(textBoxMax.Text);
                min = Convert.ToInt32(textBoxMin.Text);

                if (min > max)
                {
                    int y = max;
                    max = min;
                    min = max;
                }

                button_Res.Visibility = Visibility.Visible;
            }
            catch(Exception e1)
            {
                MessageBox.Show("Ви ввели не коректні дані, повторіть запис", "Error");
            }

        }
 
        public MainWindow()
        {
            InitializeComponent();
            labelMax.Content ="<  2 147 483 648";
            labelMin.Content = "> -2 147 483 648";

            label_Finish.Visibility = Visibility.Hidden;
            button_Res.Visibility = Visibility.Hidden;
            tabStatistic.Visibility = Visibility.Hidden;
            label_Statist.Visibility = Visibility.Hidden;
        }

        private void button_Res_Click(object sender, RoutedEventArgs e)
        {
            label_Finish.Visibility = Visibility.Hidden;

            Stopwatch mergeWatch = new Stopwatch(),
              natureWatch = new Stopwatch(),
              multiWatch = new Stopwatch();

            Main_Sort sort = new Main_Sort(n,max,min);

            sort.GenerateFiles();

            natureWatch.Start();
            sort.CreateNature();
            natureWatch.Stop();

            mergeWatch.Start();
            sort.Create_Merge();
            mergeWatch.Stop();

            multiWatch.Start();
            sort.CreateMulti();
            multiWatch.Stop();

            TimeSpan ts = mergeWatch.Elapsed;
            timeMerge.Text = String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд";

            ts = natureWatch.Elapsed;
            timeNature.Text = String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд";

            ts = multiWatch.Elapsed;
            timeMulti.Text= timeMerge.Text = String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд";

            label_Finish.Visibility = Visibility.Visible;
            label_Statist.Visibility = Visibility.Visible;
            tabStatistic.Visibility = Visibility.Visible;

        }
    }
}
