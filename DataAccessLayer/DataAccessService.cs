using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAPI.DataAccessLayer.DTO;

namespace HospitalAPI.DataAccessLayer
{
    public class DataAccessService : IDataAccessService
    {
        #region Private member variables
        private static Entities _hospitalEntities;
        private Repository<Patient> _patientRepository;
        private Repository<PatientCondition> _patientConditionRepository;
        private Repository<Doctor> _doctorRepository;
        private Repository<Consultation> _consultationRepository;
        private Repository<ConditionType> _conditionTypeRepository;
        private Repository<Topography> _topographyRepository;
        private Repository<TreatmentRoom> _treatmentRoomRepository;
        private Repository<TreatmentMachine> _treatmentMachineRepository;
        private Repository<DoctorRole> _doctorRoleRepository;
        private Repository<DoctorRoleXref> _doctorRoleXrefRepository;
        private Repository<DoctorRoleConditionTypeXref> _doctorRoleConditionTypeXrefRepository;
        private Repository<TreatmentMachineCapability> _treatmentMachineCapabilityRepository;
        private Repository<TreatmentMachineCapabilityTopographyXref> _treatmentMachineCapabilityTopographyXrefRepository;
        private Repository<TreatmentMachineCapabilityType> _treatmentMachineCapabilityTypeRepository;

        #endregion

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="hospitalEntities"></param>
        public DataAccessService(Entities hospitalEntities)
        {
            _hospitalEntities = hospitalEntities;

            //initialize the data if data doesn't exist
            if (_hospitalEntities.Patients == null)
            {
                SeedData();
                InitiRepositories();
            }
        }

        #region initialize repositories
        /// <summary>
        /// Initialize repositories
        /// </summary>
        private void InitiRepositories()
        {
            _patientRepository = _hospitalEntities.Patients;
            _patientConditionRepository = _hospitalEntities.PatientConditions;            
            _doctorRepository = _hospitalEntities.Doctors;
            _consultationRepository = _hospitalEntities.consultations;
            _conditionTypeRepository = _hospitalEntities.ConditionTypes;
            _topographyRepository = _hospitalEntities.Topographies;
            _treatmentRoomRepository = _hospitalEntities.TreatmentRooms;
            _treatmentMachineRepository = _hospitalEntities.TreatmentMachines;
            _doctorRoleRepository = _hospitalEntities.DoctorRoles;
            _doctorRoleXrefRepository = _hospitalEntities.DoctorRoleXref;
            _doctorRoleConditionTypeXrefRepository = _hospitalEntities.DoctorRoleConditionTypeXref;
            _treatmentMachineCapabilityRepository = _hospitalEntities.TreatmentMachineCapabilities;
            _treatmentMachineCapabilityTopographyXrefRepository = _hospitalEntities.TreatmentMachineCapabilityTopographyXref;
            _treatmentMachineCapabilityTypeRepository = _hospitalEntities.TreatmentMachineCapabilityTypes;
        }

        public Repository<Patient> PatientRepository { get { return _patientRepository; } }
        public Repository<Doctor> DoctorRepository { get { return _doctorRepository; } }
        public Repository<Consultation> ConsultationRepository { get { return _consultationRepository; } }
        public Repository<ConditionType> ConditionTypeRepository { get { return _conditionTypeRepository; } }
        public Repository<Topography> TopographyRepository { get { return _topographyRepository; } }
        public Repository<TreatmentRoom> TreatmentRoomRepository { get { return _treatmentRoomRepository; } }
        public Repository<TreatmentMachine> TreatmentMachineRepository { get { return _treatmentMachineRepository; } }
        public Repository<DoctorRole> DoctorRoleRepository { get { return _doctorRoleRepository; } }
        public Repository<DoctorRoleXref> DoctorRoleXrefRepository { get { return _doctorRoleXrefRepository; } }
        public Repository<DoctorRoleConditionTypeXref> DoctorRoleConditionTypeXrefRepository { get { return _doctorRoleConditionTypeXrefRepository; } }
        public Repository<TreatmentMachineCapability> TreatmentMachineCapabilityRepository { get { return _treatmentMachineCapabilityRepository; } }
        public Repository<TreatmentMachineCapabilityTopographyXref> TreatmentMachineCapabilityTopographyXrefRepository { get { return _treatmentMachineCapabilityTopographyXrefRepository; } }
        public Repository<TreatmentMachineCapabilityType> TreatmentMachineCapabilityTypeRepository { get { return _treatmentMachineCapabilityTypeRepository; } }

        #endregion

        #region Public methods for the Patient repository
        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAllItems();
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.GetItemById(id);
        }

        public Patient AddPatient(Patient newPatient)
        {
            if (newPatient == null)
                throw new ArgumentNullException("newPatient");

            var newId = _patientRepository.AddItem(newPatient);
            return _patientRepository.GetItemById(newId);
        }

        //public Patient AddPatient(string FirstName, string LastName, int conditionTypeId, int topographyId)
        //{
        //    if (FirstName == string.Empty && LastName == string.Empty)
        //        throw new Exception("Patient should have a last or first name");

