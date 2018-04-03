namespace HospitalAPI.DataAccessLayer.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class DoctorRoleConditionTypeXref : IIdentifiedEntity
    {
        public int Id { get; set; }
        public int DoctorRoleID { get; set; }
        public int ConditionTypeID { get; set; }
    
        public virtual ConditionType ConditionType { get; set; }
        public virtual DoctorRole DoctorRole { get; set; }
    }
}
