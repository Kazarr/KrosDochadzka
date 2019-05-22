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
        private const int MINHOURSFORLUNCHBREAKTIME = 4;
        private const int LUNCHBREAKTIME = 30;

        private DaySummaryRepository _daySummaryRepository;
        private EmployeeRepository _employeeRepository;
        private PersonRepository _personRepository;
        private WorkTypeRepository _workTypeRepository;
        private DailyRecordRepository _dailyRecordRepository;

        public LogicSystem()
        {
            _daySummaryRepository = new RepositoryFactory().GetDaySummaryRepository();
            _employeeRepository = new RepositoryFactory().GetEmployeeRepository();
            _personRepository = new RepositoryFactory().GetPersonRepository();
            _workTypeRepository = new RepositoryFactory().GetWorkTypeRepository();
            _dailyRecordRepository = new RepositoryFactory().GetDailyRecordRepository();
        }

        public IEnumerable<WorkType> GetWorkType()
        {
            return _workTypeRepository.GetWorkType();
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

        public IEnumerable<Person> GetPersonEmployeesPlebs(int idSupervisor)
        {
            return _personRepository.GetPersonEmployeesPlebs(idSupervisor);
        }

        public bool InsertNewDailyResultFromSystem(DailyRecord dailyResult)
        {
            return _dailyRecordRepository.InsertNewDailyResultFromSystem(dailyResult);
        }

        public IEnumerable<Person> GetPersonsEmployees()
        {
            return _personRepository.GetPersonsEmployees();
        }

        public bool UpdateDailyResult(DailyRecord updatedDailyResult)
        {
            return _dailyRecordRepository.UpdateFinishDailyResult(updatedDailyResult);
        }

        public Person GetPersonByIdEmployee(int employeeId)
        {
            return _personRepository.GetPersonByIdEmployee(employeeId);
        }

        public Employee GetEmpolyeeByID(int id)
        {
            return _employeeRepository.GetEmpolyeeByID(id);
        }

        public Employee GetEmpolyeeByIdPerson(int id)
        {
            return _employeeRepository.GetEmpolyeeByIdPerson(id);
        }

        public void SaveConnectionString(string connectionString)
        {
            Data.Properties.Settings.Default.ConnectionString = connectionString;
            Data.Properties.Settings.Default.Save();
        }

        public void DeleteEmployee(Employee e)
        {
            _employeeRepository.DeleteEmployee(e);
        }

        public void DeleteDailyResultByIdEmployee(int id)
        {
            _dailyRecordRepository.DeleteDailyResultByIdEmployee(id);
        }

        public bool HasDatabase()
        {
            bool ret = false;
            RepositoryFactory managerRepository = new RepositoryFactory();
            if (managerRepository.GetDataBaseName() == DB_NAME)
            {
                ret = true;
            }
            return ret;
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
            DaySummary daySummary = new DaySummary
            {
                Date = date.Date.ToString("MM-dd-yyyy"),
                WorkArrivalTime = _daySummaryRepository.GetArrivalTime(date, idEmployee),
                WorkLeavingTime = _daySummaryRepository.GetLeavingTime(date, idEmployee),
                LunchBreak = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Lunch),
                HolidayTime = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Holiday),
                HomeOffice = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.HomeOffice),
                BusinessTrip = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.BusinessTrip),
                Doctor = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Doctor),
                Private = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Private),
                Other = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, (int)EnumWorkType.Other)
            };

            daySummary.TotalTimeWorked = CalculateWorkedTime(daySummary);

            return daySummary;

        }

        private TimeSpan? CalculateWorkedTime(DaySummary daySummary)
        {
            daySummary.TotalTimeWorked = daySummary.WorkLeavingTime - daySummary.WorkArrivalTime - daySummary.HolidayTime
                 - daySummary.Doctor - daySummary.Private - daySummary.Other;
            //ak pocet odrobenych hodin je viac ako 4 ma zamestnanec pravo na obed
            if (daySummary.TotalTimeWorked > TimeSpan.FromHours(MINHOURSFORLUNCHBREAKTIME))
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak > TimeSpan.FromMinutes(LUNCHBREAKTIME)
                    ? daySummary.LunchBreak
                    : TimeSpan.FromMinutes(LUNCHBREAKTIME);
            }
            else
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak;
            }

            return daySummary.TotalTimeWorked;
        }

        public List<DaySummary> GetSummariesByMonth(string monthAndYear, int employeeID)
        {
            string month = monthAndYear.Split(' ')[0];
            int year = Convert.ToInt32(monthAndYear.Split(' ')[1]);
            List<DaySummary> myListOfDays = new List<DaySummary>();
            int numberOfMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;

            DateTime dt = new DateTime(year, numberOfMonth, 1);
            while (dt.Month == numberOfMonth)
            {
                myListOfDays.Add(CreateDaySummary(dt, employeeID));
                dt = dt.AddDays(1);
            }

            return myListOfDays;
        }

        public bool CheckLogin(int id, string password)
        {
            return _employeeRepository.CheckLogin(id, CalculateMD5Hash(password));
        }

        private int InsertFullEmployee(Employee employee)
        {
            employee.Password = CalculateMD5Hash(employee.Password);
            return _employeeRepository.InsertFullEmployee(employee);
        }

        public bool ChangePasswordByEmployeeId(int employeeID, string password)
        {
            return _employeeRepository.ChangePassword(employeeID, CalculateMD5Hash(password));
        }

        public void UpdateEmployee(Person person, int permission, Person supervisor)
        {
            Employee employee = new Employee
            {
                Permision = permission
            };

            //Person p = new Person() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Adress = adress };
            if (supervisor == null)
            {
                employee.IdSupervisor = employee.Id;
            }
            else
            {
                employee.IdSupervisor = _employeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
            }
            _employeeRepository.UpdateEmployee(employee, person);


        }
        
        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string adress, int permission, Person supervisor, string password)
        {
            Person person = new Person() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Adress = adress };
            person.Id = _personRepository.InsertPerson(person);
            Employee employee = new Employee() { Password = password, IdPerson = person.Id, Permision = permission };
            if (supervisor == null)
            {
                employee.IdSupervisor = InsertFullEmployee(employee);
                employee.Id = employee.IdSupervisor.Value;
                _employeeRepository.UpdateSupervisor(employee);
            }
            else
            {
                employee.IdSupervisor = _employeeRepository.GetEmpolyeeByIdPerson(supervisor.Id).Id;
                InsertFullEmployee(employee);
            }


        }

        public List<int> GetYearsFromEmploymentStartByEmployee(int employeeID)
        {
            int firstYear = _dailyRecordRepository.GetYearOfEmploymentStartByEmployee(employeeID);
            //v pripade ze metoda vrati 0, zamestnanec nema ziadne zaznamy (len teraz zacal pracovat), tak mu nadstavime terajsi rok ako 
            //jeho prvy rok
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
