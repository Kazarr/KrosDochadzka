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
        private RepositoryFactory _repositoryFactory;

        public LogicTerminal()
        {
            _repositoryFactory = new RepositoryFactory();
        }
        private void StartWork(int idEmployee, EnumWorkType type)
        {
            DailyRecord result = new DailyRecord();
            result.Start = DateTime.Now;
            result.Finish = null;
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            _repositoryFactory.GetDailyRecordRepository().InsertDialyResult(result);
        }

        public void FinishWork(int idEmployee)
        {
            DailyRecord result = _repositoryFactory.GetDailyRecordRepository().GetResultByIdWithoutFinishInCurrentDay(idEmployee);
            if (result != null)
            {
                result.Finish = DateTime.Now;
                _repositoryFactory.GetDailyRecordRepository().UpdateDailyResult(result);
            }
        }

        public bool CheckIfDailyResultExist(int idEmployee, EnumWorkType type)
        {
            DailyRecord result = new DailyRecord();
            result.IdEmployee = idEmployee;
            result.IdWorktype = (int)type;
            return _repositoryFactory.GetDailyRecordRepository().CheckIfDailyResultExist(result);
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
            twoLastResult = _repositoryFactory.GetDailyRecordRepository().SelectTwoLastResults(result);
            // Ak sa do listu uložia presne 2 záznamy s rovnakým WorkType(work) znamená to že zamestnanec za jeden deň viackrát prišiel a odišiel z roboty
            if (twoLastResult.Count == 2)
            {
                if (twoLastResult[0].IdWorktype == twoLastResult[1].IdWorktype)
                {
                    DailyRecord newResult = new DailyRecord();
                    newResult.IdEmployee = idEmployee;
                    newResult.Finish =_repositoryFactory.GetDailyRecordRepository().SelectLastStartAndFinish(result).Finish;
                    newResult.Start = _repositoryFactory.GetDailyRecordRepository().SelectLastStartAndFinish(result).Start;
                    _repositoryFactory.GetDailyRecordRepository().InsertInBlankSpace(newResult);
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
