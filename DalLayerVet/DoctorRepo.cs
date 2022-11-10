using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public class DoctorRepo:IDoctorRepo
    {
        private VetDbContext db = new VetDbContext();

        public Doctor SaveDoctor(Doctor doctor)
        {
            try
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return doctor;
            }
            catch(Exception e)
            {
                throw new Exception("Exception thrown while saving doctor into the database");
            }
        }

        public async Task SaveDoctorAsync(Doctor doctor)
        {
            try
            {
                db.Doctors.Add(doctor);
                await db.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Exception thrown while saving doctor into the database");
            }
        }

    }
}
