using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shaurya_Round.Data;
using Shaurya_Round.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShauryaTest.Controllers
{
    public class employeeController : Controller
    {
        employeeDAL db = new employeeDAL();
        // GET: employeeController
        public ActionResult Index()
        {
            var model = db.Getemployee();
            return View(model);
        }

        // GET: employeeController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetemployeebyId(id);
            return View(model);
        }

        // GET: employeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(employeee empl)
        {
            try
            {
                int result = db.Addemployee(empl);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: employeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.GetemployeebyId(id);
            return View(model);
        }

        // POST: employeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(employeee empl)
        {
            try
            {
                int result = db.Updateemployee(empl);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: employeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.GetemployeebyId(id);
            return View(model);
        }

        // POST: employeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = db.Deleteemployee(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}