using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.BusinessLayer.DTO
{
    public class DoctorRoleEntity
    {
        public int Id { get; set; }

        //[StringLength(50)]
        public string DoctorRoleName { get; set; }
    }
}
