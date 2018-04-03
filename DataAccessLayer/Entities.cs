using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.DataAccessLayer.DTO;

namespace HospitalAPI.DataAccessLayer
{
    public class Entities
    {
        public Repository<Patient> Patients { get; set; }
        public Repository<ConditionType> ConditionTypes { get; set; }
        public Repository<PatientCondition> PatientConditions { get; set; }
        public Repository<Doctor> Doctors { get; set; }
        public Repository<DoctorRole> DoctorRoles { get; set; }
        public Repository<DoctorRoleConditionTypeXref> DoctorRoleConditionTypeXref { get; set; }
        public Repository<DoctorRoleXref> DoctorRoleXref { get; set; }
        public Repository<Consultation> consultations { get; set; }
        public Repository<Topography> Topographies { get; set; }
        public Repository<TreatmentMachine> TreatmentMachines { get; set; }
        public Repository<TreatmentMachineCapabilityType> TreatmentMachineCapabilityTypes { get; set; }
        public Repository<TreatmentMachineCapability> TreatmentMachineCapabilities { get; set; }
        public Repository<TreatmentMachineCapabilityTopographyXref> TreatmentMachineCapabilityTopographyXref { get; set; }
        public Repository<TreatmentRoom> TreatmentRooms { get; set; }
    }
}
