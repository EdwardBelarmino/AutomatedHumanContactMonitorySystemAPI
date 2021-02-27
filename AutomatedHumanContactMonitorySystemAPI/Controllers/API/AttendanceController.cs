﻿using AutomatedHumanContactMonitorySystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutomatedHumanContactMonitorySystemAPI.Controllers.API
{
    public class AttendanceController : ApiController
    {

        private ApplicationDbContext _context;
        // GET api/<controller>

        public AttendanceController() 
        {
            _context = new ApplicationDbContext();
        }
        public List<Attendance> Get()
        {
            var attendaces = _context.Attendances.Include(a => a.Attendee).Include(a => a.Place).ToList();
           

            return attendaces;
        }

        // GET api/<controller>/5
        public Attendance Get(int id)
        {
            var attendance = _context.Attendances.Include(a => a.Attendee).Include(a => a.Place).Where(a => a.Id == id).SingleOrDefault();

            return attendance;
        }

        // POST api/<controller>
        public void Post([FromBody] Attendance attendanceToAdd)
        {
            _context.Attendances.Add(attendanceToAdd);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put([FromBody] Attendance attendance)
        {
            var attendanceToUpdate = _context.Attendances.Where(a => a.Id == attendance.Id).SingleOrDefault();
            attendanceToUpdate.Id = attendance.Id;
            attendanceToUpdate.AttendeeId = attendance.AttendeeId;
            attendanceToUpdate.VisitedDateTime = attendance.VisitedDateTime;
            attendanceToUpdate.Temperature = attendance.Temperature;
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var attendance = _context.Attendances.Where(a => a.Id == id).SingleOrDefault();
            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
        }
    }
}