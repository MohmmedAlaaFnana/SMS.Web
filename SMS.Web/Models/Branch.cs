using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Web.Models
{
    public class Branch
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<Course> Courses { get; set; }
    }
}
