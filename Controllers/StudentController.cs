﻿

using DBSchoolManagementSystem.Models;
using DBSchoolManagementSystem.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;


namespace DBSchoolManagementSystem.Controllers
{



    public class StudentController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        StudentServices _SS = new StudentServices();

        public StudentController()
        {
        }

        public StudentController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        #region applicationsigninmanager
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        SchoolManagement db = new SchoolManagement();

        #endregion

        #region crudstudent
        public ActionResult Index()
        {
            var model = db.Student.ToList();
            return View(model);
        }

        public ActionResult ListStudent()
        {
            var model = _SS.GetStudentList();

            return View(model);
        }

        public ActionResult Create()
        {


            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student model, HttpPostedFileBase ImageFile)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, UserId = 1, UserTypeId = 2, UserStatus = "Active" };
            var result = await UserManager.CreateAsync(user, "User12345@@");
            using (SchoolManagement db = new SchoolManagement())
            {
                if (db.Student.Any(x => x.FullName == model.FullName))
                {
                    ModelState.AddModelError("FullName", "Name Already Exist");
                }

                if (result.Succeeded)
                {
                    var myuser = await UserManager.FindByEmailAsync(model.Email);
                    await UserManager.AddToRoleAsync(myuser.Id, "Student");
                    model.UserId = myuser.Id;



                    if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                        string extension = Path.GetExtension(model.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                        model.Studentimg = "../Image/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                        model.ImageFile.SaveAs(fileName);
                    }

                    if (ModelState.IsValid)
                {

                    db.Student.Add(model);
                    db.SaveChanges();

                    myuser.UserId = model.StudentId;
                    await UserManager.UpdateAsync(myuser);

                  
                   

                    
                        return RedirectToAction("Index");
                    }
                }
            }
                return View(model);

            }
         


      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Student.Find(id);
            if (model == null)
            {
                model = new Student();
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    model.Studentimg = "../Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                    //model.ImageFile.SaveAs(fileName);
                    //return RedirectToAction("Index");
                    if (model.ImageFile.ContentLength < 1000000)
                    {
                        db.Entry(model).State = EntityState.Modified;
                        if (db.SaveChanges() > 0)
                        {
                            model.ImageFile.SaveAs(fileName);
                        }

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "File must be less than or equal to 1 MB");
                    }

                }

            }
            else
            {
                //model.Studentimg = Session["imgPath"].ToString();
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }




            return View(model);
        }







        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student model = db.Student.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = db.Student.Find(id);
            db.Student.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Student.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        public ActionResult SaveStd()
        {
            var model = new Student();
            model.EnrollmentDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveStd(Student model)
        {
            String message = _SS.InsertStudent(model);
            if (message == "Saved Successfully")
            {
                return RedirectToAction("Index");
            }
            ViewBag.Errormessage = message;
            return View(model);
        }

        public ActionResult Update(int id)
        {
            var model = db.Student.Find(id);
            if (model == null)
            {
                model = new Student();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Student model)
        {
            String message = _SS.UpdateStudent(model);
            if (message == "Update Successfully")
            {
                return RedirectToAction("Index");
            }
            ViewBag.Errormessage = message;
            return View(model);
        }
        public ActionResult DeleteStd(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Student.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("DeleteStd")]
        public ActionResult DeleteStd(int id)
        {
            var model = db.Student.Find(id);
            String message = _SS.DeleteStudent(id);
            if (message == "Deleted Successfully")
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion

        #region leavenote
        public ActionResult SubmitLeaveNote()
        {

            ViewBag.Instructors = db.Instructor.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLeaveNote(LeaveNoteViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var UserId = User.Identity.GetUserId();
                var model = db.Student.FirstOrDefault(x => x.UserId == UserId);
                if (model != null)
                {
                    var leaveNote = new leaveNote
                    {


                        StudentId = model.StudentId,
                        Instructorid = viewModel.Instructorid,
                        Note = viewModel.Note,
                        Date = DateTime.Now
                    };


                    db.LeaveNotes.Add(leaveNote);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.Instructors = db.Instructor.ToList();

            return View(viewModel);
        }




        #endregion

        public ActionResult  Assignment()
        {
            ViewBag.message = db.Assignment.ToList();
            return View();
        }


        public ActionResult ViewAssignment(int id)
        {
            var assignment = db.Assignment.FirstOrDefault(x => x.AssignmentId == id);
            ViewBag.Assignment = assignment;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitAssignmentTo(SubmitAssignmentVm s)
        {
            string img = "";
            if (ModelState.IsValid)
            {
                if (s.FileUrl != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(s.FileUrl.FileName);
                    string extension = Path.GetExtension(s.FileUrl.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    img = "../Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                    s.FileUrl.SaveAs(fileName);

                }
                var model = new SubmitAssignment();
                model.AssignmentId = s.AssignmentId;
                model.StudentId = 23;
                model.UploadFile = img;

                db.Entry(model).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Submit");
            }
            return View(s);

        }
        public ActionResult Submit()
        {
            var submitlist = _SS.GetSubmitList();


            return View(submitlist);

        }
    }
}




