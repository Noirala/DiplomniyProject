using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UniversityStudentsInfo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _TotalPages = 1;
        public int TotalPages
        {
            get
            {
                _TotalPages = _StudInfo.Count() % 20;
                if (_TotalPages == 0)
                {
                    _TotalPages = _StudInfo.Count() / 20;
                    return _TotalPages;
                } else
                {
                    _TotalPages = _StudInfo.Count() / 20;
                    return _TotalPages + 1;
                }
                
            }
        }
        private int _CurrentPage = 1;
        public int CurrentPage
        {
            get
            {
                return _CurrentPage;
            }
            set
            {
                if (value > 0)
                {
                    if (_StudInfo.Count() % 20 == 0)
                    {
                        if (value <= (_StudInfo.Count() / 20))
                        {
                            _CurrentPage = value;
                            Invalidate();
                        }
                    } else
                    {
                        if (value <= (_StudInfo.Count() / 20) + 1)
                        {
                            _CurrentPage = value;
                            Invalidate();
                        }
                    }
                }
            }
        }
        public string[] SortList { get; set; } =
        {
            "Без сортировки",
            "ФИО от А до Я",
            "ФИО от Я до А",
            "Группа по убыванию",
            "Группа по возрастанию",
            "Курс по убыванию",
            "Курс по возрастанию"
        };
        
        private int SortType = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        private void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StudInfo"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPage"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalPages"));
        }

        public List<Groups> GroupsList { get; set; }
        public List<Courses> CoursesList { get; set; }

        private IEnumerable<StudentInfo> _StudInfo;
        public IEnumerable<StudentInfo> StudInfo
        {
            get
            {
                var Result = _StudInfo;

                if (SearchFilterValue != "")
                {
                    Result = Result.Where(p => p.FullName.IndexOf(SearchFilterValue,StringComparison.OrdinalIgnoreCase)>=0);
                }

                if (CoursesFilterValue != "" && CoursesFilterValue != "Все курсы")
                {
                    Result = Result.Where(p => p.Course == _CoursesFilterValue);
                }

                if (GroupsFilterValue != 0)
                {
                    Result = Result.Where(p => p.Group == _GroupsFilterValue);
                }

                switch(SortType)
                {
                    case 1:
                        Result = Result.OrderBy(p => p.FullName);
                        break;
                    case 2:
                        Result = Result.OrderByDescending(p => p.FullName);
                        break;
                    case 3:
                        Result = Result.OrderBy(p => p.Group);
                        break;
                    case 4:
                        Result = Result.OrderByDescending(p => p.Group);
                        break;
                    case 5:
                        Result = Result.OrderBy(p => p.Course);
                        break;
                    case 6:
                        Result = Result.OrderByDescending(p => p.Course);
                        break;
                }

                

                return Result.Skip((CurrentPage-1)*20).Take(20);
            }
            set
            {
                _StudInfo = value;
                Invalidate();

                
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            StudInfo = Core.DB.StudentInfo.ToList();
            GroupsList = Core.DB.Groups.ToList();
            GroupsList.Insert(0, new Groups { GroupName = "Все группы" });
            CoursesList = Core.DB.Courses.ToList();
            CoursesList.Insert(0, new Courses { ID = "Все курсы" });
            var NewLoginWindow = new LoginWindow();
            if (!(bool)NewLoginWindow.ShowDialog())
            {
                AddStudInfo.Visibility = Visibility.Collapsed;
                //EditStudInfo.Visibility = Visibility.Collapsed;
                StudInfoGrid.Columns[7].Visibility = Visibility.Collapsed;
                StudInfoGrid.Columns[5].Visibility = Visibility.Collapsed;
                StudWindow.Width = 850;
                StudWindow.MinWidth = 850;
            }
        }

        private void EditStudInfo_Click(object sender, RoutedEventArgs e)
        {
            var SelectedStudent = StudInfoGrid.SelectedItem as StudentInfo;
            var EditStudInfoWindow = new StudInfoWindow(SelectedStudent, "edit");
            if ((bool)EditStudInfoWindow.ShowDialog())
            {
                StudInfo = Core.DB.StudentInfo.ToList();
                Invalidate();
                
            }
        }

        private void MoreStudInfo_Click(object sender, RoutedEventArgs e)
        {
            var SelectedStudent = StudInfoGrid.SelectedItem as StudentInfo;
            var MoreStudInfoWindow = new StudInfoWindow(SelectedStudent, "more");
            MoreStudInfoWindow.ShowDialog();
        }

        private void AddStudInfo_Click(object sender, RoutedEventArgs e)
        {
            var NewStudInfoWndow = new StudInfoWindow(new StudentInfo(), "");
            if ((bool)NewStudInfoWndow.ShowDialog())
            {
                StudInfo = Core.DB.StudentInfo.ToList();
                Invalidate();
                
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteStudInfo_Click(object sender, RoutedEventArgs e)
        {
            var NewAccessWindow = new AcessWindow();
            if((bool)NewAccessWindow.ShowDialog())
            {
                var student = StudInfoGrid.SelectedItem as StudentInfo;
                Core.DB.StudentInfo.Remove(student);
                Core.DB.SaveChanges();
                StudInfo = Core.DB.StudentInfo.ToList();
                Invalidate();
                
            }
        }

        private void StudInfoGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var SelectedStudent = StudInfoGrid.SelectedItem as StudentInfo;
            var MoreStudInfoWindow = new StudInfoWindow(SelectedStudent, "more");
            MoreStudInfoWindow.ShowDialog();
        }

        private void SortTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortType = SortTypeComboBox.SelectedIndex;
            Invalidate();
        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage--;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage++;
        }

        private int _GroupsFilterValue = 0;
        public int GroupsFilterValue
        {
            get
            {
                return _GroupsFilterValue;
            }
            set
            {
                _GroupsFilterValue = value;
                Invalidate();
            }
        }
        private void GroupsFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupsFilterValue = (GroupsFilter.SelectedItem as Groups).ID;
        }

        private string _CoursesFilterValue = "";
        public string CoursesFilterValue
        {
            get
            {
                return _CoursesFilterValue;
            }
            set
            {
                _CoursesFilterValue = value;
                Invalidate();
            }
        }
        private void CoursesFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CoursesFilterValue = (CoursesFilter.SelectedItem as Courses).ID;
        }

        private string _SearchFilterValue = "";
        public string SearchFilterValue
        {
            get
            {
                return _SearchFilterValue;
            }
            set
            {
                _SearchFilterValue = value;
                Invalidate();
            }
        }
        private void SearchFilter_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilterValue = SearchFilter.Text;
        }

        private void Sbros_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
