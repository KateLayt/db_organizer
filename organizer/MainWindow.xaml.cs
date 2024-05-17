using Microsoft.EntityFrameworkCore;
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
        public User? currentUser;
        public User? selectedFriend;

        // ПОДКЛЮЧЕНИЕ БД
        private static OrganizerDbContext dbContext = new OrganizerDbContext();

        public MainWindow()
        {
            InitializeComponent();
            ShowMain();
            UpdateMain();
            UpdateFamily();
        }

        public void UpdateTasks()
        {
            View_TaskList.Children.Clear();
            ICollection<Task>? tasks;
            ICollection<RepeatableTask>? reptasks;

            Txt_HelloUsrname.Text = currentUser?.Name;


            // ПОДКЛЮЧЕНИЕ БД
            if (dbContext.CurrentUsers.FirstOrDefault() != null)
            {
                if (displayedGroup == null || (displayedGroup.Name == "Все задачи" && displayedGroup.IsBuiltin == true))
                {
                    //тут можно сделать или отдельный такой список всех задач, с заранее известным айдишником
                    //ну или выводить их вложенными циклами, но тогда там будет запара с плашкой
                    Txt_DispListName.Text = "Все задачи";
                    Txt_DispListDescription.Visibility = Visibility.Collapsed;


                    tasks = dbContext.Tasks
                        .Where(u => u.TaskGroup.UserID == dbContext.CurrentUsers.FirstOrDefault().UserId)
                        .OrderBy(t => t.Deadline).ToArray();

                    reptasks = dbContext.RepeatableTasks
                        .Where(u => u.TaskGroup.UserID == dbContext.CurrentUsers.FirstOrDefault().UserId)
                        .OrderBy(t => t.Deadline).ToArray();

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

                    tasks = dbContext.Tasks
                        .Where(u => u.TaskGroup.UserID == dbContext.CurrentUsers.FirstOrDefault().UserId)
                        .Where(g => g.TaskGroupID == displayedGroup.TaskGroupID)
                        .OrderBy(t => t.Deadline)
                        .ToArray();

                    reptasks = dbContext.RepeatableTasks
                        .Where(u => u.TaskGroup.UserID == dbContext.CurrentUsers.FirstOrDefault().UserId)
                        .Where(g => g.TaskGroupID == displayedGroup.TaskGroupID)
                        .OrderBy(t => t.Deadline)
                        .ToArray();

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

            if (dbContext.CurrentUsers.FirstOrDefault() != null ) 
            {
                var groups = dbContext.TaskGroups
                    .Where(u => u.UserID == dbContext.CurrentUsers.FirstOrDefault().UserId)
                    .ToList();

                foreach (TaskGroup taskGroup in groups)
                {
                    TaskGroupPlate plate = new(this);
                    plate.representedGroup = taskGroup;
                    View_Lists.Children.Add(plate);
                    plate.Update();
                }
            }
        }

        public void UpdateMain()
        {
            UpdateLists();
            UpdateTasks();
        }

        public void ShowMain()
        {
            Pnl_GroupTaskBtns.Visibility = Visibility.Visible;
            Pnl_FriendsTasks.Visibility = Visibility.Collapsed;
            Pnl_Friends.Visibility = Visibility.Collapsed;
            Btn_AddFriend.Visibility = Visibility.Collapsed;
            Pnl_Tasks.Visibility = Visibility.Visible;
            Pnl_Groups.Visibility = Visibility.Visible;
            //Спрятать всё про семью, вывести панели с элементами главной страницы
        }

        public void ShowFamily()
        {
            Pnl_GroupTaskBtns.Visibility = Visibility.Collapsed;
            Pnl_Tasks.Visibility = Visibility.Collapsed;
            Pnl_Groups.Visibility = Visibility.Collapsed;
            Pnl_FriendsTasks.Visibility = Visibility.Visible;
            Pnl_Friends.Visibility = Visibility.Visible;
            Btn_AddFriend.Visibility = Visibility.Visible;
            //Спрятать всё про главную страницу, вывести элементы страницы семьи
        }

        public void UpdateFamily()
        {
            //Тут обновить всю инфу на странице семьи
            View_Friends.Children.Clear();
            //foreach (друга из Пользователь.Други)
            //{
            //    FriendPlate plate = new(this, repUser: friend, curUser: currentUser);
            //    View_Friends.Children.Add(plate);
            //}
        }

        public void UpdateFriendsTasks()
        {
            View_FriendsTasks.Children.Clear();
            Txt_SelectedFriendName.Text = selectedFriend?.Name;

            //foreach (Task из selectedFriend....ПростыеТаски)
            //{
            //    PlainTaskPlate plate = new();
            //    plate.RepresentedTask = 
            //    View_FriendsTasks.Children.Add(plate);
            //}

            //foreach (RepeatableTask из selectedFriend....ПростыеТаски)
            //{
            //    RepeatableTask plate = new();
            //    plate.RepeatableTaskID =
            //    View_FriendsTasks.Children.Add(plate);
            //}
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (dbContext.CurrentUsers.FirstOrDefault() == null)
            {
                LoginWindow loginWindow = new LoginWindow(this);
                loginWindow.Show();
            }
            else
            {
                // Страница аккаунта. Кнопку выхода поместить туда
            }
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
                TaskCreateWindow createWind = new(this, displayedGroup);
                createWind.Show();
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
                UpdateMain();
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
                UpdateMain();
                MessageBox.Show("Вы вышли!");
            }
            else
            {
                MessageBox.Show("Сначала авторизуйтесь!");
            }
            
        }

        private void Btn_MainPage_Click(object sender, RoutedEventArgs e)
        {
            ShowMain();
            UpdateMain();
        }

        private void Btn_FamilyPage_Click(object sender, RoutedEventArgs e)
        {
            //выбрать тут первого члена семьи по умолчанию или если его нет
            //Pnl_FriendsTasks.Visibility = Visibility.Collapsed;
            ShowFamily();
            UpdateFamily();
        }
    }
}