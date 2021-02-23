using AutomatedHumanContactMonitorySystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutomatedHumanContactMonitorySystemAPI.Controllers.API
{
    public class AttendeeController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendeeController() 
        {
            _context = new ApplicationDbContext();
        }
        public List<Attendee> Get()
        {
            var attendees = _context.Attendees.ToList();
            return attendees;
        }

        // GET api/<controller>/5
        public Attendee Get(int id)
        {
            var attendee = _context.Attendees.Where(a => a.Id == id).SingleOrDefault();
            return attendee;
        }

        // POST api/<controller>
       
        public void Post([FromBody] Attendee attendeeToAdd)
        {
            _context.Attendees.Add(attendeeToAdd);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Attendee attendee)
        {
            var attendeeToUpdate = _context.Attendee.Where(a => a.Id == attendee.Id).SingleOrDefault();
            attendeeToUpdate.Name = attendee.Name;
            attendeeToUpdate.Age = attendee.Age;
            attendeeToUpdate.Address = attendee.Address;
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var attendee = _context.Attendees.Where(a => a.Id == id).SingleOrDefault();
            _context.Attendees.Remove(attendee);
            _context.SaveChanges();
        }
    }
}