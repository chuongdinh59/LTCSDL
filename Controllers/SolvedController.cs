﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Service;
using BuildingDemo.Models;
using BuildingDemo.Filter;

namespace BuildingDemo.Controllers
{
    public class SolvedController : Controller
    {
        private BuildingService buildingService = new BuildingService();
        private BuildingTypeService buildingTypeService = new BuildingTypeService();
        private CustomerService customerService = new CustomerService();
        // GET: Solved
        [AuthenticationFilter]
        public ActionResult Index()
        {
            // Check lại có thể sai 
            int id = (int)Session["ID"];
            Customer customer = customerService.FindByAccountID(id);
            List<Building> buildings = buildingService.GetBuildingFromCustomer(customer).
                Where(b => b.IsResolve == true && b.ManagementBuildings.Any(m => m.IsSuccess == false)).ToList();
            return View(buildings, customer);
        }
        private ActionResult View(List<Building> buildings, Customer customer)  
        {
            ViewBag.buildings = buildings;
            ViewBag.customer = customer;
            return View();
        }
        // GET: Solved/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Solved/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solved/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Solved/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Solved/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Solved/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Solved/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
