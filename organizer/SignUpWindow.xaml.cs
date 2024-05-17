using organizer.Migrations;
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
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private bool isMale = true;

        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {

            // ПОДКЛЮЧЕНИЕ БД

            using (OrganizerDbContext dbContext = new OrganizerDbContext())
            {
                User? existingUser = dbContext.Users.FirstOrDefault(u => u.Username == Txt_username.Text);

                if (existingUser == null)
                {
                    if (Txt_name.Text.Length > 3 && Txt_password.Text.Length > 3 )
                    {
                        string hashedPassword = HashPassword(Txt_password.Text);
                        User newUser = new() { Name = Txt_name.Text, Username = Txt_username.Text, HashPassword = hashedPassword, IsMale = isMale, BirthDate = DateTime.Now.ToUniversalTime() };
                        newUser.AddCode = GenerateRandomCode(10);

                        dbContext.Users.Add(newUser);
                        dbContext.SaveChanges();

                        var lastUser = dbContext.Users.OrderByDescending(u => u.UserID).FirstOrDefault();
                        dbContext.TaskGroups.AddRange(new TaskGroup { Name = "Уборка", IsBuiltin = true, UserID = lastUser.UserID },
                                                        new TaskGroup { Name = "Продукты", IsBuiltin = true, UserID = lastUser.UserID },
                                                        new TaskGroup { Name = "Работа", IsBuiltin = true, UserID = lastUser.UserID },
                                                        new TaskGroup { Name = "Прочее", IsBuiltin = true, UserID = lastUser.UserID },
                                                        new TaskGroup { Name = "Все задачи", IsBuiltin = true, UserID = lastUser.UserID });
                        dbContext.SaveChanges();
                        Close();
                        MessageBox.Show("Вы зарегестрированы!\nТеперь авторизуйтесь");

                    }
                    
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                }
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            isMale = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            isMale = false;
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        private static string GenerateRandomCode(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringBuilder = new StringBuilder(length);

            lock (random) // Для потокобезопасности
            {
                for (int i = 0; i < length; i++)
                {
                    stringBuilder.Append(chars[random.Next(chars.Length)]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
