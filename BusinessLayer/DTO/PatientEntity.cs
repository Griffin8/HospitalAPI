using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.BusinessLayer.DTO
{
    public class PatientEntity
    {
        /// <summary>
        /// Patient
        /// </summary>
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int ConditionTypeId { get; set; }
        public string ConditionTypeName { get; set; }
        public int TopographyId { get; set; }
        public string TopographyName { get; set; }
        public DateTime RegistrationDatetime { get; set; }
    }
}
