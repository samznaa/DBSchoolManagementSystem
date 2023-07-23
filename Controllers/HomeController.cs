using DBSchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{

    public class HomeController : Controller
    {
        SchoolManagement db = new SchoolManagement();



        public ActionResult Index()
        {
            HomePageCount model = new HomePageCount
            {
                InstructorCount = db.Instructor.Count(),
                StudentCount = db.Student.Count(),
                CourseCount = db.Course.Count(),
                DepartmentCount = db.Department.Count(),
               
            };

            return View(model);
        }
       

        public ActionResult Search(string searchQuery)
        {
            List<Student> students = db.Student.ToList();
            List<Instructor> instructors = db.Instructor.ToList();

            char firstLetter = searchQuery.FirstOrDefault().ToString().ToLower()[0];

            students = students.Where(s => char.ToLower(s.FullName[0]) == firstLetter).ToList();
            instructors = instructors.Where(i => char.ToLower(i.FirstName[0]) == firstLetter).ToList();

            SearchViewModel searchViewModel = new SearchViewModel
            {
                Students = students,
                Instructors = instructors
            };

            return View(searchViewModel);
        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our contact page.";

            return View();
        }
        [HttpPost]

        public ActionResult Contact(string name, string email, string message)
        {

            return RedirectToAction("ThankYou");

        }

        public ActionResult ThankYou()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }





    }
}
