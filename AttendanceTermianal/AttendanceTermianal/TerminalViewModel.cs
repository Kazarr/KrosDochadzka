﻿using Data.Model;
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
        private Empolyee _empolyee = new Empolyee();
        public string CurrentDate()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
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

        public string EmployeeDescription(int id, string work)
        {
            string fullName = $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id).FirstName} " +
                                $"{ManagerRepository.PersonRepository.GetPersonByIdEmployee(id).LastName} " +
                                $"{work} " + 
                                $"{DateTime.Now}";
            return fullName;
        }
        public Tuple<bool, int> IsCorrectId(string input)
        {
            int Id = 0;
            bool isOk = false;
            if (!isOk)
            {
                isOk = int.TryParse(input, out Id); 
                return new Tuple<bool, int>(true, Id);
            }
            return new Tuple<bool, int>(false, Id);
        }

        public bool CorrectEmp(string input)
        {
            try
            {
                if (ManagerRepository.EmployeeRepository.GetEmpolyeeByID(int.Parse(input)).Id.Equals(int.Parse(input)))
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


        public void StartWork(int id_employee, int id_worktype)
        {
            _result.IdWorktype = id_worktype;
            _result.IdEmployee = id_employee;
            _result.Id = ManagerRepository.DailyResultRepository.InsertDialyResult(_result);           
        }
        public bool FinishWork(int id_employee)
        {
            _result.IdEmployee = id_employee;
            return ManagerRepository.DailyResultRepository.UpdateFinishDailyResult(_result);
        }
    }
}
