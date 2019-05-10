using Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;

namespace Logic
{
    public class LogicSystem
    {
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
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        public bool GenerateDb()
        {
            ManagerRepository manager = new ManagerRepository();
            return manager.GenerateDB();
        }

        public bool GenerateTables()
        {
            ManagerRepository manager = new ManagerRepository();
            return manager.GenerateTables();
        }

        private DaySummary CreateDaySummary(DateTime date, int idEmployee)
        {
            DaySummary daySummary = new DaySummary();
       
            daySummary.Date = date.Date.ToString("MM-dd-yyyy");
            daySummary.WorkArrivalTime = ManagerRepository.DaySummaryRepository.GetArrivalTime(date, idEmployee);
            daySummary.WorkLeavingTime = ManagerRepository.DaySummaryRepository.GetLeavingTime(date, idEmployee);
            daySummary.LunchBreak = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, 2);
            daySummary.HolidayTime = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, 3);
            daySummary.HomeOffice = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, 4);
            daySummary.BusinessTrip = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, 5);
            daySummary.Doctor = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, 6);
            daySummary.Private = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, 7);
            daySummary.Other = ManagerRepository.DaySummaryRepository.GetTimeSpendOnDailyResults(date, idEmployee, 8);

            daySummary.TotalTimeWorked = daySummary.WorkLeavingTime - daySummary.WorkArrivalTime - daySummary.HolidayTime
                 - daySummary.Doctor - daySummary.Private - daySummary.Other;

            if (daySummary.TotalTimeWorked > TimeSpan.FromHours(4))
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak > TimeSpan.FromMinutes(30) ? daySummary.LunchBreak : TimeSpan.FromMinutes(30);
            }
            else
            {
                daySummary.TotalTimeWorked -= daySummary.LunchBreak;
            }
            return daySummary;

        }

        public List<DaySummary> GetSummariesByMonth(string month, int idEmployee)
        {
            List<DaySummary> myListOfDays = new List<DaySummary>();
            int numberOfMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;

            DateTime dt = new DateTime(2019, numberOfMonth, 1);
            while (dt.Month == numberOfMonth)
            {
                myListOfDays.Add(CreateDaySummary(dt, idEmployee));
                dt = dt.AddDays(1);
            }

            return myListOfDays;
        }

        public bool CheckLogin (int id, string password)
        {
            return ManagerRepository.EmployeeRepository.CheckLogin(id,CalculateMD5Hash(password));
        }

        private int InsertFullEmployee(Employee e)
        {
            e.Password = CalculateMD5Hash(e.Password);
            return ManagerRepository.EmployeeRepository.InsertFullEmployee(e);

        }

        public bool ResetPassword (int id, string password)
        {
            return ManagerRepository.EmployeeRepository.ResetPassword(id, CalculateMD5Hash(password));
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
            if(firstYear == 0)
            {
                firstYear = DateTime.Now.Year;
            }

            List<int> YearList = new List<int>();


            for (int i = firstYear; i <= DateTime.Now.Year+1; i++)
            {
                YearList.Add(i);
            }
            return YearList;
        }
    }
}
