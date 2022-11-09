using DalLayerVet;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public class DoctorDataProcessor
    {
        DoctorRepo repo = new DoctorRepo();
        public List<Feedback> getFeedbacks(int doctorId)
        {
            List<Feedback> feedbacks= repo.getFeedbacks(doctorId);
            return feedbacks;
        }

        public List<Doctor> GetDoctors()
        {
            return repo.GetDoctors();
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            try
            {
                return await repo.GetDoctorsAsync();

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
