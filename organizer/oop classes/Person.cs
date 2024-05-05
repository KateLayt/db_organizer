using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer
{
    public class Person
    {
        private static int _count = 0;
        public readonly int ID = _count++;
        private string _name;
        private DateTime _birthDate;
        private int _avatarID;

        public Person() : this("Имя Пользователя") { }
        public Person(string name) : this(name, DateTime.Parse("2001.01.01")){ }
        public Person(string name, DateTime birthDate) : this(name, birthDate, 0) { }
        public Person(string name, DateTime birthDate, int avatarID)
        {
            Name = name;
            BirthDate = birthDate;
            AvatarID = avatarID;
        }



        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 3) throw new ArgumentNullException("name", "Имя должно содержать не менее трех символов.");
                _name = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (value > DateTime.Today) throw new ArgumentOutOfRangeException("bithdate", "Дата рождения не может быть позже сегодняшнего дня.");
                _birthDate = value;
            }

        }

        public int AvatarID
        {
            get { return _avatarID; }
            set
            {
                if (value < 0 || value > 5) throw new ArgumentOutOfRangeException("avatarid", "Не существует аватара с заданным id.");
                _avatarID = value;
            }
        }
    }
}
