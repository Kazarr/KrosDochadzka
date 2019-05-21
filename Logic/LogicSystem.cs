using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public class LogicSystem
    {
        private string DB_NAME = "KROSDOCHADZKA";
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
            ManagerRepository managerRepository = new ManagerRepository();
            if (managerRepository.GetDataBaseName() == DB_NAME)
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
            ManagerRepository manager = new ManagerRepository();
            if (manager.GenerateDB())
            {
                ret = manager.GetDataBaseName();
            }
            return ret;
        }

        public bool GenerateTables()
        {
            ManagerRepository manager = new ManagerRepository();
            return manager.GenerateTables();
        }

        private DaySummary CreateDaySummary(DateTime date, int idEmployee)
        {
            DaySummary daySummary = new DaySummary
            {
                Date = date.Date.ToString("MM-dd-yyyy"),
                WorkArrivalTime = ManagerRepository.DaySummaryRepository.GetArrivalTime(date, idEmployee),
                WorkLeavingTime = ManagerRepository.DaySummaryRepository.GetLeavingTime(date, idEmployee),
                LunchBreak = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Lunch),
                HolidayTime = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Holiday),
                HomeOffice = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.HomeOffice),
                BusinessTrip = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.BusinessTrip),
                Doctor = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Doctor),
                Private = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Private),
                Other = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Other)
            };

            daySummary.TotalTimeWorked = daySummary.WorkLeavingTime - daySummary.WorkArrivalTime - daySummary.HolidayTime
                 - daySummary.Doctor - daySummary.Private - daySummary.Other;

            daySummary.TotalTimeWorked = CheckForLunchBreak(daySummary.TotalTimeWorked, daySummary.LunchBreak);
           
            return daySummary;

        }

        private TimeSpan? CheckForLunchBreak(TimeSpan? timeWorked,TimeSpan timeLunchBreak)
        {
            if (timeWorked > TimeSpan.FromHours(4))
            {
                timeWorked -= timeLunchBreak > TimeSpan.FromMinutes(30)
                    ? timeLunchBreak
                    : TimeSpan.FromMinutes(30);
            }
            else
            {
                timeWorked -= timeLunchBreak;
            }
            return timeWorked;
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
            return ManagerRepository.EmployeeRepository.CheckLogin(id, CalculateMD5Hash(password));
        }

        private int InsertFullEmployee(Employee employee)
        {
            employee.Password = CalculateMD5Hash(employee.Password);
            return ManagerRepository.EmployeeRepository.InsertFullEmployee(employee);
        }

        public bool ChangePasswordByEmployeeId(int id, string password)
        {
            return ManagerRepository.EmployeeRepository.ChangePassword(id, CalculateMD5Hash(password));
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
                employee.IdSupervisor = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
            }
            ManagerRepository.EmployeeRepository.UpdateEmployee(employee, p);


        }

        public void AddNewEmployee(Person person, Employee employee, Person supervisor)
        {

            person.Id = ManagerRepository.PersonRepository.InsertPerson(person);

            if (supervisor == null)
            {
                employee.IdSupervisor = InsertFullEmployee(employee);
                employee.Id = employee.IdSupervisor.Value;
                ManagerRepository.EmployeeRepository.UpdateSupervisor(employee);
            }
            else
            {
                employee.IdSupervisor = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
                InsertFullEmployee(employee);
            }


        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string adress, int permission, Person supervisor, string password)
        {
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            p.Id = ManagerRepository.PersonRepository.InsertPerson(p);
            Employee e = new Employee(password, p.Id, permission);
            if (supervisor == null)
            {
                e.IdSupervisor = InsertFullEmployee(e);
                e.Id = e.IdSupervisor.Value;
                ManagerRepository.EmployeeRepository.UpdateSupervisor(e);
            }
            else
            {
                e.IdSupervisor = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
                InsertFullEmployee(e);
            }


        }

        public List<int> GetYearsFromStart(int employeeID)
        {
            int firstYear = ManagerRepository.DailyResultRepository.GetYearOfFirstRecord(employeeID);
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
