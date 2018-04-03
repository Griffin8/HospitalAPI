namespace HospitalAPI.DataAccessLayer.DTO
{
    using System;

    public class Patient : IIdentifiedEntity
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string LastName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string FirstName { get; set; }

        public DateTime RegistrationDatetime { get; set; }

        public int ConditionTypeID { get; set; }
        public string ConditionTypeName { get; set; }

        public int TopographyID { get; set; }

        public string TopographyName { get; set; }
    }
}
