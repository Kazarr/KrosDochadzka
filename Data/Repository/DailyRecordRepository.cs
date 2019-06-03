using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class DailyRecordRepository : ConnectionManager
    {

        public IEnumerable<DailyResultWithWorkType> GetSpecifficDailyResult(int employeeID, DateTime date)
        {
            List<DailyResultWithWorkType> ret = new List<DailyResultWithWorkType>();
            Execute((command) =>
            {
                command.CommandText = @"select dr.id,dr.idEmployee,dr.Start,dr.Finish,w.Name 
                                        from DailyRecord as dr
                                        left join WorkType as w on w.Id=dr.IdWorktype
                                        where idEmployee=@idEmployee and (convert(date,dr.Start)=convert(date,@date) 
                                            or convert(date,dr.Finish)=convert(date,@date))";
                command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = employeeID;
                command.Parameters.Add("@date", SqlDbType.DateTime2).Value = date;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DailyResultWithWorkType dailyResultWithWork = new DailyResultWithWorkType
                        {
                            DailyResultID = reader.GetInt32(0),
                            IdEmployee = reader.GetInt32(1),
                            StartTime = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                            FinishTime = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            WorkType = reader.IsDBNull(4) ? "" : reader.GetString(4)
                        };

                        ret.Add(dailyResultWithWork);

                    }
                }
            });
            return ret;

        }

        public bool DeleteDailyResult(int dailyResultID)
        {
            bool success = false;
            Execute((command) =>
            {
                command.CommandText = @"delete from DailyRecord
                                                where id = @dailyResultID";
                command.Parameters.Add("@dailyResultID", SqlDbType.Int).Value = dailyResultID;

                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }

        public bool InsertDialyRecord(DailyRecord dailyResult)
        {
            bool succes = false;
            Execute((command) =>
            {

                command.CommandText = @"INSERT INTO DailyRecord (IdEmployee, IdWorktype, [Start], [Finish])
                                        VALUES (@Id_Employee, @Id_Worktype , @Start, @Finish)";

                command.Parameters.Add("@Id_Employee", SqlDbType.VarChar).Value = dailyResult.IdEmployee;
                command.Parameters.Add("@Id_Worktype", SqlDbType.VarChar).Value = dailyResult.IdWorktype;
                command.Parameters.Add("@Start", SqlDbType.DateTime2).Value = dailyResult.Start;
                command.Parameters.Add("@Finish", SqlDbType.DateTime2).Value = dailyResult.Finish == null ? DBNull.Value : (object)dailyResult.Finish;
                if (command.ExecuteNonQuery() > 0)
                {
                    succes = true;
                }
            });
            return succes;
        }

        /// <summary>
        /// insert new Daily result entered from system
        /// </summary>
        /// <param name="dailyResult"></param>
        /// <returns></returns>
        public bool InsertNewDailyResultFromSystem(DailyRecord dailyResult)
        {
            bool success = false;
            Execute((command) =>
            {
                command.CommandText = @"insert into DailyRecord

                                        values (@IdEmployee,@StartTime,@FinishTime,@WorkTypeID)";
                command.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = dailyResult.IdEmployee;
                command.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = dailyResult.IdWorktype;
                command.Parameters.Add("@StartTime", SqlDbType.DateTime2).Value = dailyResult.Start;
                command.Parameters.Add("@FinishTime", SqlDbType.DateTime2).Value = dailyResult.Finish;

                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }

        public bool UpdateFinishDailyResult(DailyRecord daily_Result)
        {
            bool success = false;
            Execute((command) =>
            {
                command.CommandText = @"UPDATE DailyRecord
                                        SET Finish = GETDATE()
                                        WHERE ID = @ID";
                command.Parameters.Add("@ID", SqlDbType.VarChar).Value = daily_Result.Id;
                if (command.ExecuteNonQuery() > 1)
                {
                    success = true;
                }
            });
            return success;
        }

        /// <summary>
        /// vyhladá POSLEDNÝ finish time daného employee
        /// </summary>
        /// <param name="daily_Result"></param>
        /// <returns> vráti finish time buď null alebo hodnotu </returns>

        public DailyRecord GetLastDailyRecordByEmployeeId(int idEmployee)
        {
            DailyRecord selectedResult = null;
            Execute((command) =>
            {
               
                command.CommandText = @"Select [ID], [IdEmployee], [Start], [Finish], [IdWorktype] 
                                        from [dbo].[DailyRecord] 
                                        where IdEmployee= @IdEmployee
                                         and CONVERT(date,[Start]) = CONVERT(date,GETDATE()) order by [start] desc";
                command.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = idEmployee;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        selectedResult = new DailyRecord
                        {
                            Id = reader.GetInt32(0),
                            IdEmployee = reader.GetInt32(1),
                            Start = reader.GetDateTime(2),
                            Finish = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            IdWorktype = reader.GetInt32(4)
                        };
                    }
                }
            });
            return selectedResult;
        }

        /// <summary>
        /// gets daily result by its ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>DailyRusult</returns>
        public DailyRecord GetDailyResultByID(int dailyResultId)
        {
            DailyRecord ret = new DailyRecord();
            Execute((command) =>
            {
                command.CommandText = @"select * from DailyRecord where id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = dailyResultId;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        ret.Id = reader.GetInt32(0);
                        ret.IdEmployee = reader.GetInt32(1);
                        ret.Start = reader.GetDateTime(2);
                        ret.Finish = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                        ret.IdWorktype = reader.GetInt32(4);
                    }
                }
            });
            return ret;
        }

        /// <summary>
        /// this method make unicorn farts
        /// </summary>
        /// <param name="daily_Result"></param>
        /// <returns>true if update happend, false if not</returns>
        public bool UpdateDailyRecord(DailyRecord updatedDailyResult)
        {
            bool success = false;
            Execute((command) =>
            {
                command.CommandText = @"update DailyRecord 
                                        set Start=@start,Finish=@finish,IdWorktype=@idWorkType
                                        where id = @dailyResultID";
                command.Parameters.Add("@start", SqlDbType.DateTime2).Value = updatedDailyResult.Start;
                command.Parameters.Add("@finish", SqlDbType.DateTime2).Value = updatedDailyResult.Finish;
                command.Parameters.Add("@idWorkType", SqlDbType.Int).Value = updatedDailyResult.IdWorktype;
                command.Parameters.Add("@dailyResultID", SqlDbType.Int).Value = updatedDailyResult.Id;

                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }
        
        public int GetYearOfEmploymentStartByEmployee(int IdEmployee)
        {
            int year = 0;
            Execute((command) =>
            {
                command.CommandText = @"select year(min (dr.Start) )
                                                from DailyRecord  as dr
                                                where
                                                dr.IdEmployee=@idEmployee";

                command.Parameters.Add("@idEmployee", SqlDbType.Int).Value = IdEmployee;
                Int32.TryParse(command.ExecuteScalar().ToString(), out year);

            });
            return year;

        }
    }
}
