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
        private DailyResult _result = new DailyResult();
        private Employee _empolyee = new Employee();

        public DailyResult SetDailyResult(int id_employee, EnumWorkType type)
        {
            _result.IdWorktype = (int)type;
            _result.IdEmployee = id_employee;
            return _result;
        }

        private void StartWork(int id_employee, EnumWorkType type)
        {
            _result.Id = RepositoryFactory.DailyResultRepository.InsertDialyResult(SetDailyResult(id_employee, type));
        }

        public bool FinishWork(int id_employee, EnumWorkType type)
        {
            if (RepositoryFactory.DailyResultRepository.GetFinishDailyResult(SetDailyResult(id_employee, type)) == null)
            {
                return RepositoryFactory.DailyResultRepository.UpdateFinishDailyResult(SetDailyResult(id_employee, type));
            }
            return false;
        }

        public bool CheckIfDailyResultExist(int id_employee, EnumWorkType type)
        {
            return RepositoryFactory.DailyResultRepository.CheckIfDailyResultExist(SetDailyResult(id_employee, type));
        }

        /// <summary>
        /// Záplní okno v prípade viacnásobného príchodu a odchodu
        /// </summary>
        /// <param name="id_employee"></param>
        /// <param name="type"></param>
        public void FillBlankSpace(int id_employee, EnumWorkType type)
        {
            _result.IdEmployee = id_employee;
            List<DailyResult> test = new List<DailyResult>();
            test = RepositoryFactory.DailyResultRepository.SelectTwoLastResults(_result);
            if (test.Count == 2)
            {
                if (test[0].IdWorktype == test[1].IdWorktype)
                {
                    _result.Finish = RepositoryFactory.DailyResultRepository.SelectLastStartAndFinish(_result).Finish;
                    _result.Start = RepositoryFactory.DailyResultRepository.SelectLastStartAndFinish(_result).Start;
                    RepositoryFactory.DailyResultRepository.InsertInBlankSpace(_result);
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
