using DalLayerVet;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public class DoctorDataProcessor : IDoctorDataProcessor
    {
        IDoctorRepo repo = null;

        public DoctorDataProcessor(IDoctorRepo repo)
        {
            this.repo = repo;
        }


        public Doctor AddDoctor(DoctorDto dto)
        {
            try
            {
                Doctor doctor = AutoMapper.MapperConfig(dto);
                doctor.feedbacks = new List<Feedback>();
                doctor.appointmentIds = new List<DoctorAppointment>();

                Doctor savedDoctor = repo.SaveDoctor(doctor);
                return savedDoctor;
            }
            catch (DatabaseSaveException e)
            {
                throw new DatabaseSaveException(e.Message);
            }

        }

        public async Task<Doctor> AddDoctorAsync(DoctorDto dto)
        {
            try
            {
                Doctor doctor = AutoMapper.MapperConfig(dto);
                doctor.feedbacks = new List<Feedback>();
                doctor.appointmentIds = new List<DoctorAppointment>();

                await repo.SaveDoctorAsync(doctor);
                return doctor;
            }
            catch (DatabaseSaveException e)
            {
                throw new DatabaseSaveException(e.Message);
            }
        }

    }
}























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