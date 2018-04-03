using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HospitalAPI.BusinessLayer.DTO;
using HospitalAPI.BusinessLayer;
using System.Web.Http.Description;

namespace HospitalAPI.Controllers
{
    /// <summary>
    /// Patients Controller
    /// </summary>
    [RoutePrefix("api/v1/patients")]
    public class PatientsController : ApiController
    {
        private readonly IBusinessService _businessLayer;

        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize businessLayer service instance
        /// </summary>
        /// <param name="businessLayer"></param>
        public PatientsController(IBusinessService businessLayer)
        {
            _businessLayer = businessLayer;
        }
        #endregion

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        // GET: api/Patients
        [ResponseType(typeof(List<PatientEntity>))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var patients = _businessLayer.GetAllPatients();

            if (patients == null || patients.Count == 0)
            {
                return NotFound();
            }
            return Ok(patients);
        }

        /// <summary>
        /// Get a patient by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Patients/5
        [ResponseType(typeof(PatientEntity))]
        [Route("{id:int:min(1)}", Name = "GetPatientByID")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var patient = _businessLayer.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }    
}
