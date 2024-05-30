using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentMaker.Models
{
    public class AppointmentModel
    {
        [DisplayName("Patient's full name")]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string PatientName { get; set; }

        [DisplayName("Appointment Request Date")]
        //[DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DisplayName("Net worth of patient")]
        [DataType(DataType.Currency)]
        public decimal PatientNetWorth { get; set; }

        [DisplayName("Primary Doctor's Last Name")]
        public string DoctorName { get; set; }

        [DisplayName("Patient's Perceived Level of Pain (1-10)")]
        [Range(1,10)]
        public int PainLevel { get; set; }
    }
}
