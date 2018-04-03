using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.BusinessLayer.DTO
{
    public class DoctorEntity
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        //[StringLength(50)]
        public string FirstName { get; set; }

        // [Required]
        //[StringLength(50)]
        public string LastName { get; set; }

        public virtual List<DoctorRoleEntity> Roles { get; set; }

    }
}
