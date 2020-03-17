using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Students;
using Code360_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IStudents _student;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IGuarantor guarantorRepo;

        public HomeController(IStudents studentRepo, IWebHostEnvironment webHostEnvironment, IGuarantor guarantorRepo)
        {
            _student = studentRepo;
            this.webHostEnvironment = webHostEnvironment;
            this.guarantorRepo = guarantorRepo;
        }
        [Route("")]
        [Route("Index")]
        [Route("~/")]
        [AllowAnonymous]

        public ViewResult Index()
        {
            //view login page
            return View();
        }
        //[Route("~/Home")]
        [Route("Dashboard")]
        public ViewResult Dashboard()
        {            
            var model = _student.GetAllStudent();
            return View(model);
        }

        [Route("Delete/{id?}")]
        public IActionResult Delete(int id)
        {
            _student.DeleteStudent(id);
            return RedirectToAction("dashboard");
        }

        [Route("createStudent")]
        [HttpGet]
        public ViewResult createStudent()
        {
            return View();
        }

        [Route("createStudent")]
        [HttpPost]
        public IActionResult createStudent(StudentCreateView model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Student newStudent = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Gender = model.Gender,
                    Address = model.Address,
                    BVN = model.BVN,
                    AddmissionType = model.AddmissionType,
                    NextOfKinDocumentUrl = model.NextOfKinDocumentUrl,
                    NextOfKinEmail = model.NextOfKinEmail,
                    NextOfKinName = model.NextOfKinName,
                    NextOfKinPhone = model.NextOfKinPhone,
                    MaritalStatus = model.MaritalStatus,
                    Nationality = model.Nationality,
                    ImagePath = uniqueFileName,
                    Phone = model.Phone,
                    DateOfBirth = model.DateOfBirth,
                };
                Student stu = _student.AddStudent(newStudent);
                return RedirectToAction("create", "Guarantor", new { id = stu.ID});
                //return RedirectToAction("dashboard");
            }
            return View();
        }

        [Route("ViewStudent/{id?}")]
        public ViewResult ViewStudent(int id)
        {
            Student stu = _student.GetStudent(id);
            if (stu == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id);
            }
            DashboardView dashboardView = new DashboardView()
            {
                student = stu,
                pageTitle = "Student View"
            };
            return View(dashboardView);
        }
        
        [Route("EditStudent/{id?}")]
        [HttpGet]
        public ViewResult EditStudent(int id)
        {
            Student student = _student.GetStudent(id);
            EditView editView = new EditView()
            {
                //studentEdit = _student.GetStudent(id),
                //pagetitle = "Student Edit"
                Id = student.ID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                AddmissionType = student.AddmissionType,
                Address = student.Address,
                Gender = student.Gender,
                Phone = student.Phone,
                NextOfKinName = student.NextOfKinName,
                NextOfKinEmail = student.NextOfKinEmail,
                NextOfKinPhone = student.NextOfKinPhone,
                Nationality = student.Nationality,
                MaritalStatus = student.MaritalStatus

            };
            return View(editView);
        }

        [Route("EditStudent/{id?}")]
        [HttpPost]
        public IActionResult EditStudent(EditView student)
        {
            Student stu = _student.GetStudent(student.Id);

            if (ModelState.IsValid)
            {
                //stu.Name = student.Name;
                stu.FirstName = student.FirstName;
                stu.LastName = student.LastName;
                stu.Email = student.Email;
                stu.AddmissionType = student.AddmissionType;
                stu.Address = student.Address;
                stu.Gender = student.Gender;
                stu.Phone = student.Phone;
                stu.NextOfKinName = student.NextOfKinName;
                stu.NextOfKinEmail = student.NextOfKinEmail;
                stu.NextOfKinPhone = student.NextOfKinPhone;
                stu.Nationality = student.Nationality;
                stu.MaritalStatus = student.MaritalStatus;
            
                _student.UpdateStudent(stu);
                return RedirectToAction("dashboard");
            }
            return View();
        }

        //Ajax to delete a student

        public IActionResult DeleteStuff(int id)
        {
            var Students = _student.GetStudent(id);

            if (Students != null)
            {
                var removed = _student.DeleteStudent(id);

                if (removed != null)
                {
                    return Json(new { success = true, message = "Remove Successfull" });
                }
                else
                {
                    return Json(new { success = false, message = "Remove Failed" });
                }
            }
            return Json(new { success = false, message = "Student does not exist" });
        }
    }
}
