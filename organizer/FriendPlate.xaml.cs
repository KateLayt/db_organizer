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
    /// Interaction logic for FriendPlate.xaml
    /// </summary>
    public partial class FriendPlate : UserControl
    {
        User representedFriend;
        User currentUser;
        MainWindow main;

        public FriendPlate(MainWindow sender, User repUser, User curUser)
        {
            main = sender;
            representedFriend=repUser;
            currentUser=curUser;
            InitializeComponent();
            Txt_Name.Text = currentUser.Name;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            currentUser.Family.Users.Remove(representedFriend);
            //Удалить пользователя из другов
        }

        private void On_SelectFriend_Click(object sender, RoutedEventArgs e)
        {
            main.selectedFriend = representedFriend;
        }
    }
}
