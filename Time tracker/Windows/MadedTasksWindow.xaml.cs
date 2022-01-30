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
using Time_tracker.Contexts;
using Time_tracker.Models;

namespace Time_tracker.Windows
{
    /// <summary>
    /// Логика взаимодействия для MadedTasksWindow.xaml
    /// </summary>
    public partial class MadedTasksWindow : Window
    {
        private readonly TodoDbContext _todoDbContext;
        public MadedTasksWindow()
        {
            InitializeComponent();
            _todoDbContext = new TodoDbContext();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<MadedTask> madedTasks = _todoDbContext.MadedTasks.ToList();

            madedTaskGrid.ItemsSource = madedTasks;
        }
    }
}
