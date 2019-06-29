using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetADoctor.Models
{
    public class Appointment : SystemEntity
    {
        [Key]
        public int AppointmentId { get; set; }
        public String VisitingTime { get; set; }
        public String Date { get; set; }
        public int Serial { get; set; }
        public String Uid { get; set; }
        
        public String PrescriptionImagePath { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        public string Status { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
