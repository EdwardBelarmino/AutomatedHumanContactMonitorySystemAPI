using AutomatedHumanContactMonitorySystemAPI.Dtos;
using AutomatedHumanContactMonitorySystemAPI.Models;
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
        public List<AttendanceDto> Get()
        {
            var attendaces = _context.Attendances.Include(a => a.Attendee)
                                                 .Include(a => a.Place)
                                                 .Select(a => new AttendanceDto { Id = a.Id, 
                                                                                  VisitedDateTime = a.VisitedDateTime, 
                                                                                  Temperature = a.Temperature, 
                                                                                  AttendeeId = a.Attendee.Id, 
                                                                                  AttendeeRFID = a.Attendee.AttendeeRFID,
                                                                                  AttendeeStatus = a.Attendee.Status,
                                                                                  Status = a.Status,
                                                                                  Name = a.Attendee.Name, 
                                                                                  Age = a.Attendee.Age, 
                                                                                  Address = a.Attendee.Address, 
                                                                                  PlaceId = a.Place.Id,
                                                                                  Location = a.Place.Location})
                                                 .ToList();
           

            return attendaces;
        }

        // GET api/<controller>/5
        public Attendance Get(int id)
        {
            var attendance = _context.Attendances.Include(a => a.Attendee)
                                                 .Include(a => a.Place)
                                                 .Where(a => a.Id == id)
                                                 .SingleOrDefault();

            return attendance;
        }

        // POST api/<controller>
        public void Post([FromBody] Attendance attendanceToAdd)
        {
            _context.Attendances.Add(attendanceToAdd);
            _context.SaveChanges();
        }

        // PUT api/<controller>/UpdateAttendanceStatus
        [HttpPost]
        public void UpdateAttendanceStatus([FromBody] Attendance attendance)
        {
            var attendanceToUpdate = _context.Attendances.Where(a => a.Id == attendance.Id).SingleOrDefault();
            attendanceToUpdate.Status = attendance.Status;
            _context.SaveChanges();
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var attendance = _context.Attendances.Where(a => a.Id == id).SingleOrDefault();
            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
        }

        [HttpPost]
        public IHttpActionResult GetAttendanceBySearchParameter(SearchDto searchDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var attendances = _context.Attendances.Include(a => a.Attendee)
                                                  .Include(a => a.Place)
                                                  .Select(a => new AttendanceDto
                                                  {
                                                      Id = a.Id,
                                                      VisitedDateTime = a.VisitedDateTime,
                                                      Temperature = a.Temperature,
                                                      AttendeeId = a.Attendee.Id,
                                                      AttendeeRFID = a.Attendee.AttendeeRFID,
                                                      AttendeeStatus = a.Attendee.Status,
                                                      Status = a.Status,
                                                      Name = a.Attendee.Name,
                                                      Age = a.Attendee.Age,
                                                      Address = a.Attendee.Address,
                                                      PlaceId = a.Place.Id,
                                                      Location = a.Place.Location

                                                  })
                                                  .AsEnumerable();

            switch (searchDto.SearchBy.ToUpper().Trim())
            {
                case "DATEANDTIME":
                    attendances = attendances.Where(a => a.VisitedDateTime.ToString().Contains(searchDto.SearchText));
                    break;
                case "TEMPERATURE":
                    attendances = attendances.Where(a => a.Temperature.ToString().Contains(searchDto.SearchText));
                    break;
                case "NAME":
                    attendances = attendances.Where(a => a.Name.ToString().Contains(searchDto.SearchText));
                    break;
                case "RFID":
                    attendances = attendances.Where(a => a.AttendeeRFID.ToString().Contains(searchDto.SearchText));
                    break;
                case "LOCATION":
                    attendances = attendances.Where(a => a.Location.ToString().Contains(searchDto.SearchText));
                    break;
                default:
                    break;

            }
            //.ToList()
            //.Select(Mapper.Map<Item, ItemDto>);

            return Ok(attendances.ToList());
        }

        [HttpPost]
        public IHttpActionResult GetAttendanceByDate([FromBody] SearchDto searchDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var attendances = _context.Attendances.Include(a => a.Attendee)
                                                  .Include(a => a.Place)
                                                  .Where(a => a.VisitedDateTime.Date.Year == searchDto.Date.Value.Year &&
                                                              a.VisitedDateTime.Date.Month == searchDto.Date.Value.Month &&
                                                              a.VisitedDateTime.Date.Day == searchDto.Date.Value.Day)
                                                  .Select(a => new AttendanceDto
                                                  {
                                                      Id = a.Id,
                                                      VisitedDateTime = a.VisitedDateTime,
                                                      Temperature = a.Temperature,
                                                      AttendeeId = a.Attendee.Id,
                                                      AttendeeRFID = a.Attendee.AttendeeRFID,
                                                      AttendeeStatus = a.Attendee.Status,
                                                      Status = a.Status,
                                                      Name = a.Attendee.Name,
                                                      Age = a.Attendee.Age,
                                                      Address = a.Attendee.Address,
                                                      PlaceId = a.Place.Id,
                                                      Location = a.Place.Location

                                                  })
                                                  .AsEnumerable();

            return Ok(attendances.ToList());
        }
    }
}