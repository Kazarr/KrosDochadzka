using AttendanceSystem;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleSystem
{
    class MonthOverviewConsole
    {
        private IReader _reader;
        private IWriter _writer;
        private int _loginId;
        private Logic.LogicSystem _logicSystem;

        public MonthOverviewConsole(int id, IReader reader, IWriter writer, Logic.LogicSystem logic)
        {
            _logicSystem = logic;
            _loginId = id;
            _reader = reader;
            _writer = writer;

        }

        public void GetMonthOverview()
        {
            _writer.Clear();
            List<DaySummary> myList = _logicSystem.GetSummariesByMonth(GetDateFormat(), _loginId);
            WriteDetails(new MonthOverviewViewModel(myList));
            _writer.Writer(Properties.Resources.PressKey);
            _reader.ReadLine();
            _writer.Clear();
        }

        private string GetDateFormat()
        {
            return $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month)} " +
                $"{DateTime.Now.Year.ToString()}";
        }

        private void WriteDetails(MonthOverviewViewModel monthOverview)
        {
            _writer.Writer($"{Properties.Resources.MonthTotalHours} \t {monthOverview.GetTotalHours()}");
            _writer.Writer($"{Properties.Resources.MonthOvertime} \t {monthOverview.GetOverTime()}");
            _writer.Writer($"{Properties.Resources.MonthHoliday} \t {monthOverview.GetHolidayTime()}");
            _writer.Writer($"{Properties.Resources.MonthSick} \t\t {monthOverview.GetSickTime()}");
            _writer.Writer($"{Properties.Resources.MonthBS} \t\t {monthOverview.GetBSTripTime()}");
            _writer.Writer($"{Properties.Resources.MonthHomeOffice} \t\t {monthOverview.GetHomeOfficeTime()}");
        }
    }
}