        //    Patient newPatient = new Patient();
        //    newPatient.FirstName = FirstName;
        //    newPatient.LastName = LastName;
        //    newPatient.RegistrationDatetime = DateTime.Now;

        //    // add new patient and return its ID
        //    var newPatientId = _patientRepository.AddItem(newPatient);

        //    //add patient condition relationship for new patient
        //    PatientCondition patientCondition = new PatientCondition();
        //    patientCondition.PatientID = newPatientId;
        //    var conditionType = _conditionTypeRepository.GetItemById(conditionTypeId);
        //    patientCondition.ConditionTypeID = conditionTypeId;
        //    patientCondition.ConditionType = _conditionTypeRepository.GetItemById(conditionTypeId);
        //    patientCondition.TopographyID = topographyId;
        //    patientCondition.Topography = _topographyRepository.GetItemById(topographyId);

        //    var newPatientConditionId = _patientConditionRepository.AddItem(patientCondition);

        //    newPatient.PatientConditions = _patientConditionRepository.GetItemById(newPatientConditionId);

        //    //update patientCondition in _patientRepository
        //    _patientRepository.UpdateItem(newPatientId, )
        //    var newId = _patientRepository.AddItem(newPatient);
        //    return _patientRepository.GetItemById(newId);
        //}

        #endregion

        #region Public methods for the Consultation repository
        public List<Consultation> GetAllConsultations()
        {
            return _consultationRepository.GetAllItems();
        }

        public List<Consultation> GetAllConsultationsByConsultaionDate(DateTime consultaionDate)
        {
            var consultations = _consultationRepository.GetAllItems().Where(x => DateTime.Compare(x.StartDateTime.Date, consultaionDate.Date) == 0).ToList();

            if (consultations == null)
            {
                return null;
            }

            return consultations;
        }

        public Consultation AddConsultation(Consultation newConsultation)
        {
            if (newConsultation == null)
                throw new ArgumentNullException("newConsultation");

            var newId = _consultationRepository.AddItem(newConsultation);
            return _consultationRepository.GetItemById(newId);

        }



        #endregion

