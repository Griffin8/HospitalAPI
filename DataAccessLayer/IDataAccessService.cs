using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.DataAccessLayer.DTO;


namespace HospitalAPI.DataAccessLayer
{
    public interface IDataAccessService
    {
        Repository<Patient> PatientRepository { get; }
        Repository<Doctor> DoctorRepository { get; }
        Repository<DoctorRole> DoctorRoleRepository { get; }
        Repository<DoctorRoleXref> DoctorRoleXrefRepository { get; }
        Repository<DoctorRoleConditionTypeXref> DoctorRoleConditionTypeXrefRepository { get; }
        Repository<Consultation> ConsultationRepository { get; }
        Repository<ConditionType> ConditionTypeRepository { get; }
        Repository<Topography> TopographyRepository { get; }
        Repository<TreatmentRoom> TreatmentRoomRepository { get; }
        Repository<TreatmentMachine> TreatmentMachineRepository { get; }
        Repository<TreatmentMachineCapabilityType> TreatmentMachineCapabilityTypeRepository { get; }
        Repository<TreatmentMachineCapability> TreatmentMachineCapabilityRepository { get; }
        Repository<TreatmentMachineCapabilityTopographyXref> TreatmentMachineCapabilityTopographyXrefRepository { get; }

        List<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        Patient AddPatient(Patient newPatient);

        List<Consultation> GetAllConsultations();
        List<Consultation> GetAllConsultationsByConsultaionDate(DateTime consultaionDate);
        Consultation AddConsultation(Consultation consultation);
    }
}
