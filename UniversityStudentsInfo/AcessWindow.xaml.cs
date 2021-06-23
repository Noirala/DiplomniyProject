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
using System.Windows.Shapes;

namespace UniversityStudentsInfo
{
    /// <summary>
    /// Логика взаимодействия для AcessWindow.xaml
    /// </summary>
    public partial class AcessWindow : Window
    {
        public AcessWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
