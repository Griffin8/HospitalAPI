using HospitalAPI.BusinessLayer;
using HospitalAPI.BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HospitalAPI.Controllers
{
    /// <summary>
    /// Consultations Controller
    /// </summary>
    [RoutePrefix("api/v1/consultations")]
    public class ConsultationsController : ApiController
    {
        private readonly IBusinessService _businessLayer;

        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize businessLayer service instance
        /// </summary>
        /// <param name="businessLayer"></param>
        public ConsultationsController(IBusinessService businessLayer)
        {
            _businessLayer = businessLayer;
        }
        #endregion

        /// <summary>
        /// Get all consultations
        /// </summary>
        /// <returns></returns>
        // GET: api/Consultations
        [ResponseType(typeof(List<ConsultationEntity>))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var consultationEntities = _businessLayer.GetAllConsultations();

            if (consultationEntities == null)
            {
                return NotFound();
            }
            return Ok(consultationEntities);
        }

        /// <summary>
        /// Get a list of consultations by consultaion date
        /// </summary>
        /// <param name="consultaionDate"></param>
        /// <returns></returns>
        // GET: api/Consultations/5
        [ResponseType(typeof(List<ConsultationEntity>))]
        [Route("{consultaionDate}", Name = "GetConsultationByDate")]
        [HttpGet]
        public IHttpActionResult Get(DateTime consultaionDate)
        {
            var consultations = _businessLayer.GetConsultationsByConsultaionDate(consultaionDate);
            if (consultations == null || consultations.Count == 0)
            {
                return NotFound();
            }
            return Ok(consultations);
        }


        /// <summary>
        /// Get a list of consultations by consultaion ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Consultations/5
        [ResponseType(typeof(ConsultationEntity))]
        [Route("{id:int:min(1)}", Name = "GetConsultationById")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var consultation = _businessLayer.GetConsultationsById(id);
            if (consultation == null)
            {
                return NotFound();
            }
            return Ok(consultation);
        }
    }
}
