using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HospitalAPI.BusinessLayer.DTO;
using HospitalAPI.BusinessLayer;
using HospitalAPI.Filters;
using HospitalAPI.Models;
using System.Web.Http.Description;

namespace HospitalAPI.Controllers
{
    /// <summary>
    /// Patient Registration Controller
    /// </summary>
    [RoutePrefix("api/v1/patientRegistration")]
    public class PatientRegistrationController : ApiController
    {
        private readonly IBusinessService _businessLayer;

        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize businessLayer service instance
        /// </summary>
        /// <param name="businessLayer"></param>
        public PatientRegistrationController(IBusinessService businessLayer)
        {
            _businessLayer = businessLayer;
        }
        #endregion

        /// <summary>
        /// Register a new patient and schedule a consultation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Patients
        [ValidateModel]
        [ResponseType(typeof(void))]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]PatientRegistrationInfo value)
        {
            if (ModelState.IsValid)
            {
                PatientRegistrationInfoEntity patientReg = new PatientRegistrationInfoEntity();
                patientReg.FirstName = value.FirstName;
                patientReg.LastName = value.LastName;
                patientReg.DoctorId = value.DoctorId;
                patientReg.TreatmentRoomId = value.TreatmentRoomId;
                patientReg.ConditionTypeId = value.ConditionTypeId;
                patientReg.TopographyId = value.TopographyId;
                patientReg.ConsultationDate = value.ConsultationDate;

                try
                {
                    var newId = _businessLayer.RegisterPatient(patientReg);

                    //Generate a link to the new consultation and set the location header in the response
                    var location = new Uri(Url.Link("GetConsultationById", new { id = newId }));

                    return Created(location, "Patient is regiested");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
