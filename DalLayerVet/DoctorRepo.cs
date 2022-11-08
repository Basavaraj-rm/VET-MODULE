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

        public void addDoctor(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();

        }

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
    }
}
