using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.DataAccessLayer.DTO;
using HospitalAPI.DataAccessLayer;
using HospitalAPI.BusinessLayer.DTO;

namespace HospitalAPI.BusinessLayer
{
    /// <summary>
    /// DTO type conversion between DataAccessLayer and BusinessLayer
    /// </summary>
    public static class DTOMapper
    {
        #region convert Patient/PatientEntity
        public static PatientEntity Convert(Patient patient)
        {
            if (patient == null)
                return null;

            return new PatientEntity
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                ConditionTypeId = patient.ConditionTypeID,
                ConditionTypeName = patient.ConditionTypeName,
                TopographyId = patient.TopographyID,
                TopographyName = patient.TopographyName,
                RegistrationDatetime = patient.RegistrationDatetime
            };
        }

        public static Patient Convert(PatientEntity patient)
        {
            if (patient == null)
                return null;

            return new Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                ConditionTypeID = patient.ConditionTypeId,
                ConditionTypeName = patient.ConditionTypeName,
                TopographyID = patient.TopographyId,
                TopographyName = patient.TopographyName,
                RegistrationDatetime = patient.RegistrationDatetime
            };
        }

        public static List<Patient> Convert(List<PatientEntity> patients)
        {
            if (patients == null)
                return null;

            if (patients.Count == 0)
                return new List<Patient>();

            List<Patient> results = new List<Patient>();

            foreach (var item in patients)
            {
                results.Add(Convert(item));
                //results.Add(new Patient
                //{
                //    Id = item.Id,
                //    FirstName = item.FirstName,
                //    LastName = item.LastName,
                //    RegistrationDatetime = item.RegistrationDatetime,
                //});
            }
            return results;
        }

        public static List<PatientEntity> Convert(List<Patient> patients)
        {
            if (patients == null)
                return null;

            if (patients.Count == 0)
                return new List<PatientEntity>();

            List<PatientEntity> results = new List<PatientEntity>();

            foreach (var item in patients)
            {
                results.Add(Convert(item));

                //results.Add(new PatientEntity
                //{
                //    Id = item.Id,
                //    FirstName = item.FirstName,
                //    LastName = item.LastName,
                //    RegistrationDatetime = item.RegistrationDatetime,
                //});
            }
            return results;
        }

        #endregion

        #region convert Consultation/ConsultationEntity
        public static ConsultationEntity Convert(Consultation consultation)
        {
            if (consultation == null)
                return null;

            return new ConsultationEntity
            {
                Id = consultation.Id,
                PatientId = consultation.PatiendID,
                PatientFirstName = consultation.Patient == null ? "" : consultation.Patient.FirstName,
                PatientLastName = consultation.Patient == null ? "" : consultation.Patient.LastName,
                DoctorId = consultation.DoctorID,
                DoctorFirstName = consultation.Doctor == null ? "" : consultation.Doctor.FirstName,
                DoctorLasstName = consultation.Doctor == null ? "" : consultation.Doctor.LastName,
                ConditionTypeId = consultation.Patient == null ? 0 : consultation.Patient.ConditionTypeID,
                ConditionTypeName = consultation.Patient == null ? "" : consultation.Patient.ConditionTypeName,
                TopographyId = consultation.Patient == null ? 0 : consultation.Patient.TopographyID,
                TopographyName = consultation.Patient == null ? "" : consultation.Patient.TopographyName,
                TreatmentRoomId = consultation.TreatmentRoomID,
                TreatmentRoomName = consultation.TreatmentRoom == null ? "" : consultation.TreatmentRoom.TreatmentRoomName
            };
        }

        public static List<ConsultationEntity> Convert(List<Consultation> consultations)
        {
            if (consultations == null)
                return null;

            if (consultations.Count == 0)
                return new List<ConsultationEntity>();

            List<ConsultationEntity> results = new List<ConsultationEntity>();

            foreach (var item in consultations)
            {
                results.Add(Convert(item));
            }
            return results;
        }
        #endregion
    }
}