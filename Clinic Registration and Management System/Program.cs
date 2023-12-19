using Clinic_Registration_and_Management_System.myDbContext;
using Clinic_Registration_and_Management_System.Tabels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Transactions;

namespace Clinic_Registration_and_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicaitonDbContext myDB = new ApplicaitonDbContext();
            //    string name = "MoSaid";
            //    string pass = "Mo2023Said";
            //    string email = "mohammed.abri17@gmail.comn";
            //    string phoneNumber = "95928585";
            //    Admin admin = new Admin
            //    {
            //        AdminName = name,
            //        AdminPassword = pass,
            //        Email = email,
            //        PhoneNumber = phoneNumber
            //    };
            //    string menu = "Welcome to Clinic Registration and Management System\n" +
            //        "please select the service you want:\n" +
            //        "   1- admin dashboeard\n" +
            //        "   2- patient dashboeard\n" +
            //        "   0- exit\n";
            //    string patientMenu = "- new paitent\n" +
            //        "- existing patient";
            //    while (true)
            //    {
            //        int userchoise = choise(menu, 0, 2);
            //        switch (userchoise)
            //        {
            //            case 1:
            //                Console.Write("Admin Name: ");
            //                string inputname = Console.ReadLine();
            //                Admin loginAdmin = (from Ad in myDB.admins
            //                                    where Ad.AdminName == inputname
            //                                    select Ad).FirstOrDefault();
            //                string inputpass = "";
            //                do
            //                {
            //                    Console.Write("Admin Password: ");
            //                    inputpass = Console.ReadLine();
            //                } while (loginAdmin.AdminPassword != inputpass);

            //                string Adminmenu = "1-View appointments\n" +
            //                    "2-Delete appointments\n" +
            //                    "3-update Appointment\n" +
            //                    "4-cancel appointment\n" +
            //                    "0-log out";
            //                switch (choise(Adminmenu, 0, 4))
            //                {
            //                    case 1:

            //                        foreach (Appointment app in myDB.appointments)
            //                        {
            //                            var patientName = (from pa in myDB.patients
            //                                               where pa.PationtID == app.Pati_Id
            //                                               select pa.PatientName).FirstOrDefault();
            //                            Console.WriteLine($"{app.Appoin_id} patient Name: {patientName}" +
            //                                $" Date: {app.Date} Time: {app.Time}");
            //                        }
            //                        break;
            //                    case 2:
            //                        Console.Write("Enter Appointment ID: ");
            //                        int appo_id;
            //                        if (int.TryParse(Console.ReadLine(), out appo_id))
            //                        {
            //                            Appointment appointmentToRemove = myDB.appointments.Find(appo_id);

            //                            if (appointmentToRemove != null)
            //                            {
            //                                myDB.appointments.Remove(appointmentToRemove);
            //                                myDB.SaveChanges();

            //                                Console.WriteLine($"Appointment with ID {appo_id} has been removed.");
            //                            }
            //                            else
            //                            {
            //                                Console.WriteLine($"Appointment with ID {appo_id} not found.");
            //                            }
            //                        }
            //                        else { Console.WriteLine("Enter righte ID"); }
            //                        break;
            //                    case 3:
            //                        Console.Write("Enter Appointment ID to update: ");
            //                        if (int.TryParse(Console.ReadLine(), out int appointmentId))
            //                        {
            //                            // Step 1: Retrieve the Appointment by ID
            //                            Appointment appointmentToUpdate = myDB.appointments.Find(appointmentId);

            //                            if (appointmentToUpdate != null)
            //                            {
            //                                // Step 2: Update the Date Property
            //                                Console.Write("Enter new date for the appointment: ");
            //                                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly newDate))
            //                                {
            //                                    appointmentToUpdate.Date = newDate;

            //                                    // Step 3: Save Changes to the Database
            //                                    myDB.SaveChanges();

            //                                    Console.WriteLine($"Appointment with ID {appointmentId} has been updated.");
            //                                }
            //                                else
            //                                {
            //                                    Console.WriteLine("Invalid date input.");
            //                                }
            //                            }
            //                            else
            //                            {
            //                                Console.WriteLine($"Appointment with ID {appointmentId} not found.");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            Console.WriteLine("Invalid input for Appointment ID.");
            //                        }
            //                        break;
            //                    case 4:
            //                        Console.Write("Enter Appointment ID to update: ");
            //                        if (int.TryParse(Console.ReadLine(), out appointmentId))
            //                        {
            //                            // Step 1: Retrieve the Appointment by ID
            //                            var appointmentToDelete = myDB.appointments.Find(appointmentId);

            //                            if (appointmentToDelete != null)
            //                            {
            //                                // Step 2: Delete the Appointment
            //                                myDB.appointments.Remove(appointmentToDelete);
            //                                myDB.SaveChanges();
            //                            }
            //                            else
            //                            {
            //                                Console.WriteLine($"Appointment with ID {appointmentId} not found.");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            Console.WriteLine("Invalid input for Appointment ID.");
            //                        }
            //                        break;
            //                    case 0:
            //                        break;
            //                    default:
            //                        break;
            //                }
            //                break;
            //            case 2:
            //                while (true)
            //                {
            //                    Console.WriteLine("1-Registraiton\n" +
            //                        "2-Specialization Selection\n" +
            //                        "3-Appointment Booking");
            //                    if (int.TryParse(Console.ReadLine(), out int choises))
            //                    {
            //                        switch (choises)
            //                        {
            //                            case 1:
            //                                Console.Write("Enter Patient Name: ");
            //                                string patient_name = Console.ReadLine();
            //                                Console.Write("Enter Patient Phone Number: ");
            //                                int paitent_number = int.Parse(Console.ReadLine());
            //                                Console.Write("Enter Patient Email: ");
            //                                string patient_email = Console.ReadLine();
            //                                Patient patient = new Patient
            //                                {
            //                                    PatientName = patient_name,
            //                                    ContactEmail = patient_email,
            //                                    ContactNumber = paitent_number
            //                                };
            //                                myDB.patients.Add(patient);
            //                                myDB.SaveChanges();
            //                                break;
            //                            case 2:
            //                                break; default: break;


            //                        }
            //                    }
            //                }
            //                break;
            //            case 0: break;
            //            default: break;
            //        }
            //    }
        }
        static int choise(string menu, int start, int end)
        {
            Console.WriteLine(menu);
            int choise;
            do
            {
                Console.Write("Your Selection: ");
                int.TryParse(Console.ReadLine(), out choise);
            } while (choise < start || choise > end);
            return choise;
        }
    }
}