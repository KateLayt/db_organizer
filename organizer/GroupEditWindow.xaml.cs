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
    public partial class GroupEditWindow : Window
    {
        private TaskGroup editedGroup;
        private MainWindow main;

        public GroupEditWindow(TaskGroup group, MainWindow sender)
        {
            editedGroup = group;
            main = sender;
            InitializeComponent();

            Txt_GroupName.Text = group.Name;
            Txt_Description.Text = group.Description;
        }
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            MANUALDATA.groups.Remove(editedGroup);
            main.displayedGroup = null;
            main.Update();
            //Здесь нужно удалить группу из базы
            Close();
        }

        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            if (Txt_GroupName.Text.Length < 3 || Txt_GroupName.Text.Length > 25) errors += "Название группы должно содержать от 3 до 25 символов";
            if (Txt_Description.Text.Length > 50) errors += "Длина описания не должна превышать 50 символов.";
            if (errors != "") MessageBox.Show(errors);
            else
            {
                editedGroup.Name = Txt_GroupName.Text;
                editedGroup.Description = Txt_Description.Text;
                main.Update();
            }
        }
    }
}
