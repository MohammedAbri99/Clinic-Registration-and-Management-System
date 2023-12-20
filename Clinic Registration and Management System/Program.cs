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

            #region Add Admin
            //string name = "MoSaid";
            //string pass = "12344321";
            //string email = "mohammed.abri17@gmail.comn";
            //string phoneNumber = "95928585";
            //Admin admin = new Admin
            //{
            //    AdminName = name,
            //    AdminPassword = pass,
            //    Email = email,
            //    PhoneNumber = phoneNumber
            //};
            //myDB.admins.Add(admin);
            //myDB.SaveChanges();
            #endregion

            #region Add Clinic Specializations

            ////first specialization ============================================(1)
            //string specializationName = "Cardiology";
            //string specializatoinDesc = "Specializes in the diagnosis and treatment of heart-related conditions, including heart disease, hypertension, and heart failure.";
            //Specialization CardiologyClinic = new Specialization
            //{
            //    SpecializationName = specializationName,
            //    Description = specializatoinDesc,
            //};
            //myDB.specializations.Add(CardiologyClinic);

            ////second specialization ============================================(2)
            //Specialization OrthopedicClinic = new Specialization
            //{
            //    SpecializationName = "Orthopedic",
            //    Description = "Focuses on the musculoskeletal system, treating issues related to bones, joints, ligaments, tendons, and muscles. Common services include joint replacements, sports medicine, and fracture care.",
            //};
            //myDB.specializations.Add(OrthopedicClinic);

            ////third specialization ============================================(3)
            //Specialization DermatologyClinic = new Specialization
            //{
            //    SpecializationName = "Dermatology",
            //    Description = "Specializes in the diagnosis and treatment of skin, hair, and nail conditions. Dermatologists often address issues such as acne, eczema, skin cancer, and cosmetic dermatology.",
            //};
            //myDB.specializations.Add(DermatologyClinic);

            ////forth specialization ============================================(4)
            //Specialization PediatricClinic = new Specialization
            //{
            //    SpecializationName = "Pediatric",
            //    Description = "Focuses on the health and well-being of infants, children, and adolescents. Pediatric clinics provide a range of services, including vaccinations, well-child checkups, and treatment for common childhood illnesses.",
            //};
            //myDB.specializations.Add(PediatricClinic);
            //myDB.SaveChanges();
            #endregion

            string menu = "Welcome to Clinic Registration and Management System\n" +
                "please select the service you want:\n" +
                "   1- admin dashboeard\n" +
                "   2- patient dashboeard\n" +
                "   0- Exit\n";
            string patientMenu = "1- Registraiton\n" +
                "2- Specialization Selection\n" +
                "3- Appointment Booking\n" +
                "0- Exit";
            bool flag = true;
            while (flag)
            {
                int userchoise = choise(menu, 0, 2);
                switch (userchoise)
                {
                    case 1:
                        Console.Write("Admin Name: ");
                        string inputname = Console.ReadLine();
                        Admin loginAdmin = (from Ad in myDB.admins
                                            where Ad.AdminName == inputname
                                            select Ad).FirstOrDefault();
                        string inputpass = "";
                        do
                        {
                            Console.Write("Admin Password: ");
                            inputpass = Console.ReadLine();
                        } while (loginAdmin.AdminPassword != inputpass);

                        string Adminmenu = "1-View appointments\n" +
                            "2-Delete appointments\n" +
                            "3-update Appointment\n" +
                            "4-cancel appointment\n" +
                            "0-log out";
                        switch (choise(Adminmenu, 0, 4))
                        {
                            case 1:

                                foreach (Appointment app in myDB.appointments)
                                {
                                    var patientName = (from pa in myDB.patients
                                                       where pa.PatientID == app.PatientId
                                                       select pa.PatientName).FirstOrDefault();
                                    Console.WriteLine($"{app.Appoin_id} patient Name: {patientName}" +
                                        $" Date: {app.Date} Time: {app.Time}");
                                }
                                break;
                            case 2:
                                Console.Write("Enter Appointment ID: ");
                                int appo_id;
                                if (int.TryParse(Console.ReadLine(), out appo_id))
                                {
                                    Appointment appointmentToRemove = myDB.appointments.Find(appo_id);

                                    if (appointmentToRemove != null)
                                    {
                                        myDB.appointments.Remove(appointmentToRemove);
                                        myDB.SaveChanges();

                                        Console.WriteLine($"Appointment with ID {appo_id} has been removed.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Appointment with ID {appo_id} not found.");
                                    }
                                }
                                else { Console.WriteLine("Enter righte ID"); }
                                break;
                            case 3:
                                Console.Write("Enter Appointment ID to update: ");
                                if (int.TryParse(Console.ReadLine(), out int appointmentId))
                                {
                                    // Step 1: Retrieve the Appointment by ID
                                    Appointment appointmentToUpdate = myDB.appointments.Find(appointmentId);

                                    if (appointmentToUpdate != null)
                                    {
                                        // Step 2: Update the Date Property
                                        Console.Write("Enter new date for the appointment: ");
                                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                                        {
                                            appointmentToUpdate.Date = newDate;

                                            // Step 3: Save Changes to the Database
                                            myDB.SaveChanges();

                                            Console.WriteLine($"Appointment with ID {appointmentId} has been updated.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid date input.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Appointment with ID {appointmentId} not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for Appointment ID.");
                                }
                                break;
                            case 4:
                                Console.Write("Enter Appointment ID to update: ");
                                if (int.TryParse(Console.ReadLine(), out appointmentId))
                                {
                                    // Step 1: Retrieve the Appointment by ID
                                    var appointmentToDelete = myDB.appointments.Find(appointmentId);

                                    if (appointmentToDelete != null)
                                    {
                                        // Step 2: Delete the Appointment
                                        myDB.appointments.Remove(appointmentToDelete);
                                        myDB.SaveChanges();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Appointment with ID {appointmentId} not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for Appointment ID.");
                                }
                                break;
                            case 0:
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        bool interiorFlag = true;
                        int sp=0;
                        while (interiorFlag)
                        {
                            switch (choise(patientMenu, 0, 3))
                            {
                                // Registraition Patients.
                                case 1:
                                    try
                                    {
                                        Console.Write("Enter Patient Name: ");
                                        string patient_name = Console.ReadLine();
                                        Console.Write("Enter Patient Phone Number: ");
                                        int paitent_number = int.Parse(Console.ReadLine());
                                        Console.Write("Enter Patient Email: ");
                                        string patient_email = Console.ReadLine();
                                        Patient patient = new Patient
                                        {
                                            PatientName = patient_name,
                                            ContactEmail = patient_email,
                                            ContactNumber = paitent_number
                                        };
                                        myDB.patients.Add(patient);
                                        myDB.SaveChanges();
                                        Console.WriteLine("----------------------------------");
                                        Console.WriteLine("| Patients Added Successfully... |");
                                        Console.WriteLine("----------------------------------");
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Enter Correct Information");
                                    }      
                                    break;
                                //Specialization Selection
                                case 2:
                                    do
                                    {
                                        foreach(var spec in myDB.specializations)
                                        {
                                            Console.WriteLine($"=====> Specialization ID: {spec.SpecializationID} <=====");
                                            Console.WriteLine($"Specialization Name: {spec.SpecializationName}");
                                            Console.WriteLine($"Specialization Description: {spec.Description}");
                                            Console.WriteLine();
                                        }
                                        Console.Write("Select Specialization: ");
                                    } while (int.TryParse(Console.ReadLine(),out sp) && sp>0 && sp<myDB.specializations.Count());
                                    break;
                                //Appointment Booking
                                case 3:
                                    foreach(var pati in myDB.patients)
                                    {
                                        Console.WriteLine($"Patient Id: {pati.PatientID}, Patient Name: {pati.PatientName}");
                                    }
                                    Console.WriteLine();
                                    int PatiID;
                                    do
                                    {
                                        Console.WriteLine("Select Patient ID: ");
                                    } while (int.TryParse(Console.ReadLine(),out PatiID) && PatiID >0 && PatiID<myDB.patients.Count());

                                    DateTime apponiDT;
                                    do
                                    {
                                        Console.Write("Enter Appointment Date: ");
                                    } while (DateTime.TryParse(Console.ReadLine(),out apponiDT));

                                    TimeSpan apponiT;
                                    do
                                    {
                                        Console.Write("Enter Appointment Time: ");
                                    } while (TimeSpan.TryParse(Console.ReadLine(), out apponiT));
                                    Console.WriteLine("Enter The Status of Patient: ");
                                    string PatiStatus = Console.ReadLine();


                                    Appointment appointment = new Appointment
                                    {
                                        Date = apponiDT,
                                        Time = apponiT,
                                        PatientId = PatiID,
                                        SpecializationId = sp,
                                        status = PatiStatus
                                        
                                    };
                                    try
                                    {
                                        myDB.appointments.Add(appointment);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Enter Right Information...");
                                    }

                                    break;
                                case 0:
                                    break;
                                default : 
                                    break;
                            }
                        }
                        break;
                    // when user select user the program will terminate.
                    case 0:
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("| Thanks For Using System |");
                        Console.WriteLine("---------------------------");
                        flag = false;
                        break;
                    default: break;
                }
            }
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