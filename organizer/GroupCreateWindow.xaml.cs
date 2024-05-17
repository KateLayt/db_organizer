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
    public partial class GroupCreateWindow : Window
    {
        private MainWindow main;

        public GroupCreateWindow(MainWindow sender)
        {
            main = sender;
            InitializeComponent();
        }
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (Txt_GroupName.Text.Length < 3 || Txt_GroupName.Text.Length > 25) errors += "Название группы должно содержать от 3 до 25 символов";
            if (Txt_Description.Text.Length > 50) errors += "Длина описания не должна превышать 50 символов.";
            if (errors != "") MessageBox.Show(errors);
            else
            {
                TaskGroup newGroup = new TaskGroup
                {
                    Name = Txt_GroupName.Text,
                    Description = Txt_Description.Text
                };

                // ПОДКЛЮЧЕНИЕ БД

                using (var dbContext = new OrganizerDbContext())
                {
                    int currentUserId = dbContext.CurrentUsers.FirstOrDefault().UserId;

                    newGroup.UserID = currentUserId;
                    dbContext.TaskGroups.Add(newGroup);
                    dbContext.SaveChanges();
                }

                //MANUALDATA.groups.Add(newGroup);

                main.UpdateMain();
                Close();
            }
        }
    }
}
