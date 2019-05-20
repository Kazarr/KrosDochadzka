using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicTerminal
    {
        //private DailyResult _result; 
        //private Employee _empolyee = new Employee();

        //public DailyResult SetDailyResult(int id_employee, EnumWorkType type)
        //{
        //    _result.IdWorktype = (int)type;
        //    _result.IdEmployee = id_employee;
        //    return _result;
        //}

        private void StartWork(int idEmployee, EnumWorkType type)
        {
            DailyResult result = new DailyResult();
            result.Start = DateTime.Now;
            result.Finish = null;
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            ManagerRepository.DailyResultRepository.InsertDialyResult(result);
        }
        // toto kurva urob
       //načítať dailyResult na zaklade id zamestnanca pre dnešný deň, kde je finish null a ten následne updatetovať

        public void FinishWork(int idEmployee)
        {
            if (ManagerRepository.DailyResultRepository.GetFinishDailyResult(idEmployee) == null)
            {
                DailyResult result = new DailyResult();
                result = ManagerRepository.DailyResultRepository.GetResultByIdWithoutFinishInCurrentDay(idEmployee);
                result.Finish = DateTime.Now;
                ManagerRepository.DailyResultRepository.UpdateDailyResult(result);
            }            
        }

        public bool CheckIfDailyResultExist(int idEmployee, EnumWorkType type)
        {
            DailyResult result = new DailyResult();
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            return ManagerRepository.DailyResultRepository.CheckIfDailyResultExist(result);
        }

        /// <summary>
        /// Záplní okno v prípade viacnásobného príchodu a odchodu
        /// </summary>
        /// <param name="idEmployee"></param>
        /// <param name="type"></param>
        public void FillBlankSpace(int idEmployee, EnumWorkType type)
        {
            DailyResult result = new DailyResult();
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            List<DailyResult> twoLastResult = new List<DailyResult>();
            twoLastResult = ManagerRepository.DailyResultRepository.SelectTwoLastResults(result);
            // Ak sa do listu uložia presne 2 záznamy s rovnakým WorkType(work) znamená to že zamestnanec za jeden deň viackrát prišiel a odišiel z roboty
            if (twoLastResult.Count == 2)
            {
                if (twoLastResult[0].IdWorktype == twoLastResult[1].IdWorktype)
                {
                    DailyResult newResult = new DailyResult();
                    newResult.IdEmployee = idEmployee;
                    newResult.Finish = ManagerRepository.DailyResultRepository.SelectLastStartAndFinish(result).Finish;
                    newResult.Start = ManagerRepository.DailyResultRepository.SelectLastStartAndFinish(result).Start;
                    ManagerRepository.DailyResultRepository.InsertInBlankSpace(newResult);
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
