using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.VersionControl;

namespace FamilyOrganizer
{
    public class TaskgroupManager
    {
        private Dictionary<int, TaskGroup> _taskGroups = new();
        private Person _owner;
        public TaskgroupManager(Person owner) 
        {
            Owner = owner;
        }

        public Person Owner
        {
            get { return _owner; }
            private set
            {
                if (value == null) throw new ArgumentNullException("owner", "У групп задач должен быть владелец.");
                _owner = value;
            }
        }

        public void AddTaskGroup(TaskGroup taskgroup)
        {
            if (_taskGroups.ContainsKey(taskgroup.TaskgroupID)) throw new Exception("Эта группа уже входит в коллекцию задач.");
            _taskGroups.Add(taskgroup.TaskgroupID, taskgroup);
        }

        public void RemoveTaskGroup(int taskgroupID)
        {
            if (!_taskGroups.ContainsKey(taskgroupID)) throw new Exception("Нельзя удалить группу задач, которой нет в коллекции.");
            _taskGroups.Remove(taskgroupID);
        }

        public TaskGroup GetTaskGroup(int taskgroupID)
        {
            if (!_taskGroups.ContainsKey(taskgroupID)) throw new Exception("Нельзя получить группу задач, которой нет в коллекции.");
            return _taskGroups[taskgroupID];
        }

        public List<TaskGroup> GetAllGroups()
        {
            return _taskGroups.Values.ToList();
        }

    }
}
