using System;
using System.Data.SqlClient;
using Data.Repository;
using Logic;

namespace AttendanceSystem
{  
    class LoginViewModel
    {
       private LogicSystem _logic;

        public LoginViewModel(LogicSystem logic)
        {
            _logic = logic;
        }
        public bool CheckLogin(int id, string password)
        {
            return _logic.CheckLogin(id,password);
        }

        public string GenerateDb()
        {
            return _logic.GenerateDb();
        }
        public bool GenerateTables()
        {
            return _logic.GenerateTables();
        }

        public SqlConnectionStringBuilder GetSqlConnectionStringBuilder()
        {
            return _logic.GetSqlConnectionStringBuilder();
        }

        public void SaveConnectionString(string connectionString)
        {
            _logic.SaveConnectionString(connectionString);
        }

        public bool HasDatabase()
        {
            return _logic.HasDatabase();
        }
    }
}
