using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CHOJ.Models;
using CHOJ.Service;

namespace CHOJ.Controllers
{
    public class WikiController : BaseController
    {
        //
        // GET: /Wiki/
        [LoginedFilter(Role = "Admin")]
        public ActionResult Management()
        {
            var model = WikiService.GetInstance().List();
            return View(model);
        }

        //
        // GET: /Wiki/Details/5

        public ActionResult Details(string title)
        {
            var model = WikiService.GetInstance().Get(title);
            Title = model.Title;
            return View(model);
        }

        //
        // GET: /Wiki/Create
        [LoginedFilter(Role="Admin")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Wiki/Create
        [LoginedFilter(Role="Admin")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Wiki wiki)
        {
            try
            {
                // TODO: Add insert logic here
                WikiService.GetInstance().Add(wiki);
                return RedirectToAction("Management");
            }
            catch
            {
                return View();
            }
        }

        [LoginedFilter(Role = "Admin")]
        public ActionResult Delete(string id)
        {
            WikiService.GetInstance().Delete(id);
            return RedirectToAction("Management");
        }

        //
        // GET: /Wiki/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Wiki/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Management");
            }
            catch
            {
                return View();
            }
        }
    }
}
