using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASK_EHSprectical.Models;

namespace ASK_EHSprectical.Controllers
{
    public class employeeController : Controller
    {
        EmployeeMasterEntities db = new EmployeeMasterEntities();
        // GET: employee
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult empinsert()
        {

            employee emp = new employee();
            return View(emp);
        }
        [HttpPost]
        public ActionResult empinsert(employee obj, HttpPostedFileBase file)
        {


            string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
            file.SaveAs(path);
            obj.emp_image = "~/Images/" + file.FileName;
            
            db.employees.Add(obj);
            db.SaveChanges();
            Response.Write("successfully insert");
            ModelState.Clear();
            return RedirectToAction("show1");

        }
        [HttpGet]
        public ActionResult show1()
        {

            var counties = (from C in db.employees
                            select new { C.emp_department, C.emp_id }).ToList();
            List<SelectListItem> item2 = new List<SelectListItem>();
            foreach (var i in counties)
            {
                item2.Add(new SelectListItem { Text = i.emp_department.ToString(), Value = i.emp_id.ToString() });
            }
            item2.Insert(0, new SelectListItem() { Text = "Select", Value = "0" });


            ViewBag.Data1 = item2;
            var data = (from C in db.employees
                        select C).ToList();
            ViewBag.list = data;
            return View();
           
        }
            public ActionResult show1(employee obj)
        {
            var data = db.employees.Where(x => x.emp_department == obj.emp_department || x.emp_plant == obj.emp_plant || x.emp_first_name == obj.emp_first_name || x.emp_code == obj.emp_code).ToList();
           
            ViewBag.list = data;
            var counties = (from C in db.employees
                            select new { C.emp_department, C.emp_id }).ToList();
            List<SelectListItem> item2 = new List<SelectListItem>();
            foreach (var i in counties)
            {
                item2.Add(new SelectListItem { Text = i.emp_department.ToString(), Value = i.emp_id.ToString() });
            }
            item2.Insert(0, new SelectListItem() { Text = "Select", Value = "0" });


            ViewBag.Data1 = item2;
            return View();
        }

           

        public ActionResult editemployee(int id)
        {
            var employeedata = db.employees.Where(x=>x.emp_id==id).FirstOrDefault();
            if (employeedata != null)
            {
                TempData["id"] = id;
                TempData.Keep();
                return View(employeedata);
            }
           
            return View();
        }
        [HttpPost]
        public ActionResult editemployee(employee obj,HttpPostedFileBase file)
        {
            Int32 id = (int)TempData["id"];
            var StudentData = db.employees.Where(x => x.emp_id == id).FirstOrDefault();
           
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

               
                StudentData.emp_image = "~/Images/" + file.FileName;

                StudentData.emp_plant = obj.emp_plant;
                StudentData.emp_category = obj.emp_category;
                StudentData.emp_code = obj.emp_code;
                StudentData.emp_first_name = obj.emp_first_name;
                StudentData.emp_middel_name = obj.emp_middel_name;
                StudentData.emp_last_name = obj.emp_last_name;
                StudentData.emp_department = obj.emp_department;
                StudentData.repoting_manager = obj.repoting_manager;
                StudentData.emp_designation = obj.emp_designation;
                StudentData.emp_contact = obj.emp_contact;
                StudentData.emp_email = obj.emp_email;
                StudentData.date_of_join = obj.date_of_join;
                StudentData.job_relieving = obj.job_relieving;
                StudentData.blood_group = obj.blood_group;
                StudentData.DOB = obj.DOB;
                StudentData.emp_age = obj.emp_age;
                StudentData.emp_gender = obj.emp_gender;
                StudentData.active = obj.active;

                db.Entry(StudentData).State = EntityState.Modified;
                db.SaveChanges();
           
            return RedirectToAction("show1");
        }


    }
}