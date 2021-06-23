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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "123456" && Password.Text=="123456")
            {
                DialogResult = true;
            }
        }

        private void LogInStudButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                if (LogInButton.Focus())
                {
                    LogInButton_Click(sender, e);
                }
            }
            else if (e.Key.ToString() == "Escape")
            {
                Exit(sender, e);
            }
        }
    }
}
