using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.ViewModels
{
    internal class ScoreViewModel
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string SubjectName { get; set; }

        public int Marks { get; set; }
    }
}
