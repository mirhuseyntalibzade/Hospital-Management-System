using HospitalAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointment.Services.Interfaces
{
    internal interface IAppointment
    {
        public void AddAppointment(Appointment appointment);
        public void EndAppointment(int id);
        public Appointment GetAppointment(int id);
        public List<Appointment> GetAllAppointments();
        public List<Appointment> GetWeeklyAppointments();
        public List<Appointment> GetTodaysAppointments();
        public List<Appointment> GetAllContinuingAppointments();


    }
}
