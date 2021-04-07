using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedHumanContactMonitorySystemAPI.Dtos
{
    public class AttendeeDto
    {
        public int Id { get; set; }

        public long AttendeeRFID { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
    }
}