using Hospital.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities.HospitalData
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
        public bool IsOccupied { get; set; }
    }

}
