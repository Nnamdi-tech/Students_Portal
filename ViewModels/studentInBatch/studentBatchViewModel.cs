using Code360_Management.Models.Students;
using Code360_Management.Models.Batchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Code360_Management.ViewModels.studentInBatch
{
    public class studentBatchViewModel
    {
        public string selectedBatch { get; set; }
        public List<Code360_Management.Models.Batchs.Batch> batchList { get; set; }
        public string selectedStudent { get; set; }
        public List<Student> studentList { get; set; }
    }
}
