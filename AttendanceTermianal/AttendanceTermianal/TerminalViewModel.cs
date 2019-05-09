using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTermianal
{

    
    public class TerminalViewModel
    {
      
        private DailyResult _result = new DailyResult();
        private Employee _empolyee = new Employee();
        public string CurrentDate()
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            return date;
        }
        public string CurrentDay()
        {
            string day = DateTime.Now.ToString("dddd");
            return day;
        }
        public string CurrentHourmin()
        {
            string day = DateTime.Now.ToString("HH:mm");
            return day;
        }
        public string CurrentSec()
        {
            string day = DateTime.Now.ToString("ss");
            return day;
        }

        public string DescriptionFullname(int id_employee)
        {
            string fullName = $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id_employee).FirstName} " +
                                $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id_employee).LastName} ";
            return fullName;
        }
        public string DescriptionWorkType(string wokrType)
        {
            string workT = $"{wokrType} ";
            return workT;
        }
        public string DescriptionDate()
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy" + " | " + "HH:mm");
            return date;
        }

        /// <summary>
        /// kontroluje či pod zadaným ID existuje nejaký employee
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CorrectEmp(string input)
        {
            try
            {
                var empoloyee = ManagerRepository.EmployeeRepository.GetEmpolyeeByID(int.Parse(input));
                if (empoloyee != null && empoloyee.Id.Equals(int.Parse(input)))
                {
                    return true;
                }
                else
                {
                    return false;
                }               
            }
            catch (FormatException)
            {
                return false;
            }      
        }
        /// <summary>
        /// Vloží(INSERT) do db.daily_result nový záznam
        /// </summary>
        /// <param name="id_employee"></param>
        /// <param name="type"></param>
        private void StartWork(int id_employee, EWorkType type)
        {
            _result.Id = ManagerRepository.DailyResultRepository.InsertDialyResult(SetResult(id_employee, type));
        }
        /// <summary>
        /// Update finish time posledného záznamu v prípade ak je prázdny
        /// </summary>
        /// <param name="id_employee"></param>
        /// <param name="type"></param>
        /// <returns> true ak vykoná update</returns>
        public bool FinishWork(int id_employee, EWorkType type)
        {
            //DateTime? daco = ManagerRepository.DailyResultRepository.GetFinishDailyResult(SetResult(id_employee, type));
            if (ManagerRepository.DailyResultRepository.GetFinishDailyResult(SetResult(id_employee, type)) == null)
            {
                return ManagerRepository.DailyResultRepository.UpdateFinishDailyResult(SetResult(id_employee, type));
            }
            return false;
        }
        /// <summary>
        /// výkoná update finish time posledného záznamu a vytvorí nový
        /// </summary>
        /// <param name="id_employee"></param>
        /// <param name="type"></param>
        public void ChangeWorkType(int id_employee, EWorkType type)
        {
            if (!CheckDailyResult(id_employee, type))
            {
                FinishWork(id_employee, type);
                StartWork(id_employee, type);
                FillBlankSpace(id_employee, type);
            }           
        }
        /// <summary>
        /// Kontroluje či existuje záznam
        /// </summary>
        /// <param name="id_employee"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool CheckDailyResult(int id_employee, EWorkType type)
        {
            return ManagerRepository.DailyResultRepository.CheckIfDailyResultExist(SetResult(id_employee, type));
        }
        public DailyResult SetResult(int id_employee, EWorkType type)
        {
            _result.IdWorktype = (int)type;
            _result.IdEmployee = id_employee;
            return _result;
        }
        /// <summary>
        /// Záplní okno v prípade viacnásobného príchodu a odchodu
        /// </summary>
        /// <param name="id_employee"></param>
        /// <param name="type"></param>
        public void FillBlankSpace(int id_employee, EWorkType type)
        {
            _result.IdEmployee = id_employee;
            List<DailyResult> test = new List<DailyResult>();
            test = ManagerRepository.DailyResultRepository.SelectTwoLastResults(_result);
            if (test.Count==2)
            {
                if (test[0].IdWorktype == test[1].IdWorktype)
                {
                    _result.Finish = ManagerRepository.DailyResultRepository.SelectLastStartAndFinish(_result).Finish;
                    _result.Start = ManagerRepository.DailyResultRepository.SelectLastStartAndFinish(_result).Start;
                    ManagerRepository.DailyResultRepository.InsertInBlankSpace(_result);
                }
            }
            
        }
    }
}
