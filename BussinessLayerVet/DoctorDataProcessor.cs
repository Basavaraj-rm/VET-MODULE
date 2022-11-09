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
             if (dto.name == null)
                 throw new DoctorDetailsNotCompleteException("Please enter the doctor name");
             else if (dto.npiNo == 0)
                 throw new DoctorDetailsNotCompleteException("NPI Number mandatory");
             else if (dto.mobileNo == null)
                 throw new DoctorDetailsNotCompleteException("Mobile number not found");
             else if (dto.speciality == null)
                 throw new DoctorDetailsNotCompleteException("Doctor's speciality not found");
             else if (dto.clinicAddress == null)
                 throw new DoctorDetailsNotCompleteException("Clinic Address not found");
            
            

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
            try
            {
                if (dto.name == null)
                    throw new DoctorDetailsNotCompleteException("Please enter the doctor name");
                else if (dto.npiNo == 0)
                    throw new DoctorDetailsNotCompleteException("NPI Number mandatory");
                else if (dto.mobileNo == null)
                    throw new DoctorDetailsNotCompleteException("Mobile number not found");
                else if (dto.speciality == null)
                    throw new DoctorDetailsNotCompleteException("Doctor's speciality not found");
                else if (dto.clinicAddress == null)
                    throw new DoctorDetailsNotCompleteException("Clinic Address not found");
            }
            catch(DoctorDetailsNotCompleteException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
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
