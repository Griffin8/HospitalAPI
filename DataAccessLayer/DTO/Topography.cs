namespace HospitalAPI.DataAccessLayer.DTO
{
    using System.Collections.Generic;
 
    public class Topography : IIdentifiedEntity
    {
        public Topography()
        {
            PatientConditions = new HashSet<PatientCondition>();
            TreatmentMachineCapabilityTopographyXrefs = new HashSet<TreatmentMachineCapabilityTopographyXref>();
        }

        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string TopographyName { get; set; }

        public virtual ICollection<PatientCondition> PatientConditions { get; set; }

        public virtual ICollection<TreatmentMachineCapabilityTopographyXref> TreatmentMachineCapabilityTopographyXrefs { get; set; }
    }
}
