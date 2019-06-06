using Data.Model;
using System;
using System.Collections.Generic;

namespace AttendanceSystem
{
    public class MonthOverviewViewModel
    {
        private List<DaySummary> _daySummaries;
        private TimeSpan _totalHours;
        private TimeSpan _overTime;
        private TimeSpan _holidayTime;
        private TimeSpan _sickTime;
        private TimeSpan _bsTripTime;
        private TimeSpan _homeOfficeTime;

        public MonthOverviewViewModel(List<DaySummary> daySummaries)
        {
            _totalHours = TimeSpan.Zero;
            _daySummaries = daySummaries;
            _holidayTime = TimeSpan.Zero;
            _sickTime = TimeSpan.Zero;
            _overTime = TimeSpan.Zero;
            _bsTripTime = TimeSpan.Zero;
            _homeOfficeTime = TimeSpan.Zero;
            FillFieldsWithTime();
        }

        private void FillFieldsWithTime()
        {
            int dayCount = 0;
            foreach (var day in _daySummaries)
            {

                if ((Convert.ToDateTime(day.Date).Date < DateTime.Today.Date) &&
                    !((Convert.ToDateTime(day.Date).DayOfWeek.ToString().Equals("Sunday")) ||
                    (Convert.ToDateTime(day.Date).DayOfWeek.ToString().Equals("Saturday"))))
                {
                    dayCount++;
                }
                if (Convert.ToDateTime(day.Date).Date < DateTime.Today.Date)
                {

                    _totalHours += (day.TotalTimeWorked == null) ? TimeSpan.Zero : (TimeSpan)day.TotalTimeWorked;
                    _holidayTime += (day.HolidayTime == null) ? TimeSpan.Zero : (TimeSpan)day.HolidayTime;
                    _sickTime += (day.Doctor == null) ? TimeSpan.Zero : (TimeSpan)day.Doctor;
                    _bsTripTime += (day.BusinessTrip == null) ? TimeSpan.Zero : (TimeSpan)day.BusinessTrip;
                    _homeOfficeTime += (day.HomeOffice == null) ? TimeSpan.Zero : (TimeSpan)day.HomeOffice;
                }
            }
                _overTime = _totalHours - TimeSpan.FromHours(8 * dayCount);


        }

        public string GetTotalHours()
        {
            return $"{(Int32)_totalHours.TotalHours}:{_totalHours.ToString(@"mm\:ss")}";
        }

        public string GetOverTime()
        {
            return $"{(Int32)_overTime.TotalHours}:{_overTime.ToString(@"mm\:ss")}";
        }

        public string GetHolidayTime()
        {
            return $"{(Int32)_holidayTime.TotalHours}:{_holidayTime.ToString(@"mm\:ss")}";
        }

        public string GetSickTime()
        {
            return $"{(Int32)_sickTime.TotalHours}:{_sickTime.ToString(@"mm\:ss")}";
        }

        public string GetBSTripTime()
        {
            return $"{(Int32)_bsTripTime.TotalHours}:{_bsTripTime.ToString(@"mm\:ss")}";
        }

        public string GetHomeOfficeTime()
        {
            return $"{(Int32)_homeOfficeTime.TotalHours}:{_homeOfficeTime.ToString(@"mm\:ss")}";
        }
    }
}
