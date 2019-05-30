using Data.Model;
using Data.Repository;
using System;

namespace Logic
{
    public class LogicTerminal
    {
        private DailyRecordRepository _dailyRecordRepository;
        private PersonRepository _personRepository;
        private EmployeeRepository _employeeRepository;

        public LogicTerminal()
        {
            _dailyRecordRepository = new RepositoryFactory().GetDailyRecordRepository();
            _personRepository = new RepositoryFactory().GetPersonRepository();
            _employeeRepository = new RepositoryFactory().GetEmployeeRepository();
        }

        public string DescriptionFullname(int employeeId)
        {
            Person person = new Person();
            person = _personRepository.GetPersonByIdEmployee(employeeId);
            return $"{person.FirstName} {person.LastName}";
        }

        /// <summary>
        /// kontroluje či pod zadaným ID existuje nejaký employee
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsCorrectEmp(int employeeId)
        {
            Employee empoloyee = _employeeRepository.GetEmpolyeeByID(employeeId);
            if (empoloyee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DailyRecord GetLastDailyRecordByEmployeeId(int employeeId)
        {
            return _dailyRecordRepository.GetLastDailyRecordByEmployeeId(employeeId);
        }

        public void CreateNewTimeBlock(int idEmployee, EnumWorkType type, DateTime startTime, DateTime? finishTime = null)
        {
            DailyRecord dailyRecord = new DailyRecord
            {
                Start = startTime,
                Finish = finishTime,
                IdEmployee = idEmployee,
                IdWorktype = (int)type
            };
            _dailyRecordRepository.InsertDialyRecord(dailyRecord);
        }

        public void UpdateFinishInTimeBlock(DailyRecord dailyRecord, DateTime finishTime)
        {
            dailyRecord.Finish = finishTime;
            _dailyRecordRepository.UpdateDailyRecord(dailyRecord);
        }

        public void CreateNewAndFinishPreviousRecord(int employeeId, EnumWorkType type)
        {
            DateTime currentTime = DateTime.Now;
            DailyRecord dailyRecord = _dailyRecordRepository.GetLastDailyRecordByEmployeeId(employeeId);
            if (dailyRecord != null)
            {
                if (dailyRecord.Finish == null)
                {
                    UpdateFinishInTimeBlock(dailyRecord, currentTime);
                }
                else
                {
                    CreateNewTimeBlock(employeeId, EnumWorkType.Other, (DateTime)dailyRecord.Finish, currentTime);
                }
            }
            CreateNewTimeBlock(employeeId, type, currentTime);
        }

        /// <summary>
        /// Ak pre daného zamestnanca neexistuje žiaden záznam pre dnešný deň, vytvorím nový záznam
        /// v ktorom mu nastavím start a finish time na aktuálny |||||DOVOD|||| - aby som nestratil čas odchodu,ak si zamestnanec nedal príchod
        /// </summary>
        /// <param name="employeeId"></param>
        public void ExitTimeBlock(int employeeId)
        {
            DailyRecord dailyRecord = GetLastDailyRecordByEmployeeId(employeeId);
            if (dailyRecord == null)
            {
                CreateNewTimeBlock(employeeId, EnumWorkType.Other, DateTime.Now, DateTime.Now);
            }
            else
            {
                UpdateFinishInTimeBlock(dailyRecord, DateTime.Now);
            }
        }

        /// <summary>
        /// HLavna funkcua pre buttony
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="type"></param>
        public void ProcessAction(int employeeId, EnumWorkType type)
        {
            if (type == EnumWorkType.Exit)
            {
                ExitTimeBlock(employeeId);
            }
            else
            {
                CreateNewAndFinishPreviousRecord(employeeId, type);
            }
        }
    }
}
