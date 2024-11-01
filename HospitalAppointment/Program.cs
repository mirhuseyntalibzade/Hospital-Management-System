using HospitalAppointment.Models;
using HospitalAppointment.Services.Concretes;
using HospitalAppointment.Services.Interfaces;

namespace HospitalAppointment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("""
                    1. Appointment yarat
                    2. Appointment-i bitir
                    3. Bütün appointment-lərə bax
                    4. Bu həftəki appointment-lərə bax
                    5. Bugünki appointment-lərə bax
                    6. Bitməmiş appointmentlərə bax
                    7. Menudan çıx
                    """);
            string answer;
            bool isExited = false;
            AppointmentService appointmentService = new AppointmentService();
            Appointment appointment;
            List <Appointment> appointments = new List<Appointment>();
            while (!isExited)
            {
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("What is your patients name?");
                        string patientName = Console.ReadLine();

                        Console.WriteLine("What is your doctors name?");
                        string doctorName = Console.ReadLine();

                        Console.WriteLine("What is the date of appointment (eg. 2024-01-01 )");
                        DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
                        appointment = new(patientName, doctorName, appointmentDate);
                        appointmentService.AddAppointment(appointment);
                        Console.WriteLine("done");
                        break;
                    case "2":
                        Console.WriteLine("Which appointment would you like to end? (takes id)");
                        int id = int.Parse(Console.ReadLine());
                        appointmentService.EndAppointment(id);
                        break;
                    case "3":
                        appointments = appointmentService.GetAllAppointments();
                        foreach (Appointment item in appointments)
                        {
                            Console.WriteLine($"""
                                Id: {item.Id}
                                Patient Name: {item.PatientName}
                                Doctor's Name: {item.DoctorName}
                                Start Date: {item.StartDate}
                                End Date: {item.EndDate}
                                """);
                        }
                        break;
                    case "4":
                        appointments = appointmentService.GetWeeklyAppointments();
                        foreach (Appointment item in appointments)
                        {
                            Console.WriteLine($"""
                                Id: {item.Id}
                                Patient Name: {item.PatientName}
                                Doctor's Name: {item.DoctorName}
                                Start Date: {item.StartDate}
                                End Date: {item.EndDate}
                                """);
                        }
                        break;
                    case "5":
                        appointments = appointmentService.GetTodaysAppointments();
                        foreach (Appointment item in appointments)
                        {
                            Console.WriteLine($"""
                                Id: {item.Id}
                                Patient Name: {item.PatientName}
                                Doctor's Name: {item.DoctorName}
                                Start Date: {item.StartDate}
                                End Date: {item.EndDate}
                                """);
                        }
                        break;
                    case "6":
                        appointments = appointmentService.GetAllContinuingAppointments();
                        foreach (Appointment item in appointments)
                        {
                            Console.WriteLine($"""
                                Id: {item.Id}
                                Patient Name: {item.PatientName}
                                Doctor's Name: {item.DoctorName}
                                Start Date: {item.StartDate}
                                End Date: {item.EndDate}
                                """);
                        }
                        break;
                    case "7":
                        Console.WriteLine("Menudan çıx");
                        isExited = true;
                        break;
                    default:
                        Console.WriteLine($"{answer} is not correct value.");
                        break;
                }
            }
        }
    }
}
