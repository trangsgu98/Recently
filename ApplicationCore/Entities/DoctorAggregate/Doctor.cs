using System;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore;
namespace ApplicationCore.Entities.DoctorAggregate
{
    
    public class Doctor : IAggregateRoot
    {
        public string DoctorId{get; set;}

        public string DoctorName{get; set;}

        public Gender Gender{get; set;}
        public string Phone{get; set;}

        //public string DeptName{get; set;}

       
        public string  DeptId{get; set;}// each doctor has a dept ID

        // private List<DocAppointment> _appointment = new List<DocAppointment>();
        // IEnumerable<DocAppointment> appointment => _appointment.AsReadOnly();

        public Doctor(){}
        public Doctor(string id, string name, Gender gender, string phone, string deptId)
        {
            this.DoctorId = id;
            this.DoctorName = name;
            this.Gender = gender;
            this.Phone = phone;
            this.DeptId= deptId;
        }
    }
}