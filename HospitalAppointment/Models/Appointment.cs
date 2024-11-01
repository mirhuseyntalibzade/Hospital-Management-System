using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointment.Models
{
    internal class Appointment
    {
        private static int _counter;
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Appointment(string patientName, string doctorName, DateTime startDate)
        {
            Id = _counter++;
            PatientName = patientName;
            DoctorName = doctorName;
            StartDate = startDate;
            EndDate = null;
        }

    }
}
