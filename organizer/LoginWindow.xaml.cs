using Microsoft.EntityFrameworkCore;
using organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        // ПОДКЛЮЧЕНИЕ БД
        OrganizerDbContext _context = new OrganizerDbContext();

        private MainWindow main;

        public LoginWindow(MainWindow sender)
        {
            main = sender;
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            User? user = null;
            string? hashPassword = _context.Users.FirstOrDefault(n => n.Username == Txt_username.Text)?.HashPassword;
            if (VerifyHashedPassword(hashPassword, Txt_password.Text))
            {
                user = _context.Users
                .FirstOrDefault(u => u.Username == Txt_username.Text);
            }

            if (user == null)
            {
                MessageBox.Show("Такого пользователя не найдено");
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
                main.UpdateMain();
                Close();
            }

        }

        private void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            Close();
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] a1, byte[] a2)
        {
            if (a1 == a2)
            {
                return true;
            }

            if (a1 == null || a2 == null)
            {
                return false;
            }

            if (a1.Length != a2.Length)
            {
                return false;
            }

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
