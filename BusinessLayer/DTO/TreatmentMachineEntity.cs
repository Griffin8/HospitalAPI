
namespace HospitalAPI.BusinessLayer.DTO
{
    public class TreatmentMachineEntity
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string TreatmentMachineName { get; set; }

        public string TreatmentMachineCapabilityTypeName { get; set; }
    }
}
