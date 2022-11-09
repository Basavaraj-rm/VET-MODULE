using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public class DoctorRepo:IDoctorRepo
    {
        private VetDbContext db = new VetDbContext();
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

        public Doctor SaveDoctor(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();

            return doctor;
        }

        public async Task SaveDoctorAsync(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            await db.SaveChangesAsync();
        }

    }
}
