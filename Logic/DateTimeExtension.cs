using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public static  class DateTimeExtension
    {
        public static string DateFormat(this DateTime date) => date.ToString("dd.MM.yyyy");

        public static string DayFormat(this DateTime date) => date.ToString("dddd");

        public static string HourMinFormat(this DateTime date) => date.ToString("HH:mm");

        public static string SecondsFormat(this DateTime date) => date.ToString("ss");

        public static string DateDescription (this DateTime date )=> date.ToString("dd.MM.yyyy" + " | " + "HH:mm");
    }
}
