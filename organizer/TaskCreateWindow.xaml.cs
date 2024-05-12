using organizer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for TaskCreateWindow.xaml
    /// </summary>
    public partial class TaskCreateWindow : Window
    {
        private string _taskType = "Plain";
        public MainWindow main;
        public TaskCreateWindow(MainWindow sender)
        {
            InitializeComponent();
            main = sender;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Txt_RepeatEvery.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                Txt_RepeatEvery.Text = Txt_RepeatEvery.Text.Remove(Txt_RepeatEvery.Text.Length - 1);
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (_taskType == "Repeatable")
            {
                RepeatableTask repTask = new()
                {
                    Name = Txt_TaskName.Text,
                    Interval = Int32.Parse(Txt_RepeatEvery.Text)
                };

                if (repTask.Name.Length < 3 || repTask.Name.Length > 20) errors += "Название задачи должно содержать от 3 до 20 символов.\n";

                if (repTask.Interval < 1 || repTask.Interval > 999) errors += "Число дней в интервале повторений должно быть не менее 1 и не более 999.\n";

                if (String.IsNullOrEmpty(Date_LastDone.Text)) errors += "Дата последнего выполнения должна быть установлена.";
                else {
                    repTask.LastDone = DateTime.Parse(Date_LastDone.Text);
                    if (repTask.LastDone > DateTime.Now) errors += "Дата последнего выполнения не может быть позже сегодняшнего дня.\n";
                    repTask.Deadline = repTask.LastDone + TimeSpan.FromDays(repTask.Interval);
                }

                if (errors != "") { MessageBox.Show(errors); return; }
                else
                {
                    using (var dbContext = new OrganizerDbContext())
                    {
                        DateTime? utcLastDone = repTask.LastDone?.ToUniversalTime();
                        DateTime? utcDeadline = repTask.Deadline?.ToUniversalTime();
                        if (utcLastDone != null)
                        {
                            repTask.LastDone = utcLastDone;
                        }
                        if (utcDeadline != null)
                        {
                            repTask.Deadline = utcDeadline;
                        }
                        dbContext.RepeatableTasks.Add(repTask);
                        dbContext.SaveChanges();
                    }
                    //Добавить reptask в наши задачи Db.Add чето там, и обновить страницу.

                    main.Update();
                    Close();
                }
            }
            else
            {
                Task newTask = new() { Name = Txt_TaskName.Text, Status = "Не завершено"};

                if (newTask.Name.Length < 3 || newTask.Name.Length > 20) errors += "Название задачи должно содержать от 3 до 20 символов.\n";
                if (_taskType == "Deadlined")
                {
                    newTask.Deadline = DateTime.Parse(Date_Deadline.Text);
                    if (newTask.Deadline < DateTime.Today) errors += "Крайний срок не может быть раньше сегодняшнего дня.";
                }
                if (errors != "") { MessageBox.Show(errors); return; }
                else
                {
                    using (var dbContext = new OrganizerDbContext())
                    {
                        DateTime? utcDeadline = newTask.Deadline?.ToUniversalTime();

                        if (utcDeadline != null)
                        {
                            newTask.Deadline = utcDeadline;
                        }
                        dbContext.Tasks.Add(newTask);
                        dbContext.SaveChanges();
                    }

                    main.Update();
                    Close();
                }
            }
        }

        private void Rb_Repeatable_Checked(object sender, RoutedEventArgs e)
        {
            _taskType = "Repeatable";
            Pnl_RepeatEvery.Visibility = Visibility.Visible;
            Pnl_LastDone.Visibility = Visibility.Visible;
            Pnl_Deadline.Visibility = Visibility.Collapsed;
        }

        private void Rb_Deadlined_Checked(object sender, RoutedEventArgs e)
        {
            _taskType = "Deadlined";
            Pnl_Deadline.Visibility = Visibility.Visible;
            Pnl_LastDone.Visibility = Visibility.Collapsed;
            Pnl_RepeatEvery.Visibility = Visibility.Collapsed;
        }

        private void Rb_Plain_Checked(object sender, RoutedEventArgs e)
        {
            _taskType = "Plain";
            if (Pnl_Deadline == null) return;
            Pnl_Deadline.Visibility = Visibility.Collapsed;
            Pnl_LastDone.Visibility = Visibility.Collapsed;
            Pnl_RepeatEvery.Visibility = Visibility.Collapsed;
        }
    }
}

