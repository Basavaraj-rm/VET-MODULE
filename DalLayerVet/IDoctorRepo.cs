using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public interface IDoctorRepo
    {
        List<Feedback> getFeedbacks(int doctorId);
        Doctor SaveDoctor(Doctor doctor);
        Task SaveDoctorAsync(Doctor doctor);
    }
}
