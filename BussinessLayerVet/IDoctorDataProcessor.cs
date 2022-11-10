using DTOs;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public interface IDoctorDataProcessor
    {
        Doctor AddDoctor(DoctorDto dto);
        Task<Doctor> AddDoctorAsync(DoctorDto dto);
    }
}
