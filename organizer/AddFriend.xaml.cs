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

namespace organizer
{
    /// <summary>
    /// Логика взаимодействия для AddFriend.xaml
    /// </summary>
    public partial class AddFriend : Window
    {
        private MainWindow main;

        public AddFriend(MainWindow sender)
        {
            main = sender;
            InitializeComponent();
        }

        private void Btn_AddFriend_Click(object sender, RoutedEventArgs e)
        {
            using (OrganizerDbContext dbContext = new OrganizerDbContext())
            {
                User? friend = dbContext.Users.FirstOrDefault(c => c.AddCode == Txt_AddCode.Text);
                if (friend != null)
                {
                    User? currentUser = dbContext.Users.FirstOrDefault(u => u.UserID == dbContext.CurrentUsers.FirstOrDefault().UserId);

                    User? exist = currentUser?.Family?.Users?.FirstOrDefault(u => u.UserID == friend.UserID);



                    if (exist == null)
                    {
                        friend.FamilyID = currentUser.FamilyID;
                        dbContext.SaveChanges();
                        main.UpdateFriendsTasks();
                        main.UpdateFamily();
                    }
                    else
                    {
                        MessageBox.Show("Этот пользователь уже у вас в друзьях");
                    }
                }
            }
            Close();

        }
    }
}
