using organizer.Models;
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
using Task = organizer.Models.Task;

namespace organizer
{
    /// <summary>
    /// Interaction logic for TaskEditWindow.xaml
    /// </summary>
    public partial class TaskEditWindow : Window
    {
        private Task editedTask;
        private RepeatableTask editedRepTask;
        private PlainTaskPlate plainSender;
        private RepeatableTaskPlate repeatableSender;

        public TaskEditWindow(Task task, PlainTaskPlate plate)
        {
            editedTask = task;
            plainSender = plate;
            InitializeComponent();

            Txt_TaskName.Text = task.Name;
            if (task.Deadline == null)
            {
                Pnl_Deadline.Visibility = Visibility.Collapsed;
                Pnl_LastDone.Visibility = Visibility.Collapsed;
                Pnl_RepeatEvery.Visibility = Visibility.Collapsed;
            }

            else
            {
                Pnl_Deadline.Visibility= Visibility.Visible;
                Date_Deadline.Text = task.Deadline?.ToString("dd.MM.yyyy");
                Pnl_LastDone.Visibility = Visibility.Collapsed;
                Pnl_RepeatEvery.Visibility = Visibility.Collapsed;
            }
        }

        public TaskEditWindow(RepeatableTask task, RepeatableTaskPlate plate)
        {
            editedRepTask = task;
            repeatableSender = plate;
            InitializeComponent();

            Txt_TaskName.Text = task.Name;
            Pnl_LastDone.Visibility= Visibility.Visible;
            Date_LastDone.Text = task.LastDone?.ToString("dd.MM.yyyy");
            Pnl_RepeatEvery.Visibility= Visibility.Visible;
            Txt_RepeatEvery.Text = task.Interval.ToString();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (editedRepTask != null) {
                try
                {
                    repeatableSender.Visibility = Visibility.Collapsed;
                    using (OrganizerDbContext dbContext = new OrganizerDbContext())
                    {
                        dbContext.Remove(editedRepTask);
                        dbContext.SaveChanges();
                    }
                }
                catch { }
            }
            if (editedTask != null) 
            {
                try
                {
                    plainSender.Visibility = Visibility.Collapsed;
                    using (OrganizerDbContext dbContext = new OrganizerDbContext())
                    {
                        dbContext.Remove(editedTask);
                        dbContext.SaveChanges();
                    }
                } 
                catch { }
            }
            //Здесь нужно удалить соответствующую задачу (которая вверху проверяется на null) из базы
            Close();
        }

        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (editedRepTask != null)
            {
                editedRepTask.Name = Txt_TaskName.Text;     // Не совсем поняла а зачем это тут сверху?? Для теста? 
                if (Txt_TaskName.Text.Length < 3 || Txt_TaskName.Text.Length > 20) 
                    errors += "Название задачи должно содержать от 3 до 20 символов.\n";
                else 
                    editedRepTask.Name = Txt_TaskName.Text;

                if (Int32.Parse(Txt_RepeatEvery.Text) < 1 || Int32.Parse(Txt_RepeatEvery.Text) > 999) 
                    errors += "Число дней в интервале повторений должно быть не менее 1 и не более 999.\n";
                else
                    editedRepTask.Interval = Int32.Parse(Txt_RepeatEvery.Text);

                if (String.IsNullOrEmpty(Date_LastDone.Text)) 
                    errors += "Дата последнего выполнения должна быть установлена.";
                else
                {
                    if (DateTime.Parse(Date_LastDone.Text) > DateTime.Now) errors += "Дата последнего выполнения не может быть позже сегодняшнего дня.\n";

                    // Тут ничего не было я допишу наверное должно же быть 

                    DateTime? utcLastDone = DateTime.Parse(Date_LastDone.Text).ToUniversalTime();

                    if (utcLastDone != null)
                    {
                        editedRepTask.LastDone = utcLastDone;
                        editedRepTask.Deadline = (utcLastDone + TimeSpan.FromDays(editedRepTask.Interval))?.ToUniversalTime();

                    }
                }

                if (errors != "") {
                    MessageBox.Show(errors); 
                    return; 
                }
                else
                {
                    try
                    {
                        using (OrganizerDbContext dbContext = new OrganizerDbContext())
                        {
                            RepeatableTask? taskFromDb = dbContext.RepeatableTasks.FirstOrDefault(t => t.RepeatableTaskID == editedRepTask.RepeatableTaskID);
                            if (taskFromDb != null)
                            {
                                taskFromDb.Name = editedRepTask.Name;
                                taskFromDb.Interval = editedRepTask.Interval;
                                taskFromDb.LastDone = editedRepTask.LastDone;
                                taskFromDb.Deadline = editedRepTask.Deadline;

                                dbContext.SaveChanges();
                            }

                            else 
                                errors += "Не удалось найти такую задачу в базе.\n";
                        }
                        repeatableSender.Update();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        errors += $"Ошибка при обновлении данных: {ex.Message}";
                    }
                }
                if (errors != "") { 

                    MessageBox.Show(errors); 
                    return; 
                }
            }


            // Не уверена, что это было нужно, но я написала
            
            if (editedTask != null)     // Для обычной задачи
            {
                if (Txt_TaskName.Text.Length < 3 || Txt_TaskName.Text.Length > 20)
                    errors += "Название задачи должно содержать от 3 до 20 символов.\n";
                else
                    editedTask.Name = Txt_TaskName.Text;

                if (!String.IsNullOrEmpty(Date_Deadline.Text))
                {
                    if (DateTime.Parse(Date_Deadline.Text) < DateTime.Now) errors += "Дата дедлайна не может быть раньше сегодняшнего дня.\n";

                    DateTime? utcDeadline = DateTime.Parse(Date_Deadline.Text).ToUniversalTime();

                    if (utcDeadline != null)
                    {
                        editedTask.Deadline = utcDeadline;
                    }
                }

                if (errors != "")
                {
                    MessageBox.Show(errors);
                    return;
                }
                else
                {
                    try
                    {
                        using (OrganizerDbContext dbContext = new OrganizerDbContext())
                        {
                            Task? taskFromDb = dbContext.Tasks.FirstOrDefault(t => t.TaskID == editedTask.TaskID);
                            if (taskFromDb != null)
                            {
                                taskFromDb.Name = editedTask.Name;
                                taskFromDb.Deadline = editedTask.Deadline;

                                dbContext.SaveChanges();
                            }

                            else
                                errors += "Не удалось найти такую задачу в базе.\n";
                        }
                        plainSender.Update();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        errors += $"Ошибка при обновлении данных: {ex.Message}";
                    }
                }
                if (errors != "")
                {

                    MessageBox.Show(errors);
                    return;
                }
            }
        }

    }
}
