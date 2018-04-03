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
    /// TreatmentRooms Controller
    /// </summary>
    [RoutePrefix("api/v1/treatmentRooms")]
    public class TreatmentRoomsController : ApiController
    {
        private readonly IBusinessService _businessLayer;
        MemoryCache memoryCache = MemoryCache.Default;

        #region Public Constructor
        /// <summary>
        /// Public constructor to initialize businessLayer service instance
        /// </summary>
        /// <param name="businessLayer"></param>
        public TreatmentRoomsController(IBusinessService businessLayer)
        {
            _businessLayer = businessLayer;
        }
        #endregion

        /// <summary>
        /// Get all treatment rooms
        /// </summary>
        /// <returns></returns>
        // GET: api/treatmentRooms
        [ResponseType(typeof(List<TreatmentRoomEntity>))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            //get from memory cache. It is not necessary for this project since the data is small
            var memResult = memoryCache.Get("rooms");
            if (memResult != null)
            {
                return Ok(memResult);
            }

            var rooms = _businessLayer.GetAllTreatmentRooms();
            if (rooms == null || rooms.Count == 0)
            {
                return NotFound();
            }
            memoryCache.Add("rooms", rooms, DateTimeOffset.UtcNow.AddMinutes(5));
            return Ok(rooms);
        }
    }
}
