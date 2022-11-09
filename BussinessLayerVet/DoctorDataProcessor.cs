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
        public async Task<List<Feedback>> getFeedbacksAsync(int doctorId)
        {
            List<Feedback> feedbacks = await repo.getFeedbacksAsync(doctorId);
            return feedbacks;
        }
        public bool postFeedback(int doctorId,Feedback feedback)
        {
            bool done = repo.postFeedback(doctorId, feedback);
            return done;
        }
        public async Task<bool> postFeedbackAsync(int doctorId, Feedback feedback)
        {
            bool done = await repo.postFeedbackAsync(doctorId, feedback);
            return done;
        }
    }
}
