using Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class DialyRecordRepository:ConnectionManager
    {

        public IEnumerable<DailyResultWithWorkType> GetSpecifficDailyResult(int employeeID,DateTime date)
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
                        DailyResultWithWorkType dailyResultWithWork = new DailyResultWithWorkType();
                        dailyResultWithWork.DailyResultID = reader.GetInt32(0);
                        dailyResultWithWork.IdEmployee = reader.GetInt32(1);
                        dailyResultWithWork.StartTime = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2);
                        dailyResultWithWork.FinishTime = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                        dailyResultWithWork.WorkType = reader.IsDBNull(4) ? "" : reader.GetString(4);

                        ret.Add(dailyResultWithWork);

                    }
                }
            });
            return ret;
               
        }

        public bool DeleteDailyResult (int dailyResultID)
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

        public IEnumerable<DailyRecord> GetDailyResult()
        {
            List<DailyRecord> ret = new List<DailyRecord>();
            Execute((command) => 
            {
                command.CommandText = @"SELECT * FROM DailyRecord";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dailyResultId = reader.GetInt32(0);
                        int employeeId = reader.GetInt32(1);
                        DateTime start = reader.GetDateTime(2);
                        DateTime finish = reader.GetDateTime(3);
                        int workTypeId = reader.GetInt32(4);

                        ret.Add(new DailyRecord(dailyResultId, employeeId, start, finish, workTypeId));
                    }

                }
            });
            return ret;
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
                command.Parameters.Add("@Finish", SqlDbType.DateTime2).Value = dailyResult.Finish == null ? DBNull.Value:(object)dailyResult.Finish;
                if (command.ExecuteNonQuery()>0)
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
        public bool InsertNewDailyResultFromSystem (DailyRecord dailyResult)
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

        public bool CheckIfDailyResultExist(DailyRecord daily_Result)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"SELECT id  FROM [dbo].[DailyRecord]
                                    where IdEmployee=@IdEmp and IdWorktype=@IdWT and  Finish is null";
                command.Parameters.Add("@IdEmp", SqlDbType.Int).Value = daily_Result.IdEmployee;
                command.Parameters.Add("@IdWT", SqlDbType.Int).Value = daily_Result.IdWorktype;

                if (command.ExecuteScalar() != null)
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
                //command.CommandText = @"Select [ID], [IdEmployee], [Start], [Finish], [IdWorktype] 
                //                        from [dbo].[DailyRecord] 
                //                        where IdEmployee= @IdEmployee and [Finish] is null 
                //                         and CONVERT(date,[Start]) = CONVERT(date,GETDATE()) order by [start] desc";
                command.CommandText = @"Select [ID], [IdEmployee], [Start], [Finish], [IdWorktype] 
                                        from [dbo].[DailyRecord] 
                                        where IdEmployee= @IdEmployee
                                         and CONVERT(date,[Start]) = CONVERT(date,GETDATE()) order by [start] desc";
                command.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = idEmployee;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        selectedResult = new DailyRecord();
                        selectedResult.Id = reader.GetInt32(0);
                        selectedResult.IdEmployee = reader.GetInt32(1);
                        selectedResult.Start = reader.GetDateTime(2);
                        selectedResult.Finish = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                        selectedResult.IdWorktype = reader.GetInt32(4);
                    }
                }
            });
            return selectedResult;
        }

        /// <summary>
        ///   method for geting number of records with months
        /// </summary>
        /// <param name="id"></param>
        /// <returns>months as key and number of records as value in dictionary</returns>
        public Dictionary<string, int> GetMonthsWithNumberOfRecords(int id)
        {
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            Execute((command) => 
            {
                command.CommandText = @"select distinct datename (month, d.Start), count(*)
                                        from [dbo].[DailyRecord] as d
                                        where d.idEmployee = @id
                                        group by datename (month, d.Start)
                                        order by datename (month, d.Start)";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myDictionary[reader.GetString(0)] = reader.GetInt32(1);
                    }
                }
            });
            return myDictionary;
        }
        
        /// <summary>
        /// Select posledného startu a predposledného finishu
        /// </summary>
        /// <param name="dailyResult"></param>
        /// <returns>start a finish time</returns>
        //public DailyRecord SelectLastStartAndFinish(int employeeId)
        //{
        //    DailyRecord ret = new DailyRecord();
        //    Execute((command) => 
        //    {
        //        command.CommandText = $@"select max([start]), min(finish) from DailyRecord where id in
        //            (select top 2 id from DailyRecord where IdEmployee=@IdEmp and IdWorktype=1 order by [Start] desc) ";
        //        command.Parameters.Add("@IdEmp", SqlDbType.Int).Value = employeeId;
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                ret.Finish = reader.GetDateTime(0);
        //                ret.Start = reader.GetDateTime(1);
        //            }
        //        }
        //    });
        //    return ret;
        //}
        
        /// <summary>
        /// Select posledných dvoch záznamov zamestnanca(Employee) 
        /// </summary>
        /// <param name="dailyResult"></param>
        /// <returns>List posledných dvoch záznamov </returns>
        public List<DailyRecord> SelectTwoLastResults(int employeeId)
        {
            List<DailyRecord> ret = new List<DailyRecord>();
            Execute((command) => 
            {
                command.CommandText = @"  select top 2 * from DailyRecord where IdEmployee = @IdEmpl 
                        and CONVERT(date,[Start]) = CONVERT(date,GETDATE()) order by [start] desc";
                command.Parameters.Add("@IdEmpl", SqlDbType.Int).Value = employeeId;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DailyRecord dr = new DailyRecord();
                        dr.Id = reader.GetInt32(0);
                        dr.IdEmployee = reader.GetInt32(1);
                        dr.Start = reader.GetDateTime(2);
                        dr.Finish = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                        dr.IdWorktype = reader.GetInt32(4);
                        ret.Add(dr);
                    }
                }
            });
            return ret;
        }
       
        /// <summary>
        /// Vloženie záznamu
        /// </summary>
        /// <param name="dailyResult"> obsahuje IdEmployee, start a finish </param>
        /// <returns>true alebo false v prípade úspešneho uloženia</returns>
        public bool InsertInBlankSpace(DailyRecord dailyResult)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = $@"Insert into DailyRecord (IdEmployee,[Start],Finish,IdWorktype) 
                                    values (@Id_Employee,@start,@finish,{(int)EnumWorkType.Other})";
                command.Parameters.Add("@Id_Employee", SqlDbType.VarChar).Value = dailyResult.IdEmployee;
                command.Parameters.Add("@start", SqlDbType.DateTime2).Value = dailyResult.Start;
                command.Parameters.Add("@finish", SqlDbType.DateTime2).Value = dailyResult.Finish;
                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }

        /// <summary>
        /// gets daily result by its ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>DailyRusult</returns>
        public DailyRecord GetDailyResultByID (int dailyResultId)
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

        public bool DeleteDailyResultByIdEmployee(int idEmployee)
        {
            bool success = false;
            Execute((command) => 
            {
                command.CommandText = @"DELETE FROM DailyRecord
                                        WHERE idEmployee = @didEmployee";
                command.Parameters.Add("@didEmployee", SqlDbType.Int).Value = idEmployee;

                if (command.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            });
            return success;
        }


        public int GetYearOfFirstRecord(int IdEmployee)
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
