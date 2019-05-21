using Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using System.Data.SqlClient;

namespace Logic
{
    public class LogicSystem
    {
        private string DB_NAME = "KROSDOCHADZKA";
        private RepositoryFactory _repositoryFactory;

        public LogicSystem()
        {
            _repositoryFactory = new RepositoryFactory();
        }
        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public void SaveConnectionString(string connectionString)
        {
            Data.Properties.Settings.Default.ConnectionString = connectionString;
            Data.Properties.Settings.Default.Save();
        }

        public bool HasDatabase()
        {
            bool ret = false;
            RepositoryFactory managerRepository = new RepositoryFactory();
            if(managerRepository.GetDataBaseName() == DB_NAME)
            {
                ret = true;
            }
            return ret;
        }

        public SqlConnectionStringBuilder GetSqlConnectionStringBuilder(string initialCatalog)
        {
            ConnectionManager connectionManager = new ConnectionManager();
            return connectionManager.GetSqlConnectionStringBuilder(initialCatalog);
            
        }

        public SqlConnectionStringBuilder GetSqlConnectionStringBuilder()
        {
            ConnectionManager connectionManager = new ConnectionManager();
            return connectionManager.GetSqlConnectionStringBuilder("master");
        }

        public string GenerateDb()
        {
            string ret = "";
            RepositoryFactory manager = new RepositoryFactory();
            if (manager.GenerateDB())
            {
                ret = manager.GetDataBaseName();
            }
            return ret;
        }

        public bool GenerateTables()
        {
            RepositoryFactory manager = new RepositoryFactory();
            return manager.GenerateTables();
        }

        private DaySummary CreateDaySummary(DateTime date, int idEmployee)
        {
            DaySummary daySummary = new DaySummary();

            daySummary.Date = date.Date.ToString("MM-dd-yyyy");
            daySummary.WorkArrivalTime = _repositoryFactory.GetDaySummaryRepository().GetArrivalTime(date, idEmployee);
            daySummary.WorkLeavingTime = _repositoryFactory.GetDaySummaryRepository().GetLeavingTime(date, idEmployee);
            daySummary.LunchBreak = _repositoryFactory.GetDaySummaryRepository().GetTimeSpendOnDailyResults(date, idEmployee, 2);
            daySummary.HolidayTime = _repositoryFactory.GetDaySummaryRepository().GetTimeSpendOnDailyResults(date, idEmployee, 3);
            daySummary.HomeOffice = _repositoryFactory.GetDaySummaryRepository().GetTimeSpendOnDailyResults(date, idEmployee, 4);
            daySummary.BusinessTrip = _repositoryFactory.GetDaySummaryRepository().GetTimeSpendOnDailyResults(date, idEmployee, 5);
            daySummary.Doctor = _repositoryFactory.GetDaySummaryRepository().GetTimeSpendOnDailyResults(date, idEmployee, 6);
            daySummary.Private = _repositoryFactory.GetDaySummaryRepository().GetTimeSpendOnDailyResults(date, idEmployee, 7);
            daySummary.Other = _repositoryFactory.GetDaySummaryRepository().GetTimeSpendOnDailyResults(date, idEmployee, 8);

            daySummary.TotalTimeWorked = daySummary.WorkLeavingTime - daySummary.WorkArrivalTime - daySummary.HolidayTime
                 - daySummary.Doctor - daySummary.Private - daySummary.Other;

            if (daySummary.TotalTimeWorked > TimeSpan.FromHours(4))
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak > TimeSpan.FromMinutes(30)
                    ? daySummary.LunchBreak
                    : TimeSpan.FromMinutes(30);
            }
            else
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak;
            }
            return daySummary;

        }

        public List<DaySummary> GetSummariesByMonth(string monthAndYear, int idEmployee) 
       {
            string month = monthAndYear.Split(' ')[0];
            int year = Convert.ToInt32(monthAndYear.Split(' ')[1]);
            List<DaySummary> myListOfDays = new List<DaySummary>();
            int numberOfMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;

            DateTime dt = new DateTime(year, numberOfMonth, 1);
            while (dt.Month == numberOfMonth)
            {
                myListOfDays.Add(CreateDaySummary(dt, idEmployee));
                dt = dt.AddDays(1);
            }

            return myListOfDays;
        }

        public bool CheckLogin(int id, string password)
        {
            return _repositoryFactory.GetEmployeeRepository().CheckLogin(id, CalculateMD5Hash(password));
        }

        private int InsertFullEmployee(Employee e)
        {
            e.Password = CalculateMD5Hash(e.Password);
            return _repositoryFactory.GetEmployeeRepository().InsertFullEmployee(e);
        }

        public bool ChangePassword(int id, string password)
        {
            return _repositoryFactory.GetEmployeeRepository().ChangePassword(id, CalculateMD5Hash(password));
        }

        public void UpdateEmployee(string firstName, string lastName, string phoneNumber, string adress, int permission, Person supervisor)
        {
            Employee employee = new Employee();

            employee.Permision = permission;

            Person p = new Person(firstName, lastName, phoneNumber, adress);
            if (supervisor == null)
            {
                employee.IdSupervisor = employee.Id;
            }
            else
            {
                employee.IdSupervisor = _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(supervisor.Id).Id;
            }
            _repositoryFactory.GetEmployeeRepository().UpdateEmployee(employee, p);


        }

        public void AddNewEmployee(Person person, Employee employee, Person supervisor)
        {

            person.Id = _repositoryFactory.GetPersonRepository().InsertPerson(person);

            if (supervisor == null)
            {
                employee.IdSupervisor = InsertFullEmployee(employee);
                employee.Id = employee.IdSupervisor.Value;
                _repositoryFactory.GetEmployeeRepository().UpdateSupervisor(employee);
            }
            else
            {
                employee.IdSupervisor = _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(supervisor.Id).Id;
                InsertFullEmployee(employee);
            }


        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string adress, int permission, Person supervisor, string password)
        {
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            p.Id = _repositoryFactory.GetPersonRepository().InsertPerson(p);
            Employee e = new Employee(password, p.Id, permission);
            if (supervisor == null)
            {
                e.IdSupervisor = InsertFullEmployee(e);
                e.Id = e.IdSupervisor.Value;
                _repositoryFactory.GetEmployeeRepository().UpdateSupervisor(e);
            }
            else
            {
                e.IdSupervisor = _repositoryFactory.GetEmployeeRepository().GetEmpolyeeByIdPerson(supervisor.Id).Id;
                InsertFullEmployee(e);
            }


        }

        public List<int> GetYearsFromStart(int employeeID)
        {
            int firstYear = _repositoryFactory.GetDailyRecordRepository().GetYearOfFirstRecord(employeeID);
            if (firstYear == 0)
            {
                firstYear = DateTime.Now.Year;
            }

            List<int> YearList = new List<int>();


            for (int i = firstYear; i <= DateTime.Now.Year + 1; i++)
            {
                YearList.Add(i);
            }
            return YearList;
        }
    }
}
