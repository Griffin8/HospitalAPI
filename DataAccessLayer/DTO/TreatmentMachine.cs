namespace HospitalAPI.DataAccessLayer.DTO
{
    using System.Collections.Generic;

    public class TreatmentMachine : IIdentifiedEntity
    {
        public TreatmentMachine()
        {
            TreatmentMachineCapabilities = new HashSet<TreatmentMachineCapability>();
        }

        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string TreatmentMachineName { get; set; }

        public int TreatmentRoomID { get; set; }

        public virtual TreatmentRoom TreatmentRoom { get; set; }

        public virtual ICollection<TreatmentMachineCapability> TreatmentMachineCapabilities { get; set; }
    }
}
