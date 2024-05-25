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
using organizer.Migrations;
using organizer.Models;

namespace organizer
{
    /// <summary>
    /// Interaction logic for FriendPlate.xaml
    /// </summary>
    public partial class FriendPlate : UserControl
    {
        User representedFriend;
        MainWindow main;

        public FriendPlate(MainWindow sender, User repUser)
        {
            main = sender;
            representedFriend=repUser;
            InitializeComponent();
            Txt_Name.Text = repUser.Name;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (OrganizerDbContext dbContext = new OrganizerDbContext())
            {
                dbContext.Users.FirstOrDefault(u => u.UserID == representedFriend.UserID).FamilyID = representedFriend.UserID;
            }
        }

        private void On_SelectFriend_Click(object sender, RoutedEventArgs e)
        {
            main.selectedFriend = representedFriend;
            main.UpdateMain();
        }
    }
}
