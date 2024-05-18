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
using static System.Runtime.InteropServices.JavaScript.JSType;
using Task = organizer.Models.Task;

namespace organizer
{
    /// <summary>
    /// Interaction logic for PlainTaskPlate.xaml
    /// </summary>
    public partial class PlainTaskFriend : UserControl
    {
        public Task RepresentedTask;
        public PlainTaskFriend()
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
                this.Height = 85;
                this.Width = 300;
                Txt_Deadline.Visibility = Visibility.Collapsed;
                Txt_DeadlinePretxt.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Height = 110;
                this.Width = 300;
                Txt_Deadline.Visibility = Visibility.Visible;
                Txt_DeadlinePretxt.Visibility = Visibility.Visible;
                Txt_Deadline.Text = DateConverter.RepresentDate(RepresentedTask.Deadline);
            }
        }
    }
}
