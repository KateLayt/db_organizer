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
using Task = organizer.Models.Task;

namespace organizer
{
    /// <summary>
    /// Interaction logic for PlainTaskPlate.xaml
    /// </summary>
    public partial class PlainTaskPlate : UserControl
    {
        public Task RepresentedTask;
        public PlainTaskPlate()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            if (RepresentedTask == null)
            {
                RepresentedTask = MANUALDATA.tsk1;
            }
            Txt_TaskName.Text = RepresentedTask.Name;
            Txt_TaskStatus.Text = RepresentedTask.Status;
            if (RepresentedTask.Deadline is null)
            {
                Txt_Deadline.Visibility = Visibility.Collapsed;
                Txt_DeadlinePretxt.Visibility = Visibility.Collapsed;
            }
            else
            {
                Txt_Deadline.Visibility = Visibility.Visible;
                Txt_DeadlinePretxt.Visibility = Visibility.Visible;
                Txt_Deadline.Text = DateConverter.RepresentDate(RepresentedTask.Deadline);
            }
        }

        private void Btn_TaskDone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_TaskEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
