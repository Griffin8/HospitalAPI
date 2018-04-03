namespace HospitalAPI.DataAccessLayer.DTO
{
    public class TreatmentMachineCapabilityTopographyXref : IIdentifiedEntity
    {
        public int Id { get; set; }

        public int? TreatmentMachineCapabilityTypeID { get; set; }

        public int? TopographyID { get; set; }

        public virtual Topography Topography { get; set; }

        public virtual TreatmentMachineCapabilityType TreatmentMachineCapabilityType { get; set; }
    }
}
