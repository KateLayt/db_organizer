using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer
{
    public class OneTimeTask : Task
    {
        private DateTime _deadline;
        public OneTimeTask(string name, DateTime deadline, Person executor)
            :base(name, executor)
        {
            Deadline = deadline;
        }

        public DateTime Deadline
        {
            get { return _deadline; }
            set
            {
                if (value < DateTime.Today) throw new ArgumentOutOfRangeException("Крайний срок не может быть раньше сегодняшнего дня.");
                _deadline = value;
            }
        }
    }
}
