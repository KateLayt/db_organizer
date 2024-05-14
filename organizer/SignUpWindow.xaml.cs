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
            using (OrganizerDbContext dbContext = new OrganizerDbContext())
            {
                User? existingUser = dbContext.Users.FirstOrDefault(u => u.Username == Txt_username.Text);

                if (existingUser == null)
                {
                    if (Txt_name.Text.Length > 3 && Txt_password.Text.Length > 3 )
                    {
                        User newUser = new() { Name = Txt_name.Text, Username = Txt_username.Text, HashPassword = Txt_password.Text, IsMale = isMale, BirthDate = DateTime.Now.ToUniversalTime() };

                        dbContext.Users.Add(newUser);
                        dbContext.SaveChanges();
                        dbContext.TaskGroups.AddRange(new TaskGroup { Name = "Уборка", IsBuiltin = true },
                                                        new TaskGroup { Name = "Продукты", IsBuiltin = true },
                                                        new TaskGroup { Name = "Работа", IsBuiltin = true },
                                                        new TaskGroup { Name = "Прочее", IsBuiltin = true },
                                                        new TaskGroup { Name = "Все задачи", IsBuiltin = true });
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
    }
}
