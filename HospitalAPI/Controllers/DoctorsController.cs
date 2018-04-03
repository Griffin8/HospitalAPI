using System.Runtime.Caching;
using System.Collections.Generic;
using System.Web.Http;
using HospitalAPI.BusinessLayer.DTO;
using HospitalAPI.BusinessLayer;
using System.Web.Http.Description;
using System;

namespace HospitalAPI.Controllers
{
    /// <summary>
    /// Doctors Controller
    /// </summary>
    [RoutePrefix("api/v1/doctors")]
    public class DoctorsController : ApiController
    {
        private readonly IBusinessService _businessLayer;
        MemoryCache memoryCache = MemoryCache.Default;

        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize businessLayer service instance
        /// </summary>
        /// <param name="businessLayer"></param>
        public DoctorsController(IBusinessService businessLayer)
        {
            _businessLayer = businessLayer;
        }
        #endregion

        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <returns></returns>
        // GET: api/Doctors
        [ResponseType(typeof(List<DoctorEntity>))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            //get from memory cache. It is not necessary for this project since the data is small
            var memResult = memoryCache.Get("doctors"); 
            if(memResult != null)
            {
                return Ok(memResult);
            }

            var doctors = _businessLayer.GetAllDoctors();
            if (doctors == null || doctors.Count == 0)
            {
                return NotFound();
            }
            memoryCache.Add("doctors", doctors, DateTimeOffset.UtcNow.AddMinutes(5));
            return Ok(doctors);

        }

        /// <summary>
        /// Get a doctor by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Doctors/5
        [ResponseType(typeof(DoctorEntity))]
        [Route("{id:int:min(1)}", Name = "GetDoctorByID")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var doctor = _businessLayer.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
    }
}
