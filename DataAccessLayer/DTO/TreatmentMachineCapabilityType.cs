namespace HospitalAPI.DataAccessLayer.DTO
{
    using System.Collections.Generic;
 
    public class TreatmentMachineCapabilityType : IIdentifiedEntity
    {
        public TreatmentMachineCapabilityType()
        {
            TreatmentMachineCapabilities = new HashSet<TreatmentMachineCapability>();
            TreatmentMachineCapabilityTopographyXrefs = new HashSet<TreatmentMachineCapabilityTopographyXref>();
        }

        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string TreatmentMachineCapabilityTypeName { get; set; }

        public virtual ICollection<TreatmentMachineCapability> TreatmentMachineCapabilities { get; set; }

        public virtual ICollection<TreatmentMachineCapabilityTopographyXref> TreatmentMachineCapabilityTopographyXrefs { get; set; }
    }
}
