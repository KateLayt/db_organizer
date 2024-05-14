﻿using Microsoft.EntityFrameworkCore;
using organizer.Models;
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
using Task = organizer.Models.Task;

namespace organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TaskGroup? displayedGroup;
        private static OrganizerDbContext dbContext = new OrganizerDbContext();
        public MainWindow()
        {
            InitializeComponent();
            Update();  
        }

        public void UpdateTasks()
        {
            View_TaskList.Children.Clear();
            ICollection<Task>? tasks;
            ICollection<RepeatableTask>? reptasks;
            if (displayedGroup == null || displayedGroup.TaskGroupID == -5)
            {
                //тут можно сделать или отдельный такой список всех задач, с заранее известным айдишником
                //ну или выводить их вложенными циклами, но тогда там будет запара с плашкой
                Txt_DispListName.Text = "Все задачи";
                Txt_DispListDescription.Visibility = Visibility.Collapsed;


                // ПОДКЛЮЧЕНИЕ БД

                tasks = dbContext.Tasks.OrderBy(t => t.Deadline).ToArray();
                reptasks = dbContext.RepeatableTasks.OrderBy(t => t.Deadline).ToArray();
                
            }

            else
            {
                Txt_DispListName.Text = displayedGroup.Name;
                if (!String.IsNullOrEmpty(displayedGroup.Description))
                {
                    Txt_DispListDescription.Visibility = Visibility.Visible;
                    Txt_DispListDescription.Text = displayedGroup.Description;
                }
                else
                {
                    Txt_DispListDescription.Visibility = Visibility.Collapsed;
                }

                // ПОДКЛЮЧЕНИЕ БД

                tasks = dbContext.Tasks.Where(g => g.TaskGroupID == displayedGroup.TaskGroupID).OrderBy(t => t.Deadline).ToArray();
                reptasks = dbContext.RepeatableTasks.Where(g => g.TaskGroupID == displayedGroup.TaskGroupID).OrderBy(t => t.Deadline).ToArray();
                
                //tasks = displayedGroup.Tasks;
                //reptasks = displayedGroup.RepeatableTasks;
            }

            if (tasks != null)
            {
                foreach (Task tsk in tasks)
                {
                    PlainTaskPlate taskPlate = new PlainTaskPlate();
                    taskPlate.RepresentedTask = tsk;
                    View_TaskList.Children.Add(taskPlate);
                    taskPlate.Update();
                }
            }

            if (reptasks != null)
            {
                foreach (RepeatableTask tsk in reptasks!)
                {
                    RepeatableTaskPlate taskPlate = new RepeatableTaskPlate();
                    taskPlate.RepresentedTask = tsk;
                    View_TaskList.Children.Add(taskPlate);
                    taskPlate.Update();
                }
            }
        }

        public void UpdateLists()
        {
            View_Lists.Children.Clear();
            //foreach (TaskGroup tg in MANUALDATA.groups)
            //{
            //    TaskGroupPlate plate = new(this);
            //    plate.representedGroup = tg;
            //    View_Lists.Children.Add(plate);
            //    plate.Update();
            //}


            // ПОДКЛЮЧЕНИЕ БД

            foreach (TaskGroup taskGroup in dbContext.TaskGroups)
            {
                TaskGroupPlate plate = new(this);
                plate.representedGroup = taskGroup;
                View_Lists.Children.Add(plate);
                plate.Update();
            }
            

        }

        public void Update()
        {
            UpdateLists();
            UpdateTasks();
        }

        private void Btn_AccountPage_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Btn_MainPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ListPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddTask_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser? currentUser = dbContext.CurrentUsers.FirstOrDefault();

            if (currentUser == null)
            {
                MessageBox.Show("Сначала авторизуйтесь!");
            }
            else
            {
                TaskCreateWindow editWind = new(this, displayedGroup);
                editWind.Show();
            }
            
        }

        private void Btn_AddGroup_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser? currentUser = dbContext.CurrentUsers.FirstOrDefault();

            if (currentUser != null)
            {
                GroupCreateWindow createWind = new(this);
                createWind.Show();
            }
            else
            {
                MessageBox.Show("Сначала авторизуйтесь!");
            }
        }
        private void Btn_EditGroup_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser? currentUser = dbContext.CurrentUsers.FirstOrDefault();

            if (currentUser != null)
            {
                if (displayedGroup == null || displayedGroup.TaskGroupID < 0) { MessageBox.Show("Эту группу нельзя изменить"); return; }
                GroupEditWindow editWind = new(displayedGroup, this);
                editWind.Show();
            }
            else
            {
                MessageBox.Show("Сначала авторизуйтесь!");
            }
        }

        private void Btn_TestExit_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser? currentUser = dbContext.CurrentUsers.FirstOrDefault();

            if (currentUser != null)
            {
                dbContext.CurrentUsers.Remove(currentUser);
                dbContext.SaveChanges();
                MessageBox.Show("Вы вышли!");
            }
            else
            {
                MessageBox.Show("Сначала авторизуйтесь!");
            }
            
        }
    }
}