namespace HospitalAPI.DataAccessLayer.DTO
{
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    //[Table("TreatmentMachineCapability")]
    public class TreatmentMachineCapability : IIdentifiedEntity
    {
        public int Id { get; set; }

        public int TreatmentMachineID { get; set; }

        public int TreatmentMachineCapabilityTypeID { get; set; }

        public virtual TreatmentMachine TreatmentMachine { get; set; }

        public virtual TreatmentMachineCapabilityType TreatmentMachineCapabilityType { get; set; }
    }
}
