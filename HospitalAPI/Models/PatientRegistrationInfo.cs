using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalAPI.Models
{
    /// <summary>
    /// Data model for patient registration
    /// </summary>
    public class PatientRegistrationInfo
    {
        /// <summary>
        /// Patient's First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Patient's Last Name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Patient's condition Type ID as defined in the data source (e.g. Cancer, Flu, etc.)
        /// </summary>
        [Required]
        public int ConditionTypeId { get; set; }

        /// <summary>
        /// Patient's Topography Id as defined in the data source (e.g. Head/Neck, Breast, etc.)
        /// </summary>
        [Required]
        public int TopographyId { get; set; }

        /// <summary>
        /// Doctor Id as defined in the data source
        /// </summary>
        [Required]
        public int DoctorId { get; set; }

        /// <summary>
        /// TreatmentRoom Id as defined in the data source
        /// </summary>
        [Required]
        public int TreatmentRoomId { get; set; }

        /// <summary>
        /// Consultation Date
        /// </summary>
        [Required]
        public DateTime ConsultationDate { get; set; }
    }
}