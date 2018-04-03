namespace HospitalAPI.DataAccessLayer.DTO
{
    using System.Collections.Generic;
 
    public class TreatmentRoom : IIdentifiedEntity
    {
        public TreatmentRoom()
        {
            Consultations = new HashSet<Consultation>();
            TreatmentMachines = new HashSet<TreatmentMachine>();
        }

        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string TreatmentRoomName { get; set; }

        public virtual ICollection<Consultation> Consultations { get; set; }

        public virtual ICollection<TreatmentMachine> TreatmentMachines { get; set; }
    }
}
