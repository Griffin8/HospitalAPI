using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.BusinessLayer.DTO
{
    public class PatientRegistrationInfoEntity
    {
        /// <summary>
        /// Patient's First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Patient's Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Patient's condition Type ID as defined in the data source (e.g. Cancer, Flu, etc.)
        /// </summary>
        public int ConditionTypeId { get; set; }

        /// <summary>
        /// The name of condition
        /// </summary>
        //public string ConditionTypeName { get; set; }

        /// <summary>
        /// Patient's Topography Id as defined in the data source (e.g. Head & Neck, Breast, etc.)
        /// </summary>
        public int TopographyId { get; set; }

        /// <summary>
        /// Doctor Id as defined in the data source
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// TreatmentRoom Id as defined in the data source
        /// </summary>
        public int TreatmentRoomId { get; set; }

        /// <summary>
        /// Consultation Date
        /// </summary>
        public DateTime ConsultationDate { get; set; }

    }
}
