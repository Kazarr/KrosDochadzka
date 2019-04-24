using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Data.Repository
{
    public class DaySummaryRepository
    {
        public List<DailyResult> GetDailyResult(DateTime date, int idWorkType, int idEmployee)
        {
            List<DailyResult> ret = new List<DailyResult>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select dr.*from DailyResult as dr
                                                where dr.IdEmployee = @idEmployee  and dr.IdWorktype=@idWorkType and (convert(date,dr.start)=convert(date,@date))";
                        command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = idEmployee;
                        command.Parameters.Add("@idWorkType", SqlDbType.Int).Value = idWorkType;
                        command.Parameters.Add("@date", SqlDbType.NVarChar).Value = date;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int dailyResultId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                int employeeId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                DateTime start = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                                DateTime finish = reader.IsDBNull(3) ? DateTime.MaxValue : reader.GetDateTime(3);
                                int workTypeId = reader.IsDBNull(4) ? 8 : reader.GetInt32(4);
                                Debug.WriteLine(workTypeId);

                                ret.Add(new DailyResult(dailyResultId, employeeId, start, finish, workTypeId));
                            }
                            if (ret == null)
                            {
                                ret.Add(new DailyResult());
                            }
                            return ret;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw e;
                }
            }
        }

        public DaySummary CreateDaySummary(DateTime date, int idEmployee)
        {
            DaySummary daySummary = new DaySummary();
            daySummary.Work = GetDailyResult(date, 1, idEmployee);
            daySummary.Lunch = GetDailyResult(date, 2, idEmployee);
            daySummary.Holiday = GetDailyResult(date, 3, idEmployee);
            daySummary.HomeOffice = GetDailyResult(date, 4, idEmployee);
            daySummary.BusinessTrip = GetDailyResult(date, 5, idEmployee);
            daySummary.Doctor = GetDailyResult(date, 6, idEmployee);
            daySummary.Other = GetDailyResult(date, 7, idEmployee);

            return daySummary;

        }

        public List<string> MakeLine(DateTime date, int idEmployee)
        {
            List<string> myStringList = new List<string>();
            DaySummary day = CreateDaySummary(date, idEmployee);

            myStringList.Insert(0, date.ToString("dd/MM/yyyy"));


            DailyResult drFirst = day.Work.OrderBy(a => a.Start).FirstOrDefault();
            DailyResult drLast = day.Work.OrderByDescending(a => a.Finish).FirstOrDefault();

            myStringList.Insert(1, drFirst == null ? "" : drFirst.Start.ToString());

            myStringList.Insert(2, drLast == null ? "" : drLast.Finish.ToString());

            DailyResult drLunchStart = day.Lunch.OrderBy(a => a.Start).FirstOrDefault();

            DailyResult drLunchFinish = day.Lunch.OrderByDescending(a => a.Finish).FirstOrDefault();

            myStringList.Insert(3, drLunchStart == null ? "" : drLunchStart.Start.ToString());
            myStringList.Insert(4, drLunchFinish == null ? "" : drLunchFinish.Finish.ToString());

            //else
            //{
            //    myStringList.Insert(1, "");
            //    myStringList.Insert(2, "");
            //    myStringList.Insert(3, "");
            //    myStringList.Insert(4, "");
            //}


            return myStringList;
        }

        public Dictionary<string, List<string>> April(int idEmployee)
        {
            Dictionary<string, List<string>> April = new Dictionary<string, List<string>>();
            const int MONTH = 4; // write out all the days of May 2015
            DateTime dt = new DateTime(2019, MONTH, 1);
            while (dt.Month == MONTH)
            {
                
                April[dt.ToString("yyyy-MM-dd")] = MakeLine(dt, idEmployee);
                dt = dt.AddDays(1);
            }
            return April;
        }



    }
}
