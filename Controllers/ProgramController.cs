using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models.Programs;
using Code360_Management.ViewModels.ProgramCourse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Code360_Management.Controllers
{
    [Route("Program")]
    public class ProgramController : Controller
    {
        private readonly IProgram _programRepo;

        public ProgramController(IProgram programRepo)
        {
            _programRepo = programRepo;
        }

        [Route("AddProgram")]
        [HttpGet]
        public ViewResult AddProgram()
        {
            return View();
        }

        [Route("AddProgram/{id?}")]
        [HttpPost]
        public IActionResult AddProgram(ProgramViewModel model)
        {
            if (ModelState.IsValid)
            {
                Programme programme = new Programme()
                {
                    Program_Name = model.ProgramName,
                    BatchName = model.batch,
                    Cost = model.cost,
                    Course_Id = model.courseID
                };
                _programRepo.AddProgramme(programme);
                return RedirectToAction("dashboard", "Home");
            }
            return View();
        }
    }
}
