using organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task = organizer.Models.Task;

namespace organizer
{
    public static class MANUALDATA
    {
        public static Task tsk1 = new Task{ Name = "Задача 1", Status = "Статус первой задачи" };
        public static RepeatableTask reptsk1 = new RepeatableTask { Name = "Повторяемая задача", Status = "В работе", Interval = 10, LastDone = DateTime.Today };
    }
}
