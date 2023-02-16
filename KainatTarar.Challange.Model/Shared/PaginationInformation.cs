using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainatTarar.Challange.Model.Shared
{
    public class PaginationInformation
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalCount { get; set; }
    }
}
