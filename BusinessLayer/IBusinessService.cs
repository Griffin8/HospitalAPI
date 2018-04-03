using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.BusinessLayer.DTO;

namespace HospitalAPI.BusinessLayer
{
    /// <summary>
    /// Business Layer Contracts
    /// </summary>
    public interface IBusinessService
    {

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        List<PatientEntity> GetAllPatients();

        /// <summary>
        /// Get a patient based on a given Id
        /// </summary>
        /// <returns></returns>
        PatientEntity GetPatientById(int id);

        /// <summary> 
        /// Add a new patient
        /// </summary>
        /// <param name="newPatient">New patient</param>
        /// <returns>Inserted patient with Id assigned</returns>
        PatientEntity AddPatient(PatientEntity newPatient);

        /// <summary>
        /// Get doctor by ID
        /// </summary>
        /// <returns></returns>
        DoctorEntity GetDoctorById(int id);

        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <returns></returns>
        List<DoctorEntity> GetAllDoctors();

        /// <summary>
        /// Get all Consultations
        /// </summary>
        /// <returns></returns>
        List<ConsultationEntity> GetAllConsultations();

        /// <summary>
        /// Get a consultation for a given id
        /// </summary>
        /// <returns></returns>
        ConsultationEntity GetConsultationsById(int id);

        /// <summary>
        /// Get Consultations for a given consultation date
        /// </summary>
        /// <returns></returns>
        List<ConsultationEntity> GetConsultationsByConsultaionDate(DateTime consultaionDate);

        /// <summary>
        /// Register a patient and schedule a consultation
        /// </summary>
        /// <returns></returns>
        int RegisterPatient(PatientRegistrationInfoEntity patientRegistrationInfo);

        /// <summary>
        /// Get all treatment rooms
        /// </summary>
        /// <returns></returns>
        List<TreatmentRoomEntity> GetAllTreatmentRooms();
        
    }
}
