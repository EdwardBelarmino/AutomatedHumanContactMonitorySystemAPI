﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedHumanContactMonitorySystemAPI.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Attendee Attendee { get; set; }
        public int AttendeeId { get; set; }
        public DateTime VisitedDateTime { get; set; }
        public double Temperature { get; set; }
        public Place Place { get; set; }
        public int PlaceId { get; set; }
        public string Status { get; set; }

    }
}