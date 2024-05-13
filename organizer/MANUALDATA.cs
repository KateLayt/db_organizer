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
        public static Task tsk1 = new Task{ Name = "я жена субина", Status = "Не завершено" };
        public static Task ddlinedTsk1 = new Task { Name = "Срочная задача", Status = "В работе", Deadline = new DateTime(2023, 11, 16) };
        public static Task ddlinedTsk2 = new Task { Name = "Несрочная задача", Status = "Ожидание", Deadline = new DateTime(2024, 5, 16) };
        public static RepeatableTask reptsk1 = new RepeatableTask { Name = "Повторяемая задача", Status = "В работе", Interval = 10, LastDone = DateTime.Today };
        public static List<Models.Task> tsklst = new List<Models.Task>();
        public static List<Models.RepeatableTask> reptsklst = new List<Models.RepeatableTask>();

        public static TaskGroup tskgrp = new TaskGroup { Name = "Группа 1", IsBuiltin = false, Description = "У меня есть описание" };
        public static TaskGroup tskgrp1 = new TaskGroup { Name = "Группа 2", IsBuiltin = false };
        public static TaskGroup tskgrp2 = new TaskGroup { Name = "Группа 3", IsBuiltin = false, Description = "У меня тоже есть описание" };
        public static List<TaskGroup> groups = new List<TaskGroup>();

        static MANUALDATA()
        {
            tsklst.Add(tsk1);
            tsklst.Add(ddlinedTsk1);
            tsklst.Add(ddlinedTsk2);
            reptsklst.Add(reptsk1);
            tskgrp1.Tasks = new List<Task>{ tsk1 };
            tskgrp2.Tasks = new List<Task>{ ddlinedTsk1 };

            groups.Add(tskgrp);
            groups.Add(tskgrp1);
            groups.Add(tskgrp2);

            tskgrp.Tasks = new List<Models.Task>
            {
                tsk1,
                ddlinedTsk1,
                ddlinedTsk2
            };
        }
    }
}
