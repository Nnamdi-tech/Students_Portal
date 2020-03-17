using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models.Batchs;
using Code360_Management.Models.Students;
using Code360_Management.Models.Students_In_Batch;
using Code360_Management.ViewModels.Batch;
using Code360_Management.ViewModels.studentInBatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Code360_Management.Controllers
{
    [Route("Batch")]
    public class BatchController : Controller
    {
        private readonly IBatch _batchRepo;
        private readonly IStudentBatch _studentBatchRepo;
        private readonly IStudents _studentRepo;

        public BatchController(IBatch batchRepo, IStudentBatch studentBatchRepo, IStudents studentRepo)
        {
            _batchRepo = batchRepo;
            _studentBatchRepo = studentBatchRepo;
            _studentRepo = studentRepo;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View(_batchRepo.GetAllBatch());
        }

        [Route("AddBatch")]
        [HttpGet]
        public ViewResult create()
        {
            return View();
        }

        [Route("AddBatch")]
        [HttpPost]
        public IActionResult create(batchViewModel model)
        {
            if (ModelState.IsValid)
            {
                Batch batch = new Batch()
                {
                   Name = model.BatchName,
                   Supervisor = model.Title.ToString() + ". " + model.FirstName + " " + model.LastName,
                   StartDate = model.startDate,
                   EndDate = model.endDate
                };
                _batchRepo.AddBatch(batch);
            }
            return RedirectToAction("Index");
        }

        [Route("Delete/{id?}")]
        public IActionResult delete(int id)
        {
            _batchRepo.DeleteBatch(id);
            return RedirectToAction("index");
        }

        [Route("updateBatch/{id?}")]
        [HttpGet]
        public ViewResult update(int id)
        {
            Batch batch = _batchRepo.GetBatch(id);
            batchViewModel batchView = new batchViewModel()
            {
                Id = batch.Id,
                supervisor = batch.Supervisor,
                startDate = batch.StartDate,
                endDate = batch.EndDate,
                BatchName = batch.Name
            };
            return View(batchView);
        }

        [Route("updateBatch/{id?}")]
        [HttpPost]
        public IActionResult update(batchViewModel model)
        {
            Batch batch = _batchRepo.GetBatch(model.Id);
            if (ModelState.IsValid)
            {
                batch.Supervisor = model.supervisor;
                batch.StartDate = model.startDate;
                batch.EndDate = model.endDate;
                batch.Name = model.BatchName;

                _batchRepo.UpdateBatch(batch);
                return RedirectToAction("index");
            }
            return View();
        }

        [Route("studentBatchAdd")]
        [HttpGet]
        public IActionResult addStudentBatch()
        {
            List<Student> studentlist = _studentRepo.GetAllStudent().ToList();
            List<Batch> batches = _batchRepo.GetAllBatch().ToList();
            studentBatchViewModel studentBatchViewModel = new studentBatchViewModel()
            {
                studentList = studentlist,
                batchList = batches
            };
            return View(studentBatchViewModel);
        }

        [Route("studentBatchAdd")]
        [HttpPost]
        public IActionResult addStudentBatch(studentBatchViewModel model)
        {
            StudentInBatch studentInBatch = new StudentInBatch()
            {
                Student_Id = int.Parse(model.selectedStudent),
                Batch_Id = int.Parse(model.selectedBatch)
            };
            _studentBatchRepo.AddStudentInBatch(studentInBatch);
            return RedirectToAction("Index");
        }
    }
}
