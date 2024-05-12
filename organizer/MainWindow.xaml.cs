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

            Plate1.RepresentedTask = new RepeatableTask { Name = "Повторяемая задача 2", Status = "Ожидает выполнения", Interval = 10, LastDone = DateTime.Today };
            Plate2.RepresentedTask = new Task { Name = "Задача 3", Status = "Не завершено" };
            Plate3.RepresentedTask =  new Task { Name = "Задача со сроком", Status = "Выполняется", Deadline = new DateTime(2023, 10, 10) };
            Plate1.Update();
            Plate2.Update();
            Plate3.Update();

            // Я так поняла сюда запихивать штуки так что запихнула.

            //foreach(Task tsk in MANUALDATA.tsklst)
            //{
            //    PlainTaskPlate taskPlate = new PlainTaskPlate();
            //    taskPlate.RepresentedTask = tsk;
            //    View_TaskList.Children.Add(taskPlate);
            //    taskPlate.Update();

            //}
            Update();
            
        }

        public void Update()
        {
            using (OrganizerDbContext dbContext = new OrganizerDbContext())
            {
                foreach (Task task in dbContext.Tasks)
                {
                    PlainTaskPlate taskPlate = new PlainTaskPlate();
                    taskPlate.RepresentedTask = task;
                    View_TaskList.Children.Add(taskPlate);
                    taskPlate.Update();
                }

                foreach (RepeatableTask task in dbContext.RepeatableTasks)
                {
                    RepeatableTaskPlate taskPlate = new RepeatableTaskPlate();
                    taskPlate.RepresentedTask = task;
                    View_TaskList.Children.Add(taskPlate);
                    taskPlate.Update();
                }
            }
        }

        public void SetRepeatable(RepeatableTask newTask)
        {
            Plate1.RepresentedTask = newTask;
            Plate1.Update();
        }
        public void SetPlain(Task newTask)
        {
            Plate2.RepresentedTask = newTask;
            Plate2.Update();
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