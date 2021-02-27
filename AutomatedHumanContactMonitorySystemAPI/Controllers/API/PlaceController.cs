using AutomatedHumanContactMonitorySystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutomatedHumanContactMonitorySystemAPI.Controllers.API
{
    public class PlaceController : ApiController
    {
        private ApplicationDbContext _context;

        public PlaceController()
        {
            _context = new ApplicationDbContext();
        }
       
        public List<Place> Get()
        {
            var places = _context.Places.ToList();
            return places;
        }

        // GET api/<controller>/5
        public Place Get(int id)
        {
            var place = _context.Places.Where(a => a.Id == id).SingleOrDefault();
            return place;
        }

        // POST api/<controller>
        public void Post([FromBody] Place placeToAdd)
        {
            _context.Places.Add(placeToAdd);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put([FromBody] Place place)
        {
            var placeToUpdate = _context.Places.Where(a => a.Id == place.Id).SingleOrDefault();
            placeToUpdate.Location = place.Location;
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var place = _context.Places.Where(a => a.Id == id).SingleOrDefault();
            _context.Places.Remove(place);
            _context.SaveChanges();
        }
    }
}