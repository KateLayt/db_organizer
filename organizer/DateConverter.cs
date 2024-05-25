using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organizer
{
    public static class DateConverter
    {
        private static readonly Dictionary<int, string> MonthNames = new Dictionary<int, string>() {
            { 1, "января"}, { 2, "февраля" }, { 3, "марта"}, { 4, "апреля" }, { 5, "мая"}, { 6, "июня" },
            { 7, "июля"}, { 8, "августа" }, { 9, "сентября"}, { 10, "октября" }, { 11, "ноября"}, { 12, "декабря" }};

        public static string RepresentDate(DateTime? date)
        {
            if (date == null)
            {
                return "";
            }
            DateTime date1 = (DateTime)date;
            return $"{date1.Day.ToString()} {MonthNames[date1.Month]}";
        }

        public static DateTime GetDateTime(string date)
        {
            return new DateTime(DateTime.Now.Year, MonthNames.FirstOrDefault(x => x.Value == date.Split(" ")[1]).Key, Int32.Parse(date.Split(" ")[0]));
        }

        public static string RepresentDays(int days) {
            string result = days.ToString();
            if (days % 100 >= 10 && days % 100 <= 20)
            {
                result += " дней";
            }
            else if (days % 10 == 1)
            {
                result += " день";
            }
            else if (new[] { 2, 3, 4 }.Contains(days % 10))
            {
                result += " дня";
            }
            else
            {
                result += " дней";
            }
            return result;
        }

        public static int DifferenceInDays(DateTime date1, DateTime date2)
        {
            return (date1 < date2) ? date2.Subtract(date1).Days : date1.Subtract(date2).Days;
        }
    }
}
