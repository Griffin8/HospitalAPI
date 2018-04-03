using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPI.BusinessLayer.DTO
{
    public class TreatmentRoomEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        //[Required]
        //[StringLength(50)]
        public string TreatmentRoomName { get; set; }

        public List<TreatmentMachineEntity> TreatmentMachines { get; set; }
    }
}
