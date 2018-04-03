using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.BusinessLayer.DTO;
using HospitalAPI.DataAccessLayer;
using HospitalAPI.DataAccessLayer.DTO;
using HospitalAPI.BusinessLayer;

namespace HospitalAPI.BusinessLayer
{
    public class BusinessService : IBusinessService
    {
        private readonly IDataAccessService _dataAccessService;

        /// <summary>
        /// Public constructor -- initial DataAccessService
        /// </summary>
        /// <param name="dataAccessService"></param>
        public BusinessService(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        #region Patient services
        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        public List<PatientEntity> GetAllPatients (){
            List<Patient> daPatients = _dataAccessService.GetAllPatients();

            if (daPatients == null)
            {
                return null;
            }

            if (daPatients.Count == 0)
            {
                return new List<PatientEntity>();
            }

            //convert List<Patient> to List<PatientEntity>
            return DTOMapper.Convert(daPatients);
        }

        /// <summary>
        /// Return a patient entity for a given ID
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns></returns>
        public PatientEntity GetPatientById(int id)
        {
            var daPatient = _dataAccessService.GetPatientById(id);

            if (daPatient == null)
                return null;

            //convert Patient to PatientEntity
            return DTOMapper.Convert(daPatient);
        }

        /// <summary>
        /// Insert a patient
        /// </summary>
        /// <param name="newPatient"></param>
        /// <returns></returns>
        public PatientEntity AddPatient(PatientEntity newPatient)
        {
            if(newPatient == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                var daPatient = _dataAccessService.AddPatient(DTOMapper.Convert(newPatient));

                if (daPatient == null)
                {
                    throw new Exception("Create patient failed");
                }

                return (DTOMapper.Convert(daPatient));
            }
            catch
            {
                //log the error
                throw;
            }
        }
        #endregion

        #region Doctor services
        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <returns></returns>
        public List<DoctorEntity> GetAllDoctors()
        {
            List<Doctor> daDoctors = _dataAccessService.DoctorRepository.GetAllItems();

            if (daDoctors == null)
            {
                return null;
            }

            if (daDoctors.Count == 0)
            {
                return new List<DoctorEntity>();
            }

            List<DoctorEntity> doctors = new List<DoctorEntity>();
            doctors = (from d in daDoctors
                       select new DoctorEntity
                       {
                           Id = d.Id,
                           FirstName = d.FirstName,
                           LastName = d.LastName,
                           Roles = (from r in _dataAccessService.DoctorRoleRepository.GetAllItems()
                                    from x in _dataAccessService.DoctorRoleXrefRepository.GetAllItems()
                                    where r.Id == x.DoctorRoleID && x.DoctorID == d.Id
                                    select new DoctorRoleEntity { Id = r.Id, DoctorRoleName = r.DoctorRoleName }
                                     ).ToList()
                       }).ToList();

            return doctors;
        }

        /// <summary>
        /// Get a doctor by given id
        /// </summary>
        /// <returns></returns>
        public DoctorEntity GetDoctorById(int doctorId)
        {
            Doctor daDoctor = _dataAccessService.DoctorRepository.GetItemById(doctorId);

            if (daDoctor == null)
            {
                return null;
            }

            DoctorEntity doctor = new DoctorEntity
            {
                Id = doctorId,
                FirstName = daDoctor.FirstName,
                LastName = daDoctor.LastName,
                Roles = (from r in _dataAccessService.DoctorRoleRepository.GetAllItems()
                         from x in _dataAccessService.DoctorRoleXrefRepository.GetAllItems()
                         where r.Id == x.DoctorRoleID && x.DoctorID == doctorId
                         select new DoctorRoleEntity { Id = r.Id, DoctorRoleName = r.DoctorRoleName }
                                    ).ToList()
            };
            return doctor;

        }
        #endregion

        #region Consultation services
        public List<ConsultationEntity> GetAllConsultations()
        {
            List<Consultation> daConsultations = _dataAccessService.GetAllConsultations();

            if (daConsultations == null)
            {
                return null;
            }

            if (daConsultations.Count == 0)
            {
                return new List<ConsultationEntity>();
            }

            return DTOMapper.Convert(daConsultations);
        }

        public List<ConsultationEntity> GetConsultationsByConsultaionDate(DateTime consultaionDate)
        {
            List<Consultation> daConsultations = _dataAccessService.GetAllConsultationsByConsultaionDate(consultaionDate);

            if (daConsultations == null)
            {
                return null;
            }

            if (daConsultations.Count == 0)
            {
                return new List<ConsultationEntity>();
            }

            return DTOMapper.Convert(daConsultations);
        }

        public ConsultationEntity GetConsultationsById(int id)
        {
            Consultation daConsultation = _dataAccessService.ConsultationRepository.GetItemById(id);

            if (daConsultation == null)
            {
                return null;
            }
            return DTOMapper.Convert(daConsultation);
        }
        #endregion

        #region TreatmentRoom services
        /// <summary>
        /// Get all TreatmentRooms with machine info
        /// </summary>
        /// <returns>List<TreatmentRoomEntity></returns>
        public List<TreatmentRoomEntity> GetAllTreatmentRooms()
        {
            List<TreatmentRoom> daRooms = _dataAccessService.TreatmentRoomRepository.GetAllItems();

            if (daRooms == null)
            {
                return null;
            }

            if (daRooms.Count == 0)
            {
                return new List<TreatmentRoomEntity>();
            }

            List<TreatmentRoomEntity> rooms = new List<TreatmentRoomEntity>();
            rooms = (from r in daRooms
                     select new TreatmentRoomEntity
                     {
                         Id = r.Id,
                         TreatmentRoomName = r.TreatmentRoomName,
                         TreatmentMachines = (
                             from m in _dataAccessService.TreatmentMachineRepository.GetAllItems()
                             from x in _dataAccessService.TreatmentMachineCapabilityRepository.GetAllItems()
                             from c in _dataAccessService.TreatmentMachineCapabilityTypeRepository.GetAllItems()
                             where r.Id == m.TreatmentRoomID
                                        && m.Id == x.TreatmentMachineID
                                        && x.TreatmentMachineCapabilityTypeID == c.Id
                             select new TreatmentMachineEntity
                             {
                                 Id = m.Id,
                                 TreatmentMachineName = m.TreatmentMachineName,
                                 TreatmentMachineCapabilityTypeName = c.TreatmentMachineCapabilityTypeName
                             }).ToList()
                     }).ToList();

            return rooms;
        }
        #endregion

        #region Patient Registration
        /// <summary>
        /// Schedule a consultation for a patient
        /// </summary>
        /// <param name="patientRegistrationInfo"></param>
        /// <returns>New consultation Id</returns>
        public int RegisterPatient(PatientRegistrationInfoEntity patientRegistrationInfo)
        {
            //This method is only for new patient
            //To do: need to handle transation

            /*Patient registration workflow
             *  check if the input is valid
             *  check if the consultation date is greater than today
             *  check if the patient has registed already
             *  check if the doctor is available that date
             *  check if the doctor has a role to treat the patient's condition
             *  check if the trementroom is availabel that date
             *  check if the machine (if there is) in the treatmentroom has the capability to treat the patient based on the patient's opography. 
             *      Note that flu condition is configured to a topography "Not Applicable". All conditions should have at least one topography
             *  insert the patient and set the registration date as today
             *  Insert a consulatation for the new patient
             */

            if (patientRegistrationInfo == null)
                throw new ArgumentNullException("patientRegistrationInfo");

            try
            {                
                //check if input is valid
                var doctor = _dataAccessService.DoctorRepository.GetItemById(patientRegistrationInfo.DoctorId);
                if (doctor == null)
                {
                    throw new Exception("Invalid doctor id");
                }

                var condition = _dataAccessService.ConditionTypeRepository.GetItemById(patientRegistrationInfo.ConditionTypeId);
                if (condition == null)
                {
                    throw new Exception("Invalid ConditionType id");
                }

                var topography = _dataAccessService.TopographyRepository.GetItemById(patientRegistrationInfo.TopographyId);
                if (topography == null)
                {
                    throw new Exception("Invalid Topography id");
                }

                var treatmentRoom = _dataAccessService.TreatmentRoomRepository.GetItemById(patientRegistrationInfo.TreatmentRoomId);
                if (treatmentRoom  == null)
                {
                    throw new Exception("Invalid TreatmentRoom id");
                }

                //check if teh consultation date is greater than today
                if ( (DateTime.Now.Date - patientRegistrationInfo.ConsultationDate.Date).Days >= 0)
                    throw new Exception("The consultation date should be a future date");

                //check if the patient has registed already (assume a patient's identity is the combination of first name and last name)
                if (DoesPatientExist(patientRegistrationInfo.FirstName, patientRegistrationInfo.LastName))
                {
                    throw new Exception("The patient has been registered.");
                }

                //check if the doctor is available that date
                if (IsDoctorAvailableByDate(patientRegistrationInfo.DoctorId, patientRegistrationInfo.ConsultationDate) == false)
                 {
                    throw new Exception(string.Format("The doctor has booked on {0}", patientRegistrationInfo.ConsultationDate.Date.ToString()));
                }

                //check if the doctor has a role to treat the patient's condition
                if(IsDoctorQualifedForConsultation(patientRegistrationInfo.DoctorId, patientRegistrationInfo.ConditionTypeId) == false)
                {
                    throw new Exception(string.Format("The doctor is not qulified to treat {0}", condition.ConditionTypeName));
                }

                //check if the trementroom is availabel that date
                if (IsTreatmentRoomAvailableByDate(patientRegistrationInfo.TreatmentRoomId, patientRegistrationInfo.ConsultationDate) == false)
                {
                    throw new Exception(string.Format("The treatment room has booked on {0}", patientRegistrationInfo.ConsultationDate.Date.ToString()));
                }

                //check if the machine(if there is) in the treatmentroom has the capability to treat the patient based on the patient's opography. 
                if (IsTreatmentRoomQualifedForConsultation(patientRegistrationInfo.TreatmentRoomId, patientRegistrationInfo.TopographyId) == false)
                {
                    throw new Exception("The treatment room is not qualified for consultation");
                }

                //insert new patient
                Patient newPatient = new Patient();
                newPatient.FirstName = patientRegistrationInfo.FirstName;
                newPatient.LastName = patientRegistrationInfo.LastName;
                newPatient.ConditionTypeID = condition.Id;
                newPatient.ConditionTypeName = condition.ConditionTypeName;
                newPatient.TopographyID = topography.Id;
                newPatient.TopographyName = topography.TopographyName;
                newPatient.RegistrationDatetime = DateTime.Now;

                var insertedPatient = _dataAccessService.AddPatient(newPatient);

                if(insertedPatient == null)
                {
                    throw new Exception("Insert patient failed");
                }

                Consultation newConsultation = new Consultation();
                newConsultation.PatiendID = insertedPatient.Id;
                newConsultation.DoctorID = patientRegistrationInfo.DoctorId;
                newConsultation.StartDateTime = patientRegistrationInfo.ConsultationDate.Date;
                newConsultation.EndDateTime = patientRegistrationInfo.ConsultationDate.Date;
                newConsultation.TreatmentRoomID = patientRegistrationInfo.TreatmentRoomId;
                newConsultation.Patient = insertedPatient;
                newConsultation.Doctor = doctor;
                newConsultation.TreatmentRoom = treatmentRoom;

                var insertedConsultation = _dataAccessService.AddConsultation(newConsultation);
                if(newConsultation == null)
                {
                    throw new Exception("Failed to schedule a consultation");
                }

                return newConsultation.Id;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region private methods


        private bool DoesPatientExist(string firstName, string lastName)
        {
            var patient = (from p in _dataAccessService.PatientRepository.GetAllItems()
                         where p.FirstName == firstName && p.LastName == lastName
                          select 1).ToList();

            return (patient.Count > 0);
        }

        private bool IsDoctorQualifedForConsultation(int doctorId, int conditionTypeId)
        {
            var doctor = (from role in _dataAccessService.DoctorRoleXrefRepository.GetAllItems()
                         from con in _dataAccessService.DoctorRoleConditionTypeXrefRepository.GetAllItems()
                         where role.DoctorRoleID == con.DoctorRoleID
                            && role.DoctorID == doctorId
                            && con.ConditionTypeID == conditionTypeId
                            select 1).ToList();

            return (doctor.Count > 0);
        }

        private bool IsDoctorAvailableByDate(int doctorId, DateTime consultationDate)
        {
            //check if the doctor is booked for that date
            var doctor = (from d in _dataAccessService.ConsultationRepository.GetAllItems()
                         where d.DoctorID == doctorId && d.StartDateTime.Date == consultationDate.Date
                         select 1).ToList();

            return (doctor.Count == 0);
        }

        private bool IsTreatmentRoomAvailableByDate(int treatmentroomId, DateTime consultationDate)
        {
            //check if the room is booked for that date
            var room = (from r in _dataAccessService.ConsultationRepository.GetAllItems()
                         where r.TreatmentRoomID == treatmentroomId && r.StartDateTime.Date == consultationDate.Date
                         select 1).ToList();

            return (room.Count == 0);
        }

        private bool IsTreatmentRoomQualifedForConsultation(int roomId, int topographyId)
        {
            //return a list of machines which are qualified for topographyId. 
            var qualifiedRoomWithMachines = (from xref in _dataAccessService.TreatmentMachineCapabilityTopographyXrefRepository.GetAllItems()
                                    from ty in _dataAccessService.TreatmentMachineCapabilityTypeRepository.GetAllItems()
                                    from ca in _dataAccessService.TreatmentMachineCapabilityRepository.GetAllItems()
                                    from m in _dataAccessService.TreatmentMachineRepository.GetAllItems()
                          where xref.TreatmentMachineCapabilityTypeID == ty.Id
                                && ca.TreatmentMachineCapabilityTypeID == ty.Id
                                && ca.TreatmentMachineID == m.Id
                                && xref.TopographyID == topographyId
                          select m.TreatmentRoomID).Distinct().ToList();

            //If no rooms are found, assuming that the consultation doesn't need a room with a machine. So any room is fine
            if (qualifiedRoomWithMachines.Count == 0) 
                return true;

            //next to check if the given room is in the list of qualifiedRoomWithMachines
            return (qualifiedRoomWithMachines.Contains(roomId));
        }

        #endregion
    }
}
