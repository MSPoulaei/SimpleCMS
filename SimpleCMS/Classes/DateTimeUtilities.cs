using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace SimpleCMS
{
    public static class DateTimeUtilities
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return persianCalendar.GetYear(dateTime) + "/"
                + persianCalendar.GetMonth(dateTime) + "/"
                + persianCalendar.GetDayOfMonth(dateTime);
        }
        public static string ToShamsiText(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            //مرداد 25, 1400
            return dateTime.ToString("MMMM") + " "
                + persianCalendar.GetDayOfMonth(dateTime) + ", "
                + persianCalendar.GetYear(dateTime);
        }
        public static string ToMiladiText(this DateTime dateTime)
        {
            //June 16, 2020
            return dateTime.ToString("MMMM") + " "
                + dateTime.Day + ", "
                + dateTime.Year;
        }
        public static string ToShamsiLongText(this DateTime dateTime)
        {
            //June 16, 2020
            return dateTime.ToString("yyyy/MM/dd hh:mm tt", new CultureInfo("fa-IR"));
           //"  " +
           //        dateTime.Hour + ":" +
           //        dateTime.Minute + " " +
           //        dateTime.ToString("tt", new CultureInfo("fa-IR"));
        }

        public static string GetDayOfWeekPersianName(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "يکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه‏ شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنجشنبه";
                case DayOfWeek.Friday: return "جمعه";
                default: return "خطا";
            }
        }
        public static string GetMonthPersianName(this DateTime date)
        {
            //PersianCalendar jc = new PersianCalendar();
            //string pdate = string.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));
            string persianDate = date.ToShamsi();// 1400/
            string[] dates = persianDate.Split('/');
            int month = Convert.ToInt32(dates[1]);
            switch (month)
            {
                case 1: return "فررودين";
                case 2: return "ارديبهشت";
                case 3: return "خرداد";
                case 4: return "تير‏";
                case 5: return "مرداد";
                case 6: return "شهريور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دي";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: return "خطا";
            }

        }
    }
}