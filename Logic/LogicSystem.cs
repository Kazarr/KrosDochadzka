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
        private PermissionRepository _permissionRepository;

        public LogicSystem()
        {
            _daySummaryRepository = new RepositoryFactory().GetDaySummaryRepository();
            _employeeRepository = new RepositoryFactory().GetEmployeeRepository();
            _personRepository = new RepositoryFactory().GetPersonRepository();
            _workTypeRepository = new RepositoryFactory().GetWorkTypeRepository();
            _dailyRecordRepository = new RepositoryFactory().GetDailyRecordRepository();
            _permissionRepository = new RepositoryFactory().GetPermissionRepository();
        }

        public string SelectPermissionNameById(int permision)
        {
            return _permissionRepository.SelectPermissionNameById(permision);
        }

        public int SelectPermissionIdByName(string name)
        {
            return _permissionRepository.SelectPermissionIdByName(name);
        }

        public IEnumerable<WorkType> GetWorkType()
        {
            return _workTypeRepository.GetWorkType();
        }

        public IList<Person> GetPersonEmployeesSupervisors()
        {
            return _personRepository.GetPersonEmployeesSupervisors();
        }

        public List<string> SelectPermissionName()
        {
            return _permissionRepository.SelectPermissionName();
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

        public bool UpdateDailyRecord(DailyRecord updatedDailyResult)
        {
            return _dailyRecordRepository.UpdateDailyRecord(updatedDailyResult);
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

        public void DeleteEmployee(Employee e,int supervisorID)
        {
            _employeeRepository.DeleteEmployee(e,supervisorID);
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
        

        private List<DaySummary> CreateDaySummary(string monthAndYear, int idEmployee)
        {
            string month = monthAndYear.Split(' ')[0];
            int year = Convert.ToInt32(monthAndYear.Split(' ')[1]);
            int numberOfMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;

            DateTime date = new DateTime(year, numberOfMonth, 1);
            List<DailyRecord> dailyRecords = _daySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee);
            List<DaySummary> monthRecords = new List<DaySummary>();

            while (date.Month == numberOfMonth)
            {
                DaySummary daySummary = new DaySummary
                {
                    Date = date.ToString("M/d/yyyy")
                };

                foreach (var item in dailyRecords)
                {
                    if (item.Start.ToString().Contains(daySummary.Date))
                    {
                        switch (item.IdWorktype)
                        {
                            case (int)EnumWorkType.Work:
                                if (daySummary.WorkArrivalTime==null || daySummary.WorkArrivalTime>item.Start)
                                {
                                    daySummary.WorkArrivalTime = item.Start;
                                }
                                daySummary.WorkLeavingTime = item.Finish;
                                break;
                            case (int)EnumWorkType.Lunch:
                                daySummary.LunchBreak += (TimeSpan)(item.Finish - item.Start);
                                break;
                            case (int)EnumWorkType.Holiday:
                                daySummary.HolidayTime += (TimeSpan)(item.Finish - item.Start);
                                break;
                            case (int)EnumWorkType.HomeOffice:
                                daySummary.HomeOffice += (TimeSpan)(item.Finish - item.Start);
                                break;
                            case (int)EnumWorkType.BusinessTrip:
                                daySummary.BusinessTrip += (TimeSpan)(item.Finish - item.Start);
                                break;
                            case (int)EnumWorkType.Doctor:
                                daySummary.Doctor += (TimeSpan)(item.Finish - item.Start);
                                break;
                            case (int)EnumWorkType.Private:
                                daySummary.Private += (TimeSpan)(item.Finish - item.Start);
                                break;
                            case (int)EnumWorkType.Other:
                                daySummary.Other += (TimeSpan)(item.Finish - item.Start);
                                break;

                        }
                    }
                }
                daySummary.TotalTimeWorked = CalculateWorkedTime(daySummary);
                date = date.AddDays(1);
                monthRecords.Add(daySummary);
            }


        

            return monthRecords;

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
        return CreateDaySummary(monthAndYear,employeeID);
    }

    public bool CheckLogin(int employeeId, string password)
    {
        return _employeeRepository.CheckLogin(employeeId, CalculateMD5Hash(password));
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

    public void UpdateEmployee(Person person, Employee employee, Person supervisor)
    {
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
        Employee employee = new Employee() { Password = password, IdPerson = person.Id, IdPermission = permission, HiredDate=DateTime.Now };
        if (supervisor == null)
        {
            employee.IdSupervisor = InsertFullEmployee(employee);
            employee.Id = employee.IdSupervisor.Value;
            _employeeRepository.UpdateSupervisor(employee.Id);
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
