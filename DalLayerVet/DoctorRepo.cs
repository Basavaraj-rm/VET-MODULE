using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public class DoctorRepo:IDoctorRepo
    {
        VetDbContext db = new VetDbContext();
        public List<Feedback> getFeedbacks(int doctorId)
        {
            var data = db.Doctors.Find(doctorId);
            if(data == null)
            {
                return null;
            }
            else
            {
                return data.feedbacks; 
            }
        }
        public bool AddAppointment(int doctorId, DoctorAppointment appointmentId)
        {
            if (db.Doctors.Find(doctorId) != null)
            {
                Doctor d = db.Doctors.Find(doctorId);
                d.appointmentIds.Add(appointmentId);
                db.SaveChanges();
                return true;
            }
            else
                return false;

        }
      public async Task<bool> _AddAppointment(int doctorId, DoctorAppointment appointmentId)
        {
            if (db.Doctors.Find(doctorId) != null)
            {
                Doctor d = db.Doctors.Find(doctorId);
                d.appointmentIds.Add(appointmentId);
                db.SaveChanges();
                return await Task.FromResult(true);
            }
            else
                return await Task.FromResult(false);
        }
    }
}
