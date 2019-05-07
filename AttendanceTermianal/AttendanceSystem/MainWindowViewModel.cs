﻿using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class MainWindowViewModel
    {
        private Empolyee _empolyee;
        private Person _person;

        public MainWindowViewModel()
        {

        }

        public Person Person { get => _person; set {  _person = value;
                                                      Empolyee = GetEmpolyeeByPersonId(Person.Id);}}

        public Empolyee Empolyee { get => _empolyee; set => _empolyee = value; }

        public Empolyee GetEmployeeByID(int id)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByID(id);
        }


        public BindingList<Person> FillComboBox()
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonsEmployees().ToList());
        }

        public BindingList<Person> FillComboBox(int idSupervisor)
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonEmployeesPlebs(idSupervisor).ToList());
        }

        public BindingList<DaySummary> FillDataGridViewOverview(int id, string month)
        {
            return new BindingList<DaySummary>(ManagerRepository.DaySummaryRepository.GetSummariesByMonth(month, id));
        }

        public IDictionary<string, int> GetMonthWithNumberOfRecords(int id)
        {
            return ManagerRepository.DailyResultRepository.GetMonthsWithNumberOfRecords(id);
        }

        public Person GetPersonByEmployeeId(int employeeId)
        {
            return ManagerRepository.PersonRepository.GetPersonByIdEmployee(employeeId);
        }

        public Person GetPersonByEmployee(Person person)
        {
            return ManagerRepository.PersonRepository.GetPersonByIdEmployee(person.Id);
        }

        public Empolyee GetEmpolyeeByPersonId(int id)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(id);
        }

        public Empolyee GetEmpolyeeByPersonId(Person person)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(person);
        }

        public int GetEmployeeIdByPerson(Person selectedItem)
        {
            return ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(selectedItem.Id).Id;
        }

        public void DeleteEmployeePerson(Person person)
        {
            Empolyee e = ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(person.Id);
            ManagerRepository.DailyResultRepository.DeleteDailyResultByIdEmployee(e.Id);
            ManagerRepository.EmployeeRepository.DeleteEmployee(e);
            //ManagerRepository.PersonRepository.DeletePerson(person);//nemusime mazat z osoby
        }

        public BindingList<Person> FillPlebPerson(int employeeId)
        {
            BindingList<Person> ret = new BindingList<Person>();
            ret.Add(ManagerRepository.PersonRepository.GetPersonByIdEmployee(employeeId));
            return ret;
        }
        public bool ResetPassword()
        {
            return ManagerRepository.EmployeeRepository.ResetPassword(ManagerRepository.EmployeeRepository.GetEmpolyeeByIdPerson(Person.Id).Id, "0000");
        }
    }
}
