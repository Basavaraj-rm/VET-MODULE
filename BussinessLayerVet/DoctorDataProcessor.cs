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
                if (dto.name == null ||  dto.npiNo == 0 || dto.mobileNo == null || dto.speciality == null || dto.clinicAddress == null) 
                    throw new DoctorDetailsInCompleteException("Doctor details Incomplete. Name, NpiNo, MobileNo, Speciality and ClinicAddress are mandatory fields for the doctor");

                Doctor doctor = AutoMapper.MapperConfig(dto);
                doctor.feedbacks = new List<Feedback>();
                doctor.appointmentIds = new List<DoctorAppointment>();

                Doctor savedDoctor = repo.SaveDoctor(doctor);
                return savedDoctor;
            }
            catch(DoctorDetailsInCompleteException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<Doctor> AddDoctorAsync(DoctorDto dto)
        {
            try
            {
                if (dto.name == null || dto.npiNo == 0 || dto.mobileNo == null || dto.speciality == null || dto.clinicAddress == null)
                    throw new DoctorDetailsInCompleteException("Doctor details Incomplete. Name, NpiNo, MobileNo, Speciality and ClinicAddress are mandatory fields for the doctor");

                Doctor doctor = AutoMapper.MapperConfig(dto);
                doctor.feedbacks = new List<Feedback>();
                doctor.appointmentIds = new List<DoctorAppointment>();

                await repo.SaveDoctorAsync(doctor);
                return doctor;
            }
            catch (DoctorDetailsInCompleteException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
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