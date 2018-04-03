namespace HospitalAPI.DataAccessLayer.DTO
{
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    //[Table("Doctor")]
    public class Doctor : IIdentifiedEntity
    {
        public Doctor()
        {
            DoctorRoleXrefs = new HashSet<DoctorRoleXref>();
            Consultations = new HashSet<Consultation>();
        }

        public int Id { get; set; }

        //[StringLength(50)]
        public string FirstName { get; set; }

       // [Required]
        //[StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<DoctorRoleXref> DoctorRoleXrefs { get; set; }

        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}
