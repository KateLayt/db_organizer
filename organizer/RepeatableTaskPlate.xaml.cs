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
using Task = organizer.Models.Task;

namespace organizer
{
    /// <summary>
    /// Interaction logic for TaskPlate.xaml
    /// </summary>
    public partial class RepeatableTaskPlate : UserControl
    {
        RepeatableTask representedTask;
        public RepeatableTaskPlate()
        {
            InitializeComponent();

            representedTask = MANUALDATA.reptsk1;
            Txt_TaskName.Text = representedTask.Name;
            Txt_TaskStatus.Text = representedTask.Status;
            Txt_RepeatEvery.Text = DateConverter.RepresentDays(representedTask.Interval);
            Txt_LastDone.Text = DateConverter.RepresentDate(representedTask.LastDone); //нам точно нужно, чтобы это свойство было nullable в модели?

        }

        //проверки на тип задачи, в связи с ними же отображение полей и изменение значений в них.
    }
}
