using Data.Repository;
using Logic;

namespace AttendanceSystem
{  
    class LoginViewModel
    {
       private LogicSystem _logic = new LogicSystem();
        public bool CheckLogin(int id, string password)
        {
            return _logic.CheckLogin(id,password);
        }

        public bool GenerateDb()
        {
            return _logic.GenerateDb();
        }
        public bool GenerateTables()
        {
            return _logic.GenerateTables();
        }
       
    }
}
