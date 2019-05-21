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

        private void StartWork(int idEmployee, EnumWorkType type)
        {
            DailyResult result = new DailyResult();
            result.Start = DateTime.Now;
            result.Finish = null;
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            ManagerRepository.DailyResultRepository.InsertDialyResult(result);
        }

        public void FinishWork(int idEmployee)
        {
            DailyResult result = ManagerRepository.DailyResultRepository.GetResultByIdWithoutFinishInCurrentDay(idEmployee);
            if (result != null)
            {
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
