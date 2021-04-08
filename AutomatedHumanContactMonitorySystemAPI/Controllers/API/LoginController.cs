using AutomatedHumanContactMonitorySystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace AutomatedHumanContactMonitorySystemAPI.Controllers.API
{
    public class LoginController : ApiController
    {
        private ApplicationDbContext _context;
        // GET api/<controller>

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }



        [HttpPost]
        public IHttpActionResult Authorize(AppUser loginAppUser)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var isAuthorized = _context.AppUsers.Where(a => a.Username == loginAppUser.Username && a.Password == loginAppUser.Password).Any();

            return Ok(isAuthorized);
        }
    }
}