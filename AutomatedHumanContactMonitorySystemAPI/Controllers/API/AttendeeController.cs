using AutoMapper;
using AutomatedHumanContactMonitorySystemAPI.Dtos;
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
       
        public string Post([FromBody] Attendee attendeeToAdd)
        {
            if (_context.Attendees.Where(a => a.AttendeeRFID == attendeeToAdd.AttendeeRFID).Any())
            {
                return "RFID already registered";
            }
            else
            {
                _context.Attendees.Add(attendeeToAdd);
                _context.SaveChanges();
                return "Registration successful";

            }
    
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Attendee attendee)
        {
            var attendeeToUpdate = _context.Attendees.Where(a => a.Id == attendee.Id).SingleOrDefault();
            attendeeToUpdate.Name = attendee.Name;
            attendeeToUpdate.AttendeeRFID = attendee.AttendeeRFID;
            attendeeToUpdate.Age = attendee.Age;
            attendeeToUpdate.Address = attendee.Address;
            _context.SaveChanges();
        }

        [HttpPost]
        public void UpdateAttendeeStatus([FromBody] Attendee attendee)
        {
            var attendeeToUpdate = _context.Attendees.Where(a => a.Id == attendee.Id).SingleOrDefault();
            attendeeToUpdate.Status = attendee.Status;
            _context.SaveChanges();
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var attendee = _context.Attendees.Where(a => a.Id == id).SingleOrDefault();
            _context.Attendees.Remove(attendee);
            _context.SaveChanges();
        }

        [HttpPost]
        public IHttpActionResult GetAttendeeBySearchParameter(SearchDto searchDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var attendees = _context.Attendees.AsEnumerable();

            switch (searchDto.SearchBy.ToUpper().Trim())
            {
                case "NAME":
                    attendees = attendees.Where(a => a.Name.Contains(searchDto.SearchText));
                    break;
                case "ADDRESS":
                    attendees = attendees.Where(a => a.Address.Contains(searchDto.SearchText));
                    break;
                default:
                    break;

            }
            //.ToList()
            //.Select(Mapper.Map<Item, ItemDto>);

            return Ok(attendees.ToList());
        }
    }
}