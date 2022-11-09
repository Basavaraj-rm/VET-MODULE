using DalLayerVet;
using DTOs;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public class DoctorDataProcessor : IDoctorDataProcessor
    {
        IDoctorRepo repo = new DoctorRepo();
        public List<Feedback> getFeedbacks(int doctorId)
        {
            List<Feedback> feedbacks= repo.getFeedbacks(doctorId);
            return feedbacks;
        }

        public Doctor AddDoctor(DoctorDto dto)
        {
            Doctor doctor = AutoMapper.MapperConfig(dto);
            doctor.feedbacks = new List<Feedback>();
            doctor.appointmentIds = new List<DoctorAppointment>();

            /*Doctor doctor = new Doctor();
            doctor.imgUrl = dto.imgUrl;
            doctor.name = dto.name;
            doctor.npiNo = dto.npiNo;
            doctor.mobileNo = dto.mobileNo;
            doctor.email = dto.email;
            doctor.speciality = dto.speciality;
            doctor.clinicAddress = dto.clinicAddress;
            doctor.appointmentIds = new List<DoctorAppointment>();
            doctor.feedbacks = new List<Feedback>();*/

            Doctor savedDoctor = repo.SaveDoctor(doctor);
            return savedDoctor;
        }

        public async Task<Doctor> AddDoctorAsync(DoctorDto dto)
        {
            /*Doctor doctor = new Doctor();
            doctor.imgUrl = dto.imgUrl;
            doctor.name = dto.name;
            doctor.npiNo = dto.npiNo;
            doctor.mobileNo = dto.mobileNo;
            doctor.email = dto.email;
            doctor.speciality = dto.speciality;
            doctor.clinicAddress = dto.clinicAddress;
            doctor.appointmentIds = new List<DoctorAppointment>();
            doctor.feedbacks = new List<Feedback>();*/
            Doctor doctor = AutoMapper.MapperConfig(dto);
            doctor.feedbacks = new List<Feedback>();
            doctor.appointmentIds = new List<DoctorAppointment>();

            await repo.SaveDoctorAsync(doctor);
            return doctor;
        }

    }
}
