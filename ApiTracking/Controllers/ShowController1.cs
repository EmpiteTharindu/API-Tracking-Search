using ApiTracking.Data;
using ApiTracking.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTracking.Controllers
{
    [Route ("api/[controller]")]
    public class ShowController1 : Controller
    {
        private readonly ApplicationDbContext _db;

        public ShowController1(ApplicationDbContext db)
        {
            _db = db;
        }

        [Produces("application/json")]
        [HttpGet ("showdetails")]
        public async Task<IActionResult> ShowDetails()
        {
            try
            {
                List<Details> objList = _db.ApiTracking.ToList();
                return  Ok(objList);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
