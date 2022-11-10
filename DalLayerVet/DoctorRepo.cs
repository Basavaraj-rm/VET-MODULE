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
                throw new DatabaseSaveException("Couldn't able to save doctor object into the database as doctor details are incomplete");
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
                throw new DatabaseSaveException("Couldn't able to save doctor object into the database as doctor details are incomplete");
            }
        }

    }
}
