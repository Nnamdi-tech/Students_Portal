using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.ViewModels.Batch
{
    public class batchViewModel
    {
        public int Id { get; set; }
        public batchName BatchName { get; set; }
        public int programId { get; set; }
        public string supervisor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public title Title { get; set; }

    }

    public enum title
    {
        Mr,
        Mrs,
        Miss,
        Barr,
        Dr,
        Prof,
        Engr,
        Master,
    }
}
