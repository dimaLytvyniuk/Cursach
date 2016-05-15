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
            n = Convert.ToInt32(textBoxN.Text);
            max = Convert.ToInt32(textBoxMax.Text);
            min=
        }
 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Res_Click(object sender, RoutedEventArgs e)
        {
            Main_Sort sort = new Main_Sort();
            sort.GenerateFiles();
            sort.CreateNature();
            sort.Create_Merge();
            sort.CreateMulti();
        }
    }
}
