namespace HospitalAPI.DataAccessLayer.DTO
{
    using System.Collections.Generic;

    public class DoctorRole : IIdentifiedEntity
    {
        public DoctorRole()
        {
            DoctorRoleXrefs = new HashSet<DoctorRoleXref>();
        }

        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string DoctorRoleName { get; set; }

        public virtual ICollection<DoctorRoleXref> DoctorRoleXrefs { get; set; }
    }
}
