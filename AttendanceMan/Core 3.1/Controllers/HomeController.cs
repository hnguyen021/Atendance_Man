using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core_3._1.Models;
using Microsoft.AspNetCore.Authorization;
using Core_3._1.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core_3._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _db;

        public HomeController(ILogger<HomeController> logger, AppDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<PhysicalClass> subjectList = _db.PhysicalClasses;
            return View(subjectList);
        }
        public IActionResult ViewStudent(long id)
        {
            IEnumerable<Student> StudentList = _db.Students.Where(x => x.IdPhysicalClass == id).ToList();
            ViewBag.Attendance = _db.AttendanceEntries.ToList();
            return View(StudentList);
        }
        [HttpGet]
        public IActionResult CheckAttendance(long id)
        {

            var model = new AttendanceCheckViewModel();
            model.Students = _db.Students.Where(x => x.IdPhysicalClass == id).ToList();
            model.AttendanceEntry = _db.AttendanceEntries.Where(x => x.IdPhysicalClass == id).ToList();
            

            return View(model);
        }
        [HttpGet]
        public IActionResult AddAttendance(long id)
        {

            //var model = new AttendanceCheckViewModel();
            //model.Students = _db.Students.Where(x => x.IdPhysicalClass == id).ToList();
            // model.AttendanceEntry = _db.AttendanceEntries.Where(x => x.IdPhysicalClass == id).ToList();
            var st = _db.Students.Where(x => x.IdPhysicalClass == id).ToList();
            foreach (var item in st) {
                AttendanceEntry at = new AttendanceEntry()
                {
                    DateCheck = DateTime.Now,
                    CheckAttendance = false,
                    IdPhysicalClass = id,
                    IdStudent = item.IdStudent


                };
                _db.Add(at);
                _db.SaveChanges();
                } 


            return RedirectToAction("Index","Home");
        }
        [HttpPost]

        public IActionResult UpdateAttendance(long idCheck)
        {

            // var model = new AttendanceCheckViewModel();
            var t = _db.AttendanceEntries.Where(x => x.IdAttendanceEntry == idCheck).FirstOrDefault();
            var CheckAt = t.CheckAttendance;

            if (CheckAt == true)
            {
                t.CheckAttendance = false;
            }
            else
            {
                t.CheckAttendance = true;
            }
            _db.Update(t);
            _db.SaveChanges();
            TempData["message"] = "Thêm Thành công";
            ViewBag.SuccessMsg = "Thêm Thành công";
            // model.Students = _db.Students.Where(x => x.IdPhysicalClass == idCheck).ToList();
            //model.AttendanceEntry = _db.AttendanceEntries.Where(x => x.IdPhysicalClass == idCheck).ToList();
            // /"location.reload(true)");
            return RedirectToAction("CheckAttendance");
        }

        public IActionResult AddStudent()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ActionAddStudent(Student st)
        {
            if (ModelState.IsValid)
            {
                AttendanceEntry te = _db.AttendanceEntries.OrderByDescending(x => x.IdAttendanceEntry).FirstOrDefault();
                var idE = te.IdAttendanceEntry;
                Student stu = new Student()
                {

                    NameStudent = st.NameStudent,
                    Score = st.Score,
                    IdPhysicalClass = st.IdPhysicalClass,
                    IdAttendanceEntry = idE+1,



                };
                _db.Add(stu);
                 _db.SaveChanges();
                Task.Delay(2000).Wait();
                Student t = _db.Students.OrderByDescending(x => x.IdStudent).FirstOrDefault();
                var ids = t.IdStudent;
                AttendanceEntry at = new AttendanceEntry()
                {
                    DateCheck = DateTime.Now,
                    CheckAttendance = false,
                    IdPhysicalClass = st.IdPhysicalClass,
                    IdStudent = ids

                };
                _db.Add(at);
                _db.SaveChanges();
                TempData["message"] = "Thêm Thành công";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.SuccessMsg = "Thêm Thành công";
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult UpdateStudent(long id)
        {
            var student = _db.Students.Where(x => x.IdStudent == id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult ActionUpdateStudent(Student st)
        {
            if (ModelState.IsValid)
            {

                Student stu = new Student()
                {
                    IdStudent = st.IdStudent,
                    NameStudent = st.NameStudent,
                    Score = st.Score,
                    IdPhysicalClass = st.IdPhysicalClass,
                    IdAttendanceEntry = st.IdAttendanceEntry,



                };
                _db.Update(stu);
                _db.SaveChanges();
                
                
            }
            TempData["message"] = "Thêm Thành công";
            ViewBag.SuccessMsg = "Thêm Thành công";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult DeleteStudent(long id)
        {
            var studenAt = _db.AttendanceEntries.Where(x => x.IdStudent == id);
            foreach(var st in studenAt)
            {
                _db.Remove(st);
                
                Task.Delay(1000).Wait();
            }
             Task.Delay(1000).Wait();
            var student = _db.Students.Where(x => x.IdStudent == id).FirstOrDefault();
            _db.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        
        //[BindProperty(SupportsGet =tr)]s
        [HttpGet]
        public IActionResult SearchStudent(string text)
        {

            ViewBag.Attendance = _db.AttendanceEntries.ToList();
            //return View(StudentList);
            var model = _db.Students.Where(x => x.NameStudent.Contains(text)).ToList();
            return View(model);
        }

        public IActionResult ViewTeacher()
        {
            var model = _db.Lecturers.ToList();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
