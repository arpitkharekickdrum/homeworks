using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.ViewModels
{
    internal class PaginatedDataViewModel<TModel>
    {
        public int TotalRows { get; set; } //total studens

        public IEnumerable<TModel> Rows { get; set; } //return 15 students
    }
}
