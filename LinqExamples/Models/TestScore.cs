using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.Models
{
    internal class TestScore
    {
        public int StudentId { get; internal set; }
        public string Subject { get; internal set; }
        public int Marks { get; internal set; }
    }
}
