namespace HospitalAPI.DataAccessLayer.DTO
{
    using System;

    //[Table("Consultation")]
    public class Consultation : IIdentifiedEntity
    {
        public int Id { get; set; }

        public int PatiendID { get; set; }

        public int DoctorID { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int TreatmentRoomID { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual TreatmentRoom TreatmentRoom { get; set; }
    }
}
