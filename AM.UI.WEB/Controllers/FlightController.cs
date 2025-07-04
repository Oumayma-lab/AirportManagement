﻿using AM.Applactioncore.Domaine;
using AM.Applactioncore.Intterfaces;
using AM.Applactioncore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight sf;
        IServicePlane sp;

        public FlightController(IServiceFlight sf,IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }

        // GET: FlightController
        public ActionResult Index()
        {   
            return View(sf.GetMany());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var flight = sf.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }


        // GET: FlightController/Create
        //formulair vide
        public ActionResult Create()
        {

            ViewBag.planeFK =
                new SelectList(sp.GetMany(), "PlaneId", "Information"); // on récupère par la clé priùmaire ( planeID) 
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection)
        {
            try
            {
                sf.Add(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
