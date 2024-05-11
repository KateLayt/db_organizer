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

        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (editedRepTask != null)
            {
                editedRepTask.Name = Txt_TaskName.Text;
                if (Txt_TaskName.Text.Length < 3 || Txt_TaskName.Text.Length > 20) errors += "Название задачи должно содержать от 3 до 20 символов.\n";
                else editedRepTask.Name = Txt_TaskName.Text; 

                if (Int32.Parse(Txt_RepeatEvery.Text) < 1 || Int32.Parse(Txt_RepeatEvery.Text) > 999) errors += "Число дней в интервале повторений должно быть не менее 1 и не более 999.\n";
                else editedRepTask.Interval = Int32.Parse(Txt_RepeatEvery.Text);

                if (String.IsNullOrEmpty(Date_LastDone.Text)) errors += "Дата последнего выполнения должна быть установлена.";
                else
                {
                    if (DateTime.Parse(Date_LastDone.Text) > DateTime.Now) errors += "Дата последнего выполнения не может быть позже сегодняшнего дня.\n";
                }

                if (errors != "") { MessageBox.Show(errors); return; }
                else
                {
                    editedRepTask.Name = Txt_TaskName.Text;
                    editedRepTask.Interval = Int32.Parse(Txt_RepeatEvery.Text);
                    editedRepTask.LastDone = DateTime.Parse(Date_LastDone.Text);
                    editedRepTask.Deadline = editedRepTask.LastDone + TimeSpan.FromDays(editedRepTask.Interval);
                    
                    repeatableSender.Update();
                    Close();
                }
            }
            else if (editedTask != null)
            {
                if (Txt_TaskName.Text.Length < 3 || Txt_TaskName.Text.Length > 20) errors += "Название задачи должно содержать от 3 до 20 символов.\n";
                if (editedTask.Deadline != null)
                {
                    if (DateTime.Parse(Date_Deadline.Text) < DateTime.Today) errors += "Крайний срок не может быть раньше сегодняшнего дня.";
                }
                if (errors != "") { MessageBox.Show(errors); return; }
                else
                {
                    editedTask.Name = Txt_TaskName.Text;
                    if (editedTask.Deadline != null)  editedTask.Deadline = DateTime.Parse(Date_Deadline.Text);

                    plainSender.Update();
                    Close();
                }
            }
        }
    }
}
