using System;
using System.Globalization;

namespace Common.Library
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc=new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
        public static string ToShamsiDot(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "." + pc.GetMonth(value).ToString("00") + "." +
                   pc.GetDayOfMonth(value).ToString("00");
        }
        public static string ToShamsiMonthDay(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetMonth(value).ToString("0") + pc.GetDayOfMonth(value).ToString("00");
            
        }
        public static string ToShamsiMonth(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetMonth(value).ToString("0");
                
        }
        public static string ToShamsiDay(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetDayOfMonth(value).ToString("00"); 

        }
    }
}
