using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer
{
    public class Task : IComparable<Task>
    {
        private protected readonly List<String> AcceptableStatuses;
        private protected static int _count = 0;
        public readonly int ID = _count++;
        private protected string _name, _status;
        private Person _executor;

        public Task(string name, Person executor) : this(name, executor, new() { "Не завершено", "Завершено" }) { }

        public Task(string name, Person executor, List<String> acceptableStatuses)
        {
            AcceptableStatuses = acceptableStatuses;
            Name = name;
            Executor = executor;
            _status = "Не завершено";
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentNullException("name", "Название задания не может быть пустым.");
                _name = value;
            }

        }

        public Person Executor
        {
            get { return _executor; }
            set
            {
                if (value == null) throw new ArgumentNullException("executor", "У задачи должен быть исполнитель.");
                _executor = value;
            }
        }


        public string TaskStatus
        {
            get { return _status; }
            private set 
            { 
                if(!AcceptableStatuses.Contains(value)) throw new ArgumentException("Недопустимое состояние задачи.", "status");
                _status = value; 
            }
        }

        public void Complete()
        {
            TaskStatus = "Завершено";
        }

        public void Reset()
        {
            TaskStatus = "Не завершено";
        }

        public int CompareTo(Task other)
        {
            if (this.TaskStatus == other.TaskStatus) return 0;
            switch (this.TaskStatus)
            {
                case "Не завершено": return 1;
                case "За работу!":
                    if (other.TaskStatus == "Не завершено")
                    {
                        return -1;
                    }
                    else return 1;
                case "Нормально":
                    if (other.TaskStatus == "За работу!" || other.TaskStatus == "Не завершено")
                    {
                        return -1;
                    }
                    else return 1;
                case "Всё хорошо":
                    if (this.TaskStatus == "Завершено")
                    {
                        return 1;
                    }
                    else return -1;
                case "Завершено": return -1;
                default: return 0;
            }
        }
    }
}
