using ApiTracking.Data;
using ApiTracking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// IActionResult Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int pg =1)
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
        /// Task<IActionResult> Index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int id, int pg=1)
        {
            

            if (id == 0)
            {
                /* var query = _db.ApiTracking.AsNoTracking().OrderBy(s => s.ID);
                // var model = await PagingList.CreateAsync(query, 3, page);
                 IEnumerable<Details> objList = _db.ApiTracking;
                 return View(objList);*/
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
            else
            {
                ViewData["Get Api Tracking Details"] = id;

                var apiquery = from x in _db.ApiTracking select x;
                apiquery = apiquery.Where(x => x.ID == id);
                return View(apiquery);
            }
            
        }

     


    }
}
