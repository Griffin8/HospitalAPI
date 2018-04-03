namespace HospitalAPI.DataAccessLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class DoctorRoleXref : IIdentifiedEntity
    {
        public int Id { get; set; }

        public int DoctorRoleID { get; set; }

        public int DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual DoctorRole DoctorRole { get; set; }
    }
}
