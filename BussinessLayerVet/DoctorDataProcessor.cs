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
        public bool editDoctor(Doctor d,int id)
        {
            return(repo.EditDoctor(d,id));
        }
        public async Task<bool> editDoctorAsync(Doctor d,int id)
        {
            return(await repo.EditDoctorasync(d,id));
        }
    }
}
