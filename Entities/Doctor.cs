﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Doctor
    {
        [Key]
        public int doctorId { get; set; }
        public string imgUrl { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public long npiNo { get; set; }
        [Required]
        public string mobileNo { get; set; }
        public string email { get; set; }
        [Required]
        public string speciality { get; set; }
        [Required]
        public string clinicAddress { get; set; }
        public virtual List<Feedback> feedbacks { get; set; }
        public virtual List<DoctorAppointment> appointmentIds { get; set; }
    }
}
