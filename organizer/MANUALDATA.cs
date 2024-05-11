using organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task = organizer.Models.Task;

namespace organizer
{
    public static class MANUALDATA
    {
        public static Task tsk1 = new Task{ Name = "Задача 1", Status = "Не завершено" };
        public static Task ddlinedTsk1 = new Task { Name = "Срочная задача", Status = "В работе", Deadline = new DateTime(2023, 11, 16) };
        public static Task ddlinedTsk2 = new Task { Name = "Несрочная задача", Status = "Ожидание", Deadline = new DateTime(2024, 5, 16) };
        public static RepeatableTask reptsk1 = new RepeatableTask { Name = "Повторяемая задача", Status = "В работе", Interval = 10, LastDone = DateTime.Today };
        public static List<Models.Task> tsklst = new List<Models.Task>();

        static MANUALDATA()
        {
            tsklst.Add(tsk1);
            tsklst.Add(ddlinedTsk1);
            tsklst.Add(ddlinedTsk2);
        }
    }
}
