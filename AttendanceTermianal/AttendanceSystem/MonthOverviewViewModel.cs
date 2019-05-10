using Data.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    class MonthOverviewViewModel
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
            _overTime = TimeSpan.Zero;
            _holidayTime = TimeSpan.Zero;
            _sickTime = TimeSpan.Zero;
            _bsTripTime = TimeSpan.Zero;
            _homeOfficeTime = TimeSpan.Zero;
            Count();
        }

        private void Count()
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
                _overTime = _totalHours - TimeSpan.FromHours(8 * dayCount);
            }


        }

        public string GetTotalHours()
        {
            return _totalHours.ToString(@"hh\:mm\:ss");
        }

        public string GetOverTime()
        {
            return $"{(Int32)  _overTime.TotalHours}:{_overTime.ToString(@"mm\:ss")}";
        }

        public string GetHolidayTime()
        {
            return _holidayTime.ToString(@"hh\:mm\:ss");
        }

        public string GetSickTime()
        {
            return _sickTime.ToString(@"hh\:mm\:ss");
        }

        public string GetBSTripTime()
        {
            return _bsTripTime.ToString(@"hh\:mm\:ss");
        }

        public string GetHomeOfficeTime()
        {
            return _homeOfficeTime.ToString(@"hh\:mm\:ss");
        }




    }
}
