using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Web.Models
{
    public class TeacherCourse
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public int CourseId { get; set; }

        public virtual ApplicationUser Teacher { get; set; }

        public virtual Course Course { get; set; }
    }
}
