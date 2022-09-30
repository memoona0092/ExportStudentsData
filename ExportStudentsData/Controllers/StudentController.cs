using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExportStudentsData.Models;
using Rotativa;

namespace ExportStudentsData.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentDBContext studentDBContext=new StudentDBContext();
        public ActionResult Index()
        {
            return View(studentDBContext.Students.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student oStudent)
        {
            try { 

                studentDBContext.Students.Add(oStudent);
                studentDBContext.SaveChanges();
                }
            catch
            {
                throw;
            }

            return View();
        }
        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }



        public ActionResult PrintPartialViewToPdf(int id)
        {
            using (StudentDBContext db = new StudentDBContext())
            {
                Student oStudent = db.Students.FirstOrDefault(s => s.StudentID == id);

                var report = new PartialViewAsPdf("~/Views/Shared/DetailStudent.cshtml", oStudent);
                return report;
            }

        }

    }
}