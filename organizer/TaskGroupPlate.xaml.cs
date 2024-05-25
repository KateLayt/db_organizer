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
using System.Windows.Navigation;
using System.Windows.Shapes;
using organizer.Models;

namespace organizer
{
    /// <summary>
    /// Interaction logic for TaskGroupPlate.xaml
    /// </summary>
    public partial class TaskGroupPlate : UserControl
    {
        public TaskGroup representedGroup;
        MainWindow main;
        public TaskGroupPlate(MainWindow sender)
        {
            if (representedGroup == null) representedGroup = MANUALDATA.tskgrp;
            main = sender;
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            
            //Txt_TaskCounter.Text = ((representedGroup.Tasks?.Count() ?? 0) + (representedGroup.RepeatableTasks?.Count() ?? 0)).ToString();
            
            // ПОДКЛЮЧЕНИЕ БД
            
            using (OrganizerDbContext dbContext = new OrganizerDbContext())
            {
                CurrentUser? currentUser = dbContext.CurrentUsers.FirstOrDefault();
                if (currentUser != null)
                {   
                    Txt_GroupName.Text = representedGroup.Name;

                    if (representedGroup.Name == "Все задачи" && representedGroup.IsBuiltin == true)
                    {
                        Txt_TaskCounter.Text = (dbContext.Tasks
                            .Where(u => u.TaskGroup.User.UserID == currentUser.UserId)
                            .Count()
                            + dbContext.RepeatableTasks
                            .Where(u => u.TaskGroup.User.UserID == currentUser.UserId)
                            .Count())
                            .ToString();
                    }
                    else
                    {
                        int tasks = dbContext.Tasks
                            .Where(u => u.TaskGroup.User.UserID == currentUser.UserId)
                            .Where(g => (g.TaskGroup.Name == representedGroup.Name))
                            .Count();
                        int repTasks = dbContext.RepeatableTasks
                            .Where(u => u.TaskGroup.User.UserID == currentUser.UserId)
                            .Where(g => g.TaskGroup.Name == representedGroup.Name)
                            .Count();
                        Txt_TaskCounter.Text = (tasks + repTasks).ToString();
                    }
                }
                else
                {
                    
                }

            }
        }

        private void Plate_Click(object sender, RoutedEventArgs e)
        {
            main.displayedGroup = representedGroup;
            main.UpdateMain();
        }
    }
}
