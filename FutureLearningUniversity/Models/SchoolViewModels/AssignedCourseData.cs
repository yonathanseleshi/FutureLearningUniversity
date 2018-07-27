using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureLearningUniversity.Models.SchoolViewModels
{
    public class AssignedCourseData
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
