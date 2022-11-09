using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Doctor> GetDoctors()
        {
            return db.Doctors.ToList();
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            var list= await db.Doctors.ToListAsync();
            return list;
        }
    }
}
