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

            n = Convert.ToInt32(textBoxN.Text);
            max = Convert.ToInt32(textBoxMax.Text);
            min = Convert.ToInt32(textBoxMin.Text);

            int y = 0;
        }
 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Res_Click(object sender, RoutedEventArgs e)
        {
            label_Finish.Visibility = Visibility.Hidden;
            
            Main_Sort sort = new Main_Sort(n,max,min);
            sort.GenerateFiles();


            sort.CreateNature();

            sort.Create_Merge();



            //Stopwatch stopWatch = new Stopwatch();

            //stopWatch.Start();

            sort.CreateMulti();

            label_Finish.Visibility = Visibility.Visible;

            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;

            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);


        }
    }
}