        #region Seed data for the data entities
        private void SeedData()
        {
            //Seed doctor roles
            var doctorRoles = new List<DoctorRole> {
                new DoctorRole { Id = 1, DoctorRoleName = "GeneralPractitioner"},
                new DoctorRole { Id = 2, DoctorRoleName = "Oncologist"}
             };

            //Seed doctors
            var doctors = new List<Doctor> {
                new Doctor { Id = 1, FirstName = "John"},
                new Doctor { Id = 2, FirstName = "Anna"},
                new Doctor { Id = 3, FirstName = "Laura"}
             };

            //Seed doctorRoleXref
            var doctorRoleXref = new List<DoctorRoleXref> {
                new DoctorRoleXref { Id = 1, DoctorID = 1, Doctor = doctors[0], DoctorRoleID = 2, DoctorRole = doctorRoles[1]},
                new DoctorRoleXref { Id = 2, DoctorID = 2, Doctor = doctors[1], DoctorRoleID = 1, DoctorRole = doctorRoles[0]},
                new DoctorRoleXref { Id = 3, DoctorID = 3, Doctor = doctors[2], DoctorRoleID = 1, DoctorRole = doctorRoles[0]},
                new DoctorRoleXref { Id = 4, DoctorID = 3, Doctor = doctors[2], DoctorRoleID = 2, DoctorRole = doctorRoles[1]}
             };

            //Add DoctorRoleXrefs to the doctors
            doctors[0].DoctorRoleXrefs.Add(doctorRoleXref[0]);
            doctors[1].DoctorRoleXrefs.Add(doctorRoleXref[1]);
            doctors[2].DoctorRoleXrefs.Add(doctorRoleXref[2]);
            doctors[2].DoctorRoleXrefs.Add(doctorRoleXref[3]);

            //seed condition type data
            var conditionTypes = new List<ConditionType> {
                new ConditionType { Id = 1, ConditionTypeName = "Flu"},
                new ConditionType { Id = 2, ConditionTypeName = "Cancer"}
             };

            //See DoctorRoleConditionTypeXref
            var doctorRoleConditionTypeXref = new List<DoctorRoleConditionTypeXref>
            {
                //GeneralPractitioner/Flu
                new DoctorRoleConditionTypeXref
                {
                    Id = 1,
                    DoctorRoleID =1,
                    ConditionTypeID = 1,
                    DoctorRole = doctorRoles[0],
                    ConditionType = conditionTypes[0]
                },
                //Oncologists/Cancer
                new DoctorRoleConditionTypeXref
                {
                    Id = 1,
                    DoctorRoleID =2,
                    ConditionTypeID = 2,
                    DoctorRole = doctorRoles[1],
                    ConditionType = conditionTypes[1]
                }
            };

            //seed treatmentMachine Capability type data
            var treatmentMachineCapabilityTypes = new List<TreatmentMachineCapabilityType> {
                new TreatmentMachineCapabilityType { Id = 1, TreatmentMachineCapabilityTypeName = "Simple" },
                new TreatmentMachineCapabilityType { Id = 2, TreatmentMachineCapabilityTypeName = "Advanced" }
            };

            //seed topography data
            var topographies = new List<Topography> {
                new Topography { Id = 1, TopographyName = "Not Applicable" },
                new Topography { Id = 2, TopographyName = "Head & Neck" },
                new Topography { Id = 3, TopographyName = "Breast" }
            };

            //seed treatment rooms
            var treatmentRooms = new List<TreatmentRoom> {
                new TreatmentRoom { Id = 1, TreatmentRoomName = "RoomOne" },
                new TreatmentRoom { Id = 2, TreatmentRoomName = "RoomTwo" },
                new TreatmentRoom { Id = 3, TreatmentRoomName = "RoomThree" },
                new TreatmentRoom { Id = 4, TreatmentRoomName = "RoomFour" },
                new TreatmentRoom { Id = 5, TreatmentRoomName = "RoomFive" }
                };

            //seed treatmentMachine data
            var treatmentMachines = new List<TreatmentMachine> {
                new TreatmentMachine { Id = 1, TreatmentMachineName = "MachineA", TreatmentRoomID = 3},
                new TreatmentMachine { Id = 2, TreatmentMachineName = "MachineB", TreatmentRoomID = 4},
                new TreatmentMachine { Id = 3, TreatmentMachineName = "MachineC", TreatmentRoomID = 5}
            };

            //seed TreatmentMachine Capabilities
            var treatmentMachineCapabilities = new List<TreatmentMachineCapability>
            {
                new TreatmentMachineCapability {Id = 1, TreatmentMachineID = 1, TreatmentMachineCapabilityTypeID = 2},
                new TreatmentMachineCapability {Id = 2, TreatmentMachineID = 2, TreatmentMachineCapabilityTypeID = 2},
                new TreatmentMachineCapability {Id = 3, TreatmentMachineID = 3, TreatmentMachineCapabilityTypeID = 1}
            };

            // add treatmentMachineCapabilities to treatmentMachine
            treatmentMachines[0].TreatmentMachineCapabilities.Add(treatmentMachineCapabilities[0]);
            treatmentMachines[1].TreatmentMachineCapabilities.Add(treatmentMachineCapabilities[1]);
            treatmentMachines[2].TreatmentMachineCapabilities.Add(treatmentMachineCapabilities[2]);

            //treatmentMachineCapabilityTopographyXref
            var treatmentMachineCapabilityTopographyXref = new List<TreatmentMachineCapabilityTopographyXref>
            {
                //head & neck cancer/ Advanced machine
                new TreatmentMachineCapabilityTopographyXref {Id=1, TopographyID=2, Topography=topographies[1], TreatmentMachineCapabilityTypeID = 2, TreatmentMachineCapabilityType = treatmentMachineCapabilityTypes[1] },
                //breast cancer / Advanced machine
                new TreatmentMachineCapabilityTopographyXref {Id=2, TopographyID=3, Topography=topographies[2], TreatmentMachineCapabilityTypeID = 2, TreatmentMachineCapabilityType = treatmentMachineCapabilityTypes[1] },
                //breast cancer / Simple machine
                new TreatmentMachineCapabilityTopographyXref {Id=3, TopographyID=3, Topography=topographies[2], TreatmentMachineCapabilityTypeID = 1, TreatmentMachineCapabilityType = treatmentMachineCapabilityTypes[0] }
            };

            //Seed a patient data            
            var patients = new List<Patient>();

            //Consultation
            var consultations = new List<Consultation>();

            //bind to Hospital Entities
            _hospitalEntities.Patients = new Repository<Patient>(patients);
            _hospitalEntities.ConditionTypes = new Repository<ConditionType>(conditionTypes);
            _hospitalEntities.Doctors = new Repository<Doctor>(doctors);
            _hospitalEntities.DoctorRoles = new Repository<DoctorRole>(doctorRoles);
            _hospitalEntities.DoctorRoleConditionTypeXref = new Repository<DoctorRoleConditionTypeXref>(doctorRoleConditionTypeXref);
            _hospitalEntities.DoctorRoleXref = new Repository<DoctorRoleXref>(doctorRoleXref);
            _hospitalEntities.consultations = new Repository<Consultation>(consultations);
            _hospitalEntities.Topographies = new Repository<Topography>(topographies);
            _hospitalEntities.TreatmentMachines = new Repository<TreatmentMachine>(treatmentMachines);
            _hospitalEntities.TreatmentMachineCapabilityTypes = new Repository<TreatmentMachineCapabilityType>(treatmentMachineCapabilityTypes);
            _hospitalEntities.TreatmentMachineCapabilities = new Repository<TreatmentMachineCapability>(treatmentMachineCapabilities);
            _hospitalEntities.TreatmentMachineCapabilityTopographyXref = new Repository<TreatmentMachineCapabilityTopographyXref>(treatmentMachineCapabilityTopographyXref);
            _hospitalEntities.TreatmentRooms = new Repository<TreatmentRoom>(treatmentRooms);

        #endregion
    }

}
}
