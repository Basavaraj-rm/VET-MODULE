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

        public bool EditDoctor(Doctor doctor,int id)
        {
            var data = db.Doctors.Find(id);
            if (data == null)
                return false;
            else
            {
                data.name = doctor.name;
                data.mobileNo = doctor.mobileNo;
                data.email = doctor.email;
                data.clinicAddress = doctor.clinicAddress;
                data.imgUrl = doctor.imgUrl;
                data.speciality = doctor.speciality;
                data.npiNo = doctor.npiNo;
                db.SaveChanges();
                return true;
            }
        }

        public async Task<bool> EditDoctorasync(Doctor doctor,int id)
        {
            var data = await db.Doctors.FindAsync(id);
            if(data== null) return false;
            else
            {
                data.name = doctor.name;
                data.mobileNo = doctor.mobileNo;
                data.email = doctor.email;
                data.clinicAddress=doctor.clinicAddress;
                data.imgUrl = doctor.imgUrl;
                data.speciality = doctor.speciality;
                data.npiNo = doctor.npiNo;
                await db.SaveChangesAsync();
                return true;
            }
            
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
