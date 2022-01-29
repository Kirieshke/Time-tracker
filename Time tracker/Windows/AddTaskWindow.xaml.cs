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
    /// Логика взаимодействия для AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        private readonly TodoDbContext _todoDbContext;
        public AddTaskWindow()
        {
            _todoDbContext = new TodoDbContext();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _todoDbContext.Todoes.Add(
               new Todo
               {
                   Text = TaskNameTb.Text,
                   Description = DescTb.Text,
                   Deadline = CalendarItem.SelectedDate
               }
               );
            _todoDbContext.SaveChanges();
        }
    }
}
