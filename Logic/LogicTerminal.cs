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
            ManagerRepository.DailyResultRepository.InsertDialyResult(result);
        }
        // toto kurva urob
       //načítať dailyResult na zaklade id zamestnanca pre dnešný deň, kde je finish null a ten následne updatetovať

        public bool FinishWork(int id_employee, EnumWorkType type)
        {
            if (ManagerRepository.DailyResultRepository.GetFinishDailyResult(SetDailyResult(id_employee, type)) == null)
            {
                return ManagerRepository.DailyResultRepository.UpdateDailyasdasdResult(SetDailyResult(id_employee, type));
            }
            return false;
        }

        public bool CheckIfDailyResultExist(int id_employee, EnumWorkType type)
        {
            return ManagerRepository.DailyResultRepository.CheckIfDailyResultExist(SetDailyResult(id_employee, type));
        }

        /// <summary>
        /// Záplní okno v prípade viacnásobného príchodu a odchodu
        /// </summary>
        /// <param name="id_employee"></param>
        /// <param name="type"></param>
        public void FillBlankSpace(int id_employee, EnumWorkType type)
        {
            _result.IdEmployee = id_employee;
            List<DailyResult> twoLastResult = new List<DailyResult>();
            twoLastResult = ManagerRepository.DailyResultRepository.SelectTwoLastResults(_result);
            // Ak sa do listu uložia presne 2 záznamy s rovnakým WorkType(work) znamená to že zamestnanec za jeden deň viackrát prišiel a odišiel z roboty
            if (twoLastResult.Count == 2)
            {
                if (twoLastResult[0].IdWorktype == twoLastResult[1].IdWorktype)
                {
                    _result.Finish = ManagerRepository.DailyResultRepository.SelectLastStartAndFinish(_result).Finish;
                    _result.Start = ManagerRepository.DailyResultRepository.SelectLastStartAndFinish(_result).Start;
                    ManagerRepository.DailyResultRepository.InsertInBlankSpace(_result);
                }
            }
        }

        public void ChangeWorkType(int id_employee, EnumWorkType type)
        {
            if (!CheckIfDailyResultExist(id_employee, type))
            {
                FinishWork(id_employee, type);
                StartWork(id_employee, type);
                FillBlankSpace(id_employee, type);
            }
        }
    }
}
