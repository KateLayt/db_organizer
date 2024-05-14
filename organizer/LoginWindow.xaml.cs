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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        OrganizerDbContext _context = new OrganizerDbContext();

        private MainWindow main;

        public LoginWindow(MainWindow sender)
        {
            main = sender;
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            User? user = _context.Users
                .FirstOrDefault(u => u.Username == Txt_username.Text && u.HashPassword == Txt_password.Text);

            if (user == null)
            {
                // Такого пользователя не найдено
            }
            else
            {
                CurrentUser currentUser = new CurrentUser
                {
                    UserId = user.UserID,
                    User = user
                };

                _context.CurrentUsers.Add(currentUser);
                _context.SaveChanges();
                main.Update();
                Close();
            }

        }

        private void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            Close();
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }
    }
}
