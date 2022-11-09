using DTOs;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public interface IDoctorDataProcessor
    {
        List<Feedback> getFeedbacks(int doctorId);
        Doctor AddDoctor(DoctorDto dto);
        Task<Doctor> AddDoctorAsync(DoctorDto dto);
    }
}
