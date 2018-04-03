namespace HospitalAPI.DataAccessLayer.DTO
{
    using System.Collections.Generic;

    public class PatientCondition : IIdentifiedEntity
    {
        public PatientCondition()
        {
            Consultations = new HashSet<Consultation>();
        }

        public int Id { get; set; }

        public int ConditionTypeID { get; set; }

        public int TopographyID { get; set; }

        public int PatientID { get; set; }

        public virtual ConditionType ConditionType { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Topography Topography { get; set; }

        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}
