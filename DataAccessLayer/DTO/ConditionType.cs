namespace HospitalAPI.DataAccessLayer.DTO
{
    using System;
    using System.Collections.Generic;

    public class ConditionType : IIdentifiedEntity
    {
        public ConditionType()
        {
            PatientConditions = new HashSet<PatientCondition>();
        }

        /// <summary>
        /// has to be "Id"
        /// </summary>
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string ConditionTypeName { get; set; }

        public virtual ICollection<PatientCondition> PatientConditions { get; set; }
    }
}
