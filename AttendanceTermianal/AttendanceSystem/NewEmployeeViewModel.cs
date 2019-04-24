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
    public class NewEmployeeViewModel
    {
        public Empolyee Empolyee { get; set; }
        public Person Person { get; set; }

        public NewEmployeeViewModel(int idPerson)
        {
            Empolyee = ManagerRepository.EmployeeRepository.GetEmpolyeeByID(idPerson);
            Person = ManagerRepository.PersonRepository.GetPersonById(idPerson);
        }

        public NewEmployeeViewModel()
        {
        }

        public Person GetPersonByEmployeeId(int employeeId)
        {
            return ManagerRepository.PersonRepository.GetPersonByIdEmployee(employeeId);
        }

        public void AddNewEmployee(string firstName, string lastName, string phoneNumber, string adress, decimal salary, int permission, Person supervisor, string password)
        {
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            p.Id = ManagerRepository.PersonRepository.InsertPerson(p);
            Empolyee e = new Empolyee(password,p.Id, supervisor.Id, permission,salary);
            ManagerRepository.EmployeeRepository.InsertFullEmployee(e);
            
        }

        public BindingList<Person> FillSupervisors()
        {
            return new BindingList<Person>(ManagerRepository.PersonRepository.GetPersonEmployeesSupervisors());
        }

        public void UpdateEmployee(string firstName, string lastName, string phoneNumber, string adress, decimal salary, int permission, Person supervisor, string password)
        {
            Empolyee.Password = password;
            Empolyee.Permision = permission;
            Empolyee.Salary = salary;
            Person p = new Person(firstName, lastName, phoneNumber, adress);
            ManagerRepository.EmployeeRepository.UpdateEmployee(Empolyee, p);
            

        }
    }
}
