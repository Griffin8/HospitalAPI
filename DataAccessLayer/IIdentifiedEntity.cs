using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.DataAccessLayer
{
    public interface IIdentifiedEntity
    {
        /// <summary>
        /// All DTO primary key should be named as Id so that the generic method GetItemById works
        /// </summary>
        int Id { get; set; }
    }
}