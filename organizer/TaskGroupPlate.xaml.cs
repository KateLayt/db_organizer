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
            Txt_GroupName.Text = representedGroup.Name;
            //Txt_TaskCounter.Text = ((representedGroup.Tasks?.Count() ?? 0) + (representedGroup.RepeatableTasks?.Count() ?? 0)).ToString();
            
            // ПОДКЛЮЧЕНИЕ БД
            
            using (OrganizerDbContext dbContext = new OrganizerDbContext())
            {
                int tasks = dbContext.Tasks.Where(g => g.TaskGroup.Name == representedGroup.Name).Count();
                int repTasks = dbContext.RepeatableTasks.Where(g => g.TaskGroup.Name == representedGroup.Name).Count();
                Txt_TaskCounter.Text = (tasks + repTasks).ToString();
            }
        }

        private void Plate_Click(object sender, RoutedEventArgs e)
        {
            main.displayedGroup = representedGroup;
            main.Update();
        }
    }
}
