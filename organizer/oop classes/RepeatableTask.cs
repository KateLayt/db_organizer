using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FamilyOrganizer
{
    public class RepeatableTask : Task
    {
        private DateTime _lastDone, _deadline;
        private int _interval;
        public RepeatableTask(string name, int interval, Person executor)
            : base(name, executor, new() { "Всё хорошо", "Нормально", "За работу!" })
        {
            LastDone = DateTime.Today;
            Deadline = LastDone.AddDays(interval);
            Interval = interval;
            UpdateTask(); //Задает первоначальное значение status
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                if (value < DateTime.Now) throw new ArgumentOutOfRangeException("deadline", "Крайний срок не может быть раньше сегодняшнего дня.");
                _deadline = value;
            }
        }

        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                if (value > 999) throw new ArgumentOutOfRangeException(paramName: "interval", message: "Слишком большой интервал.");
                if (value < 1) throw new ArgumentOutOfRangeException(paramName: "interval", message: "Интервал должен быть больше 0.");
                _interval = value;
            }
        }

        public string TaskStatus
        {
            get 
            { 
                UpdateTask();
                return _status; 
            }
            private set
            {
                if (!AcceptableStatuses.Contains(value)) throw new ArgumentException("Недопустимое состояние задачи.", "status");
                _status = value;
            }
        }


        public DateTime LastDone
        {
            get { return _lastDone; }
            set
            {
                if (value > DateTime.Now) throw new ArgumentOutOfRangeException("LastDone", "Задача не могла быть выполнена в последний раз позже сегодняшнего дня.");
                _lastDone = value;
            }
        }

        public void UpdateTask()
        {
            int overallDays = Interval;
            int currentDays = DateTime.Now.Subtract(LastDone).Days;

            if (currentDays < overallDays / 3)
            {
                TaskStatus = "Всё хорошо";
            }

            else if (currentDays > overallDays / 3 && currentDays < overallDays * 2 / 3)
            {
                TaskStatus = "Нормально";
            }

            else
            {
                TaskStatus = "За работу!";
            }

        }

        public void Complete()
        {
            Deadline = DateTime.Today.AddDays(Interval);
            LastDone = DateTime.Today;
            this.UpdateTask();
        }

    }
}
