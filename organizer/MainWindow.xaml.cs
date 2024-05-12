using organizer.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task = organizer.Models.Task;

namespace organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Я так поняла сюда запихивать штуки так что запихнула.

            Update();
            
        }

        public void Update()
        {
            View_TaskList.Children.Clear();

            foreach (Task tsk in MANUALDATA.tsklst)
            {
                PlainTaskPlate taskPlate = new PlainTaskPlate();
                taskPlate.RepresentedTask = tsk;
                View_TaskList.Children.Add(taskPlate);
                taskPlate.Update();
            }
            foreach (RepeatableTask tsk in MANUALDATA.reptsklst)
            {
                RepeatableTaskPlate taskPlate = new RepeatableTaskPlate();
                taskPlate.RepresentedTask = tsk;
                View_TaskList.Children.Add(taskPlate);
                taskPlate.Update();
            }

            //using (OrganizerDbContext dbContext = new OrganizerDbContext())
            //{
            //    foreach (Task task in dbContext.Tasks)
            //    {
            //        PlainTaskPlate taskPlate = new PlainTaskPlate();
            //        taskPlate.RepresentedTask = task;
            //        View_TaskList.Children.Add(taskPlate);
            //        taskPlate.Update();
            //    }

            //    foreach (RepeatableTask task in dbContext.RepeatableTasks)
            //    {
            //        RepeatableTaskPlate taskPlate = new RepeatableTaskPlate();
            //        taskPlate.RepresentedTask = task;
            //        View_TaskList.Children.Add(taskPlate);
            //        taskPlate.Update();
            //    }
            //}
        }

        /* private void Btn_AddTask_Click(object sender, RoutedEventArgs e)
         {
             // ОБЕРНУТЬ ВСЕ В TRY CATCH
             // ПРОВЕРКИ ВНУТРИ БДШКИ
             // Проверка Lbl_Name.Text 
             if (!string.IsNullOrEmpty(Lbl_Name.Text))
             {
                 using (var dbContext = new OrganizerDbContext())
                 {
                     Task newTask = new Task { Name = Lbl_Name.Text, Status = "мда" };
                     CONSOLE.Text = newTask.Name;
                     dbContext.Tasks.Add(newTask);
                     dbContext.SaveChanges();
                 }
             }
    }*/

        private void Btn_AccountPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_MainPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ListPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskCreateWindow editWind = new TaskCreateWindow(this);
            editWind.Show();
        }
    }
}