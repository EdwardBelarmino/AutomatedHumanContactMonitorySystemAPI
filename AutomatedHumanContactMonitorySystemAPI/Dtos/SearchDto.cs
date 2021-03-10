using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedHumanContactMonitorySystemAPI.Dtos
{
    public class SearchDto
    {
        public string SearchBy { get; set; }
        public string FilterBy { get; set; }
        public string SearchText { get; set; }
    }
}