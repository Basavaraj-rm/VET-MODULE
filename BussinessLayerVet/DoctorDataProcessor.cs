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
        public bool postFeedback(int doctorId,Feedback feedback)
        {
            bool done = repo.postFeedback(doctorId, feedback);
            return done;
        }
    }
}
