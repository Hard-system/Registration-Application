﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ACCDataStore.Core.CustomException;

namespace ACCDataStore.Core.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime DateTH2DateEN(DateTime dtDateTime, System.Globalization.CultureInfo currentCulture)
        {
            if (currentCulture.CompareInfo.Name.Equals("th-TH"))
            {
                dtDateTime = dtDateTime.AddYears(-543);
            }
            return dtDateTime;
        }

        public static DateTime DateEN2DateTH(DateTime dtDateTime)
        {
            dtDateTime = dtDateTime.AddYears(543);
            return dtDateTime;
        }

        //public static DateTime JulianDate2DateTime(double nJulianDate)
        //{
        //    return DateTime.FromOADate(nJulianDate - 2415018.5);
        //}

        public static DateTime JulianDate2DateTime(double nJulianDate)
        {
            long L = (long)nJulianDate + 68569;
            long N = (long)((4 * L) / 146097);
            L = L - ((long)((146097 * N + 3) / 4));
            long I = (long)((4000 * (L + 1) / 1461001));
            L = L - (long)((1461 * I) / 4) + 31;
            long J = (long)((80 * L) / 2447);
            int Day = (int)(L - (long)((2447 * J) / 80));
            L = (long)(J / 11);
            int Month = (int)(J + 2 - 12 * L);
            int Year = (int)(100 * (N - 49) + I + L);

            var dtDateTime = new DateTime(Year, Month, Day).AddDays(1);
            return dtDateTime;
        }

        public static double DateTime2JulianDate(DateTime dtDateTime)
        {
            return dtDateTime.ToOADate() + 2415018.5;
        }

        //public static DateTime JulianDate2DateTime(double nJulianDate)
        //{
        //    try
        //    {
        //        double a, b, c, d, e, z, alpha;
        //        int nDay, nMonth, nYear;

        //        z = nJulianDate + 1;
        //        if (z < 2299161)
        //        {
        //            a = z;
        //        }
        //        else
        //        {
        //            alpha = (int)((z - 1867216.25) / 35524.25);
        //            a = z + 1 + alpha - alpha / 4;
        //        }

        //        b = a + 1524;
        //        c = (int)((b - 122.1) / 365.25);
        //        d = (int)(365.25 * c);
        //        e = (int)((b - d) / 30.6001);

        //        nDay = (int)(b - d - ((int)(30.6001 * e)));

        //        if (e < 13.5)
        //        {
        //            nMonth = (int)(e - 1);
        //        }
        //        else
        //        {
        //            nMonth = (int)(e - 13);
        //        }

        //        if (nMonth > 2.5)
        //        {
        //            nYear = (int)(c - 4716);
        //        }
        //        else
        //        {
        //            nYear = (int)(c - 4715);
        //        }

        //        return new DateTime(nYear, nMonth, nDay);
        //    }
        //    catch
        //    {
        //        return DateTime.MinValue;
        //    }
        //}

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            DayOfWeek firstDay = defaultCultureInfo.DateTimeFormat.FirstDayOfWeek;
            return GetFirstDayOfWeek(dayInWeek, firstDay);
        }

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }
            return firstDayInWeek;
        }

        public static DateTime GetFirstDayOfMonth(DateTime dtDate)
        {
            DateTime dtFrom = dtDate;
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
            return dtFrom;
        }

        //public static DateTime GetFirstDayOfMonth(int iMonth)
        //{
        //    DateTime dtFrom = new DateTime(DateTime.Now.Year, iMonth, 1);
        //    dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
        //    return dtFrom;
        //}

        //public static DateTime GetFirstDayOfMonth(int iMonth, int nYear)
        //{
        //    DateTime dtFrom = new DateTime(nYear, iMonth, 1);
        //    dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
        //    return dtFrom;
        //}

        public static DateTime GetLastDayOfMonth(DateTime dtDate)
        {
            DateTime dtTo = dtDate;
            dtTo = dtTo.AddMonths(1);
            dtTo = dtTo.AddDays(-(dtTo.Day));
            return dtTo;
        }

        //public static DateTime GetLastDayOfMonth(int iMonth)
        //{
        //    DateTime dtTo = new DateTime(DateTime.Now.Year, iMonth, 1);
        //    dtTo = dtTo.AddMonths(1);
        //    dtTo = dtTo.AddDays(-(dtTo.Day));
        //    return dtTo;
        //}

        //public static DateTime GetLastDayOfMonth(int iMonth, int nYear)
        //{
        //    DateTime dtTo = new DateTime(nYear, iMonth, 1);
        //    dtTo = dtTo.AddMonths(1);
        //    dtTo = dtTo.AddDays(-(dtTo.Day));
        //    return dtTo;
        //}

        public static int GetWeekNumberOfYear(DateTime dtPassed)
        {
            CultureInfo ciCurr = new CultureInfo("en-US");
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public static string GetWeekTextOfYear(DateTime dtPassed)
        {
            int nWeekNum = GetWeekNumberOfYear(dtPassed);
            string sYear = dtPassed.Year.ToString().Substring(2, 1);
            if (dtPassed.Month == 1 && nWeekNum > 40)
            {
                sYear = (dtPassed.Year - 1).ToString().Substring(3, 1);
            }
            return sYear + nWeekNum.ToString().PadLeft(2, '0');
        }

        public static int GetTotalPointBetweenDateTime(int nIntervalType, DateTime dtFromDateTime, DateTime dtToDateTime)
        {
            switch (nIntervalType)
            {
                case 0: // minute
                    return (int)Math.Floor((dtToDateTime - dtFromDateTime).TotalMinutes);
                default:
                    return (int)Math.Floor((dtToDateTime - dtFromDateTime).TotalMinutes);
            }
        }

        public static string DateTimeToString(DateTime dtDataDateTime)
        {
            return dtDataDateTime != null ? dtDataDateTime.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US")) : "";
        }

        public static string DateTimeToString(DateTime? dtDataDateTime)
        {
            return dtDataDateTime != null && dtDataDateTime.HasValue ? dtDataDateTime.Value.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("en-US")) : "";
        }

        public static string DateTimeToStringSql(DateTime dtDataDateTime)
        {
            return dtDataDateTime != null ? dtDataDateTime.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US")) : "";
        }

        public static string DateTimeToStringSql(DateTime? dtDataDateTime)
        {
            return dtDataDateTime != null && dtDataDateTime.HasValue ? dtDataDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss", new System.Globalization.CultureInfo("en-US")) : "";
        }

        public static string DateTimeToString(DateTime dtDataDateTime, string sFormat)
        {
            return dtDataDateTime != null ? dtDataDateTime.ToString(sFormat, new System.Globalization.CultureInfo("en-US")) : "";
        }

        public static string DateTimeToString(DateTime? dtDataDateTime, string sFormat)
        {
            return dtDataDateTime != null && dtDataDateTime.HasValue ? dtDataDateTime.Value.ToString(sFormat, new System.Globalization.CultureInfo("en-US")) : "";
        }

        public static string DateTimeToString(DateTime dtDataDateTime, string sFormat, string sCultureInfo)
        {
            return dtDataDateTime != null ? dtDataDateTime.ToString(sFormat, new System.Globalization.CultureInfo(sCultureInfo)) : "";
        }

        public static string DateTimeToString(DateTime? dtDataDateTime, string sFormat, string sCultureInfo)
        {
            return dtDataDateTime != null && dtDataDateTime.HasValue ? dtDataDateTime.Value.ToString(sFormat, new System.Globalization.CultureInfo(sCultureInfo)) : "";
        }

        public static DateTime StringToDateTime(string sDateTime, string sFormat, string sErrorMessage)
        {
            var dtDataDateTime = DateTime.MinValue;
            if (DateTime.TryParseExact(sDateTime, sFormat, new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out dtDataDateTime))
            {
                return dtDataDateTime;
            }
            else
            {
                throw new InvalidFormatException(sErrorMessage);
            }
        }

        public static DateTime GetBeginOfToday()
        {
            return DateTime.Today;
        }

        public static DateTime GetEndOfToday()
        {
            return DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        public static DateTime GetBeginOfCurrentHour(DateTime dtNow, int nHourInterval)
        {
            return dtNow.Trim(TimeSpan.TicksPerHour).AddHours(nHourInterval);
        }

        public static DateTime GetEndOfCurrentHour(DateTime dtNow, int nHourInterval)
        {
            return dtNow.Trim(TimeSpan.TicksPerHour).AddHours(nHourInterval).AddMinutes(59).AddSeconds(59);
        }

        public static DateTime Trim(this DateTime date, long roundTicks)
        {
            return new DateTime(date.Ticks - date.Ticks % roundTicks);
        }

        public static List<DateTime> GetDateRange(DateTime dtFrom, DateTime dtTo)
        {
            return Enumerable.Range(0, dtTo.Subtract(dtFrom).Days + 1).Select(d => dtFrom.AddDays(d)).ToList();
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            var OLDtime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = date.ToUniversalTime() - OLDtime;
            return Math.Floor(diff.TotalMilliseconds);
        }
    }
}
