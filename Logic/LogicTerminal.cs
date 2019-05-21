using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class LogicTerminal
    {
        private DialyRecordRepository _dailyRecordRepository;
        private PersonRepository _personRepository;
        private EmployeeRepository _employeeRepository;

        public LogicTerminal()
        {
            _dailyRecordRepository = new RepositoryFactory().GetDailyRecordRepository();
            _personRepository = new RepositoryFactory().GetPersonRepository();
            _employeeRepository = new RepositoryFactory().GetEmployeeRepository();
        }
        private void StartWork(int idEmployee, EnumWorkType type)
        {
            DailyRecord result = new DailyRecord();
            result.Start = DateTime.Now;
            result.Finish = null;
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            _dailyRecordRepository.InsertDialyResult(result);
        }

        public void FinishWork(int idEmployee)
        {
            DailyRecord result = _dailyRecordRepository.GetResultByIdWithoutFinishInCurrentDay(idEmployee);
            if (result != null)
            {
                result.Finish = DateTime.Now;
                _dailyRecordRepository.UpdateDailyResult(result);
            }
        }

        public Person GetPersonByIdEmployee(int id_employee)
        {
            return _personRepository.GetPersonByIdEmployee(id_employee);
        }

        public bool CheckIfDailyResultExist(int idEmployee, EnumWorkType type)
        {
            DailyRecord result = new DailyRecord();
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            return _dailyRecordRepository.CheckIfDailyResultExist(result);
        }

        public Employee GetEmpolyeeByID(int v)
        {
            return _employeeRepository.GetEmpolyeeByID(v);
        }

        /// <summary>
        /// Záplní okno v prípade viacnásobného príchodu a odchodu
        /// </summary>
        /// <param name="idEmployee"></param>
        /// <param name="type"></param>
        public void FillBlankSpace(int idEmployee, EnumWorkType type)
        {
            DailyRecord result = new DailyRecord();
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            List<DailyRecord> twoLastResult = new List<DailyRecord>();
            twoLastResult = _dailyRecordRepository.SelectTwoLastResults(result);
            // Ak sa do listu uložia presne 2 záznamy s rovnakým WorkType(work) znamená to že zamestnanec za jeden deň viackrát prišiel a odišiel z roboty
            if (twoLastResult.Count == 2)
            {
                if (twoLastResult[0].IdWorktype == twoLastResult[1].IdWorktype)
                {
                    DailyRecord newResult = new DailyRecord();
                    newResult.IdEmployee = idEmployee;
                    newResult.Finish = _dailyRecordRepository.SelectLastStartAndFinish(result).Finish;
                    newResult.Start = _dailyRecordRepository.SelectLastStartAndFinish(result).Start;
                    _dailyRecordRepository.InsertInBlankSpace(newResult);
                }
            }
        }

        public void ChangeWorkType(int idEmployee, EnumWorkType type)
        {
            if (!CheckIfDailyResultExist(idEmployee, type))
            {
                FinishWork(idEmployee);
                StartWork(idEmployee, type);
                FillBlankSpace(idEmployee, type);
            }
        }
    }
}
