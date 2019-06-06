using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Data.Generator
{
    public class EmployeeGenerator
    {
        private RepositoryFactory _repositoryFactory;
        public List<int> GeneratedEmployeesId { get; private set; }
        public List<int> GeneratedSupervisorsId { get; private set; }
        private const int SUPERVISOR_CHANCE = 20;
        private PersonGenerator _personGenerator;
        private DailyRecordGenerator _dailyRecordGenerator;
        private Random r { get; set; }
        public bool Result { get; private set; }
        public bool Generating { get; private set; }
        public EmployeeGenerator(int employeeCount)
        {
            _repositoryFactory = new RepositoryFactory();
            GeneratedEmployeesId = new List<int>();
            GeneratedSupervisorsId = new List<int>();
            _personGenerator = new PersonGenerator(employeeCount);
            _dailyRecordGenerator = new DailyRecordGenerator();
            r = new Random();
        }
        
        public bool Generate(Action<int> reportProgress, Func<bool> cancelationPendint)
        {
            Generating = true;
            bool finishedPerson = _personGenerator.GenerateRandomPersons(reportProgress, cancelationPendint);
            bool finishedEmployee = GenerateEmployees(reportProgress, cancelationPendint);
            bool finishedDailyRecord = _dailyRecordGenerator.GiveRecordsToEmployee(reportProgress, cancelationPendint, GeneratedEmployeesId);
            Generating = false;
            return (finishedPerson && finishedEmployee && finishedDailyRecord);
        }

        private DateTime RandomDate()
        {
            DateTime start = new DateTime(2010, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }

        public Employee SetSupervisor(int i)
        {
            string pass = "4a7d1ed414474e4033ac29ccb8653d9b";
            int idPerson = i;
            int idPermission = 2;
            decimal salary = r.Next(1400, 2300);
            DateTime date = RandomDate();
            return new Employee() { Password = pass, IdPerson = idPerson, IdPermission = idPermission, Salary = salary, HiredDate = date };
        }

        public Employee SetEmployee(int i)
        {
            string pass = "4a7d1ed414474e4033ac29ccb8653d9b";
            int idPerson = i;
            int idSupervisor = GeneratedSupervisorsId[r.Next(0,GeneratedSupervisorsId.Count)];
            int idPermission = 1;
            decimal salary = r.Next(1000, 2500);
            DateTime date = RandomDate();
            return new Employee() { Password = pass, IdPerson = idPerson, IdSupervisor = idSupervisor, IdPermission = idPermission, Salary = salary, HiredDate = date };
        }

        public bool GenerateEmployees(Action<int> reportProgress, Func<bool> cancelationPendint)
        {
            bool finished = false;
            int count = 0; 
            GeneratedSupervisorsId.Add(1);
            for(int i = _personGenerator.generatedPersonsId[0]; i <= _personGenerator.generatedPersonsId.Last() && !cancelationPendint.Invoke(); i++ ,count++)
            {
                if (r.Next(1, 101) >= 20)
                {
                    GeneratedEmployeesId.Add(_repositoryFactory.GetEmployeeRepository().InsertFullEmployee(SetEmployee(i)));
                }
                else
                {
                    GeneratedEmployeesId.Add(_repositoryFactory.GetEmployeeRepository().InsertFullEmployee(SetSupervisor(i)));
                    GeneratedSupervisorsId.Add(GeneratedEmployeesId.Last());
                    _repositoryFactory.GetEmployeeRepository().UpdateSupervisor(GeneratedSupervisorsId.Last());
                }
                reportProgress.Invoke(((int)(((double)count / _personGenerator.generatedPersonsId.Count) * 100)));
            }
            if(GeneratedEmployeesId.Count == _personGenerator.generatedPersonsId.Count) { finished = true; }
            return finished;
        }

        //public void GenerateSupervisor()
        //{
        //    List<Person> people = _repositoryFactory.GetPersonRepository().GetPersons().ToList();
        //    for (int i = 5; i < people.Count - 700; i++)
        //    {
        //        _repositoryFactory.GetEmployeeRepository().InsertFullEmployee(SetSupervisor(i));
        //    }
        //}

        //public void GenerateEmployee()
        //{
        //    List<Person> people = _repositoryFactory.GetPersonRepository().GetPersons().ToList();
        //    for (int i = 200; i < people.Count - 1; i++)
        //    {
        //        _repositoryFactory.GetEmployeeRepository().InsertFullEmployee(SetEmployee(i));
        //    }
        //}
    }
}
