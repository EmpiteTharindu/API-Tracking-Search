using ApiTracking.Data;
using ApiTracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTracking.Controllers
{
    public class SearchController1 : Controller
    {

        private readonly ApplicationDbContext _db;

        public SearchController1(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Task<IActionResult> Index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int id, int pg = 1, string SearchText = "")
        {

            List<Details> objList = _db.ApiTracking.ToList();
            const int pageSize = 3;
            if (pg < 1)
                pg = 1;

            int recsCount = objList.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = objList.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            return View(data);

        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public async Task<IActionResult> Search(string SearchText = "")
        {
            List<Details> objList;
            if (SearchText != "" && SearchText != null)
            {
                objList = _db.ApiTracking.Where(p => p.JsonResponse.Contains(SearchText)).ToList();
            }
            else
                objList = _db.ApiTracking.ToList();

            return View(objList);

        }


        /// <summary>
        /// View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult View(int id)
        {
            try
            {
                /* IEnumerable<Details> objList = _db.ApiTracking;
                 var result = _db.ApiTracking.First(p => p.ID == id).JsonResponse;
                 ViewBag.JsonData = JValue.Parse(result).ToString(Formatting.Indented);
                 return Ok(ViewBag.JsonData);*/

                IEnumerable<Details> objList;
                if (id != null)
                {
                    objList = _db.ApiTracking.Where(x => x.ID == id);
                }
                else
                    objList = _db.ApiTracking.ToList();

                return View(objList);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }






    }
}
