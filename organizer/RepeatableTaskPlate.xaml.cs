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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace organizer
{
    /// <summary>
    /// Interaction logic for TaskPlate.xaml
    /// </summary>
    public partial class RepeatableTaskPlate : UserControl
    {
        public RepeatableTask RepresentedTask;
        public RepeatableTaskPlate()
        {
            InitializeComponent();
            //RepresentedTask = task; в итоговой архитектуре назначение вручную извне - бан. таск должен будет передаваться в конструктор перед отображением плашек.
            Update();
        }

        public void Update()
        {
            if (RepresentedTask == null)
            {
                RepresentedTask = MANUALDATA.reptsk1;
            }
            this.Height = 130;
            this.Width = 300;
            Txt_TaskName.Text = RepresentedTask.Name;
            Txt_TaskStatus.Text = RepresentedTask.Status;
            Txt_RepeatEvery.Text = DateConverter.RepresentDays(RepresentedTask.Interval);
            Txt_LastDone.Text = DateConverter.RepresentDate(RepresentedTask.LastDone);
        }

        private void Btn_TaskEdit_Click(object sender, RoutedEventArgs e)
        {
            TaskEditWindow editWind = new TaskEditWindow(RepresentedTask, this);
            editWind.Show();
        }
    }
}
