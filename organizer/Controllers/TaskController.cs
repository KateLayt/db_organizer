using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task = organizer.Models.Task;

//namespace organizer.Controllers
//{
//    public class TaskController : MainWindow
//    {
//        public void Add_Task(object sender, RoutedEventArgs e)
//        {
//            // Проверка Lbl_Name.Text 
//            if (!string.IsNullOrEmpty(Lbl_Name.Text))
//            {
//                using (var dbContext = new OrganizerDbContext())
//                {
//                    Task newTask = new Task { Name = Lbl_Name.Text, Status = "мда" } ;
//                    CONSOLE.Text = newTask.Name;
//                    //dbContext.Tasks.Add(newTask);
//                    //dbContext.SaveChanges();
//                }
//            }
//            else
//            {
//                // Пошел на хуй блять 
//            }
//        }
//    }
//}
