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
    /// Логика взаимодействия для StudInfoWindow.xaml
    /// </summary>
    public partial class StudInfoWindow : Window
    {

        //private List<Groups> _GroupsList;
        public IEnumerable<Groups> GroupsList { get; set; }
        public IEnumerable<Courses> CoursesList { get; set; }
        //{
        //    get
        //    {
        //        return _GroupsList;
        //    }
        //    set
        //    {
        //        _GroupsList = value;
        //    }
        //}
        public StudentInfo StudInfo { get; set; }
        public string Type = "";
        public Boolean IsReadOnly { get; set; }
        
        public StudInfoWindow(StudentInfo student, String WindowType)
        {
            InitializeComponent();
            Type = WindowType;
            StudInfo = student;
            this.DataContext = this;
            GroupsList = Core.DB.Groups.ToArray();
            CoursesList = Core.DB.Courses.ToArray();
        }
        public string WindowTitle
        {
            get
            {
                if (Type == "more")
                {
                    IsReadOnly = true;
                    SaveButton.Visibility = Visibility.Collapsed;
                    ExitButton.Visibility = Visibility.Visible;
                    GroupCombo.Visibility = Visibility.Collapsed;
                    GroupText.Visibility = Visibility.Visible;
                    CourseCombo.Visibility = Visibility.Collapsed;
                    CourseText.Visibility = Visibility.Visible;
                    return "Просмотр информации о студенте";
                }
                else if (Type == "edit")
                {
                    IsReadOnly = false;
                    SaveButton.Visibility = Visibility.Visible;
                    ExitButton.Visibility = Visibility.Collapsed;
                    GroupCombo.Visibility = Visibility.Visible;
                    GroupText.Visibility = Visibility.Collapsed;
                    CourseCombo.Visibility = Visibility.Visible;
                    CourseText.Visibility = Visibility.Collapsed;
                    return "Редактирование информации о студенте";
                }
                else
                {
                    IsReadOnly = false;
                    SaveButton.Visibility = Visibility.Visible;
                    ExitButton.Visibility = Visibility.Collapsed;
                    GroupCombo.Visibility = Visibility.Visible;
                    GroupText.Visibility = Visibility.Collapsed;
                    CourseCombo.Visibility = Visibility.Visible;
                    CourseText.Visibility = Visibility.Collapsed;
                    return "Добавление инфомации о студенте";
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (StudInfo.StudentID == 0)
                    //throw new Exception("Не Заполнено поле 'ID'");
                if (StudInfo.LastName == null)
                    throw new Exception("Не Заполнено поле 'Фамилия'");
                if (StudInfo.FirstName == null)
                    throw new Exception("Не Заполнено поле 'Имя'");
                if (StudInfo.Patronymic == null)
                    throw new Exception("Не Заполнено поле 'Отчество'");
                if (StudInfo.DateOfEnrollment == null)
                    throw new Exception("Не Заполнено поле 'Дата поступления'");
                if (StudInfo.Groups == null)
                    throw new Exception("Не Заполнено поле 'Группа'");
                if (StudInfo.Courses == null)
                    throw new Exception("Не Заполнено поле 'Курс'");
                if (StudInfo.AttestatScanNumber == 0)
                    throw new Exception("Не Заполнено поле 'Номер скана аттестата'");
                if (StudInfo.PassportNumber == null)
                    throw new Exception("Не Заполнено поле 'Номер и серия паспорта'");
                if (StudInfo.Registration == null)
                    throw new Exception("Не Заполнено поле 'Место регистрации'");
                if (StudInfo.Telephone == null)
                    throw new Exception("Не Заполнено поле 'Телефон'");

                //StudInfo = StudInfo;

                if (StudInfo.StudentID == 0) Core.DB.StudentInfo.Add(StudInfo);

                Core.DB.SaveChanges();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Last.Text = e.Key.ToString();
            if (e.Key.ToString() == "Return")
            {
                if(SaveButton.Focus())
                {
                    SaveButton_Click(sender, e);
                }
            }else if (e.Key.ToString() == "Escape")
            {
                if(ExitButton.Focus())
                {
                    ExitButton_Click(sender, e);
                }
            }
        }
    }
}
