using DalLayerVet;
using DTOs;
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
            try
            {
                List<Feedback> feedbacks = repo.getFeedbacks(doctorId);
                return feedbacks;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public async Task<List<Feedback>> getFeedbacksAsync(int doctorId)
        {
            try
            {
                List<Feedback> feedbacks = await repo.getFeedbacksAsync(doctorId);
                return feedbacks;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
        public bool postFeedback(int doctorId,Feedback feedback)
        {
            try
            {
                bool done = repo.postFeedback(doctorId, feedback);
                return done;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
        public async Task<bool> postFeedbackAsync(int doctorId, Feedback feedback)
        {
            try
            {
                bool done = await repo.postFeedbackAsync(doctorId, feedback);
                return done;
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
        public bool AddAppointment(int doctorId, DoctorAppointment appointmentId)
        {
            bool response = repo.AddAppointment(doctorId, appointmentId);
            return response;
        }
        public async Task<bool> AddAppointmentAsync(int doctorId, DoctorAppointment appointmentId)
        {
            var response = await repo.AddAppointmentAsync(doctorId, appointmentId);
            return response;
        }
        public List<Doctor> GetDoctors()
        {
            return repo.GetDoctors();
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {

            return await repo.GetDoctorsAsync();
        }
        public bool editDoctor(Doctor d, int id)
        {
            return (repo.EditDoctor(d, id));
        }
        public async Task<bool> editDoctorAsync(Doctor d, int id)
        {
            return (await repo.EditDoctorasync(d, id));
        }
        public Doctor AddDoctor(DoctorDto dto)
        {
            Doctor doctor = new Doctor();
            doctor.imgUrl = dto.imgUrl;
            doctor.name = dto.name;
            doctor.npiNo = dto.npiNo;
            doctor.mobileNo = dto.mobileNo;
            doctor.email = dto.email;
            doctor.speciality = dto.speciality;
            doctor.clinicAddress = dto.clinicAddress;
            doctor.appointmentIds = new List<DoctorAppointment>();
            doctor.feedbacks = new List<Feedback>();

            Doctor savedDoctor = repo.SaveDoctor(doctor);
            return savedDoctor;
        }

        public async Task<Doctor> AddDoctorAsync(DoctorDto dto)
        {
            Doctor doctor = new Doctor();
            doctor.imgUrl = dto.imgUrl;
            doctor.name = dto.name;
            doctor.npiNo = dto.npiNo;
            doctor.mobileNo = dto.mobileNo;
            doctor.email = dto.email;
            doctor.speciality = dto.speciality;
            doctor.clinicAddress = dto.clinicAddress;
            doctor.appointmentIds = new List<DoctorAppointment>();
            doctor.feedbacks = new List<Feedback>();

            await repo.SaveDoctorAsync(doctor);
            return doctor;
        }
    }
}
