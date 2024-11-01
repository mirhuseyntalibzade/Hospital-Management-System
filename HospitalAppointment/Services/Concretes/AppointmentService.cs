using HospitalAppointment.Models;
using HospitalAppointment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalAppointment.Services.Concretes
{
    internal class AppointmentService : IAppointment
    {
        private readonly List<Appointment> Appointments;
        public AppointmentService()
        {
            Appointments = new List<Appointment>();
        }
        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public void EndAppointment(int id)
        {
            for (int i = 0; i < Appointments.Count; i++)
            {
                if (Appointments[i].Id == id)
                {
                    Appointments[i].EndDate = DateTime.Now;
                    break;
                }
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            return Appointments;
        }
        public Appointment GetAppointment(int id)
        {
            for (int i = 0; i < Appointments.Count; i++)
            {
                if (Appointments[i].Id == id)
                {
                    return Appointments[i];
                }
            }
            throw new Exception("null");
        }

        public List<Appointment> GetAllContinuingAppointments()
        {
            List<Appointment> activeAppointments = new List<Appointment>();
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.EndDate == null)
                {
                    activeAppointments.Add(appointment);
                }
            }
            return activeAppointments;
        }


        public List<Appointment> GetTodaysAppointments()
        {
            List<Appointment> todaysAppointments = new List<Appointment>();
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.StartDate.Year == DateTime.Now.Year && appointment.StartDate.Month == DateTime.Now.Month && appointment.StartDate.Day == DateTime.Now.Day)
                {
                    todaysAppointments.Add(appointment);
                }
            }
            return todaysAppointments;
        }

        public List<Appointment> GetWeeklyAppointments()
        {
            List<Appointment> weeklyAppointments = new List<Appointment>();
            
            DateTime currentDate = DateTime.Now.Date;
            DateTime appointmentDate;

            int currentDayOfWeek = (int)currentDate.DayOfWeek;
            int appointmentDayOfWeek;

            currentDayOfWeek = currentDayOfWeek == 0 ? 7 : currentDayOfWeek;

            DateTime startOfCurrentWeek = currentDate.AddDays(-currentDayOfWeek + 1);
            DateTime startOfAppointmentWeek;

            foreach (Appointment appointment in Appointments)
            {
                appointmentDate = appointment.StartDate.Date;
                appointmentDayOfWeek = (int)appointmentDate.DayOfWeek;
                appointmentDayOfWeek = appointmentDayOfWeek == 0 ? 7 : appointmentDayOfWeek;
                startOfAppointmentWeek = appointmentDate.AddDays(-appointmentDayOfWeek + 1);
                if (startOfCurrentWeek == startOfAppointmentWeek)
                {
                    weeklyAppointments.Add(appointment);
                }
            }
            return weeklyAppointments;
        }
    }
}
