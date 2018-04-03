using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.BusinessLayer.DTO
{
    public class ConsultationEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLasstName { get; set; }
        public int ConditionTypeId { get; set; }
        public string ConditionTypeName { get; set; }
        public int TopographyId { get; set; }
        public string TopographyName { get; set; }
        public int TreatmentRoomId { get; set; }
        public string TreatmentRoomName { get; set; }
        public DateTime RegistrationDatetime { get; set; }
        public DateTime ConsultationDatetime { get; set; }
    }
}
