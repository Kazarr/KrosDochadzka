﻿using Data.Model;
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
    public class DailyResultRepository
    {

        public IEnumerable<DailyResultWithWorkType> GetSpecifficDailyResult(int employeeID,DateTime date)
        {
            List<DailyResultWithWorkType> ret = new List<DailyResultWithWorkType>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select dr.id,dr.idEmployee,dr.Start,dr.Finish,w.Name 
                                                from DailyResult as dr
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
                            return ret;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public bool DeleteDailyResult (int dailyResultID)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"delete from DailyResult
                                                where id = @dailyResultID";
                        command.Parameters.Add("@dailyResultID", SqlDbType.Int).Value = dailyResultID;

                        if (command.ExecuteNonQuery()>0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message); 
                    return false;

                }
            }
        }

        public IEnumerable<DailyResult> GetDailyResult()
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
                        command.CommandText = @"SELECT * FROM DailyResult";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int dailyResultId = reader.GetInt32(0);
                                int employeeId = reader.GetInt32(1);
                                DateTime start = reader.GetDateTime(2);
                                DateTime finish = reader.GetDateTime(3);
                                int workTypeId = reader.GetInt32(4);

                                ret.Add(new DailyResult(dailyResultId, employeeId, start, finish, workTypeId));
                            }
                            return ret;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public int InsertDialyResult(DailyResult dailyResult)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO DailyResult (IdEmployee, IdWorktype)
                                                OUTPUT INSERTED.Id
                                                VALUES (@Id_Employee, @Id_Worktype)";
                        command.Parameters.Add("@Id_Employee", SqlDbType.VarChar).Value = dailyResult.IdEmployee;
                        command.Parameters.Add("@Id_Worktype", SqlDbType.VarChar).Value = dailyResult.IdWorktype;
                        return (int)command.ExecuteScalar();
                    }
                }
                catch (Exception e)
                {                    
                    Debug.WriteLine($"Error happend during  InsertDailyResult \n Error info:{e.Message}");
                    return 0;
                }
            }
        }
        
        /// <summary>
        /// insert new Daily result entered from system
        /// </summary>
        /// <param name="dailyResult"></param>
        /// <returns></returns>
        public bool InsertNewDailyResultFromSystem (DailyResult dailyResult)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"insert into DailyResult 
                                                values (@IdEmployee,@StartTime,@FinishTime,@WorkTypeID)";
                        command.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = dailyResult.IdEmployee;
                        command.Parameters.Add("@WorkTypeID", SqlDbType.Int).Value = dailyResult.IdWorktype;
                        command.Parameters.Add("@StartTime", SqlDbType.DateTime2).Value = dailyResult.Start;
                        command.Parameters.Add("@FinishTime", SqlDbType.DateTime2).Value = dailyResult.Finish;

                        if (command.ExecuteNonQuery()>0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  InsertNewDailyResultFromSystem \n Error info:{e.Message}");
                    return false;
                }
            }
        }

        public bool UpdateFinishDailyResult(DailyResult daily_Result)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"UPDATE DailyResult
                                               SET Finish = GETDATE()
                                                WHERE ID = @ID";
                        command.Parameters.Add("@ID", SqlDbType.VarChar).Value = daily_Result.Id;
                        if (command.ExecuteNonQuery() > 1)
                        {
                            return true;
                        }
                        else
                        {
                              return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  UpdateFinishDailyResult \n Error info:{e.Message}");
                    return false;

                }
            }
        }

        public bool CheckIfDailyResultExist(DailyResult daily_Result)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT id  FROM [KROSDOCHADZKA].[dbo].[DailyResult]
                                            where IdEmployee=@IdEmp and IdWorktype=@IdWT and  Finish is null";
                        command.Parameters.Add("@IdEmp", SqlDbType.Int).Value = daily_Result.IdEmployee;
                        command.Parameters.Add("@IdWT", SqlDbType.Int).Value = daily_Result.IdWorktype;
                        
                        if (command.ExecuteScalar()!=null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  CheckIfDailyResultExist \n Error info:{e.Message}");
                    return false;
                }
            }
        }
        
        /// <summary>
        /// vyhladá POSLEDNÝ finish time daného employee
        /// </summary>
        /// <param name="daily_Result"></param>
        /// <returns> vráti finish time buď null alebo hodnotu </returns>
        public DateTime? GetFinishDailyResult(DailyResult daily_Result)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"SELECT finish FROM [KROSDOCHADZKA].[dbo].[DailyResult]
                                            where IdEmployee=@IdEmp 
                                            and CONVERT(date,[Start]) = CONVERT(date,GETDATE()) order by [start] desc ";
                        command.Parameters.Add("@IdEmp", SqlDbType.Int).Value = daily_Result.IdEmployee;
                        DateTime? test = command.ExecuteScalar() as DateTime?;

                        return test;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  GetFinishDailyResult \n Error info:{e.Message}");

                    return DateTime.MinValue;
                }
            }
        }

        /// <summary>
        ///   method for geting number of records with months
        /// </summary>
        /// <param name="id"></param>
        /// <returns>months as key and number of records as value in dictionary</returns>
        public Dictionary<string, int> GetMonthsWithNumberOfRecords(int id)
        {
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select distinct datename (month, d.Start), count(*)
                                                from [dbo].[DailyResult] as d
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
                            return myDictionary;
                        }
                    }
                }
                catch (Exception e)
                {

                    Debug.WriteLine($"Error happend during  GetMonthsWithNumberOfRecords \n Error info:{e.Message}");
                    return null;

                }
            }
        }
        
        /// <summary>
        /// Select posledného startu a predposledného finishu
        /// </summary>
        /// <param name="dailyResult"></param>
        /// <returns>start a finish time</returns>
        public DailyResult SelectLastStartAndFinish(DailyResult dailyResult)
        {
            DailyResult result = new DailyResult();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select max([start]), min(finish) from dailyresult where id in
                            (select top 2 id from DailyResult where IdEmployee=@IdEmp and IdWorktype=1 order by [Start] desc) ";
                        command.Parameters.Add("@IdEmp", SqlDbType.Int).Value = dailyResult.IdEmployee;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {                                
                                result.Finish = reader.GetDateTime(0);
                                result.Start = reader.GetDateTime(1);
                            }
                            return result;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  SelectLastStartAndFinish \n Error info:{e.Message}");
                    return null;
                }
            }
        }
        
        /// <summary>
        /// Select posledných dvoch záznamov zamestnanca(Employee) 
        /// </summary>
        /// <param name="dailyResult"></param>
        /// <returns>List posledných dvoch záznamov </returns>
        public List<DailyResult> SelectTwoLastResults(DailyResult dailyResult)
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
                        command.CommandText = @"  select top 2 * from DailyResult where IdEmployee = @IdEmpl 
                                and CONVERT(date,[Start]) = CONVERT(date,GETDATE()) order by [start] desc";
                        command.Parameters.Add("@IdEmpl", SqlDbType.Int).Value = dailyResult.IdEmployee;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DailyResult dr = new DailyResult();
                                dr.Id = reader.GetInt32(0);
                                dr.IdEmployee = reader.GetInt32(1);
                                dr.Start = reader.GetDateTime(2);
                                dr.Finish = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                                dr.IdWorktype = reader.GetInt32(4);

                                ret.Add(dr);
                            }
                            return ret;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  SelectTwoLastResults \n Error info:{e.Message}");
                    return null;
                }
            }
        }
       
        /// <summary>
        /// Vloženie záznamu
        /// </summary>
        /// <param name="dailyResult"> obsahuje IdEmployee, start a finish </param>
        /// <returns>true alebo false v prípade úspešneho uloženia</returns>
        public bool InsertInBlankSpace(DailyResult dailyResult)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"Insert into DailyResult (IdEmployee,[Start],Finish,IdWorktype) 
                                            values (@Id_Employee,@start,@finish,8)";
                        command.Parameters.Add("@Id_Employee", SqlDbType.VarChar).Value = dailyResult.IdEmployee;
                        command.Parameters.Add("@start", SqlDbType.DateTime2).Value = dailyResult.Start;
                        command.Parameters.Add("@finish", SqlDbType.DateTime2).Value = dailyResult.Finish;
                        if (command.ExecuteNonQuery()>0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  InsertInBlankSpace \n Error info:{e.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// gets daily result by its ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>DailyRusult</returns>
        public DailyResult GetDailyResultByID (int dailyResultId)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"select * from DailyResult where id = @id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = dailyResultId;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DailyResult dailyResult = new DailyResult();
                            if (reader.Read())
                            {
                                
                                dailyResult.Id = reader.GetInt32(0);
                                dailyResult.IdEmployee = reader.GetInt32(1);
                                dailyResult.Start = reader.GetDateTime(2);
                                dailyResult.Finish = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                                dailyResult.IdWorktype = reader.GetInt32(4);
                            }
                            return dailyResult;
                        }


                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  GetDailyResultByID \n Error info:{e.Message}");
                    return null;

                }
            }
        }

        /// <summary>
        /// this method make unicorn farts
        /// </summary>
        /// <param name="daily_Result"></param>
        /// <returns>true if update happend, false if not</returns>
        public bool UpdateDailyResult(DailyResult updatedDailyResult)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"update DailyResult 
                                                set Start=@start,Finish=@finish,IdWorktype=@idWorkType
                                                where id = @dailyResultID";
                        command.Parameters.Add("@start", SqlDbType.DateTime2).Value = updatedDailyResult.Start;
                        command.Parameters.Add("@finish", SqlDbType.DateTime2).Value = updatedDailyResult.Finish;
                        command.Parameters.Add("@idWorkType", SqlDbType.Int).Value = updatedDailyResult.IdWorktype;
                        command.Parameters.Add("@dailyResultID", SqlDbType.Int).Value = updatedDailyResult.Id;

                        if (command.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  UpdateDailyResult \n Error info:{e.Message}");
                    return false;
                }
            }
        }

        public bool DeleteDailyResultByIdEmployee(int idEmployee)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM DailyResult
                                                WHERE idEmployee = @didEmployee";
                        command.Parameters.Add("@didEmployee", SqlDbType.Int).Value = idEmployee;

                        if (command.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Error happend during  DeleteDailyResultByIdEmployee \n Error info:{e.Message}");

                    return false;

                }
            }
        }
    }
}
