using NguyenDuyNam_lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenDuyNam_lab456.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Courses> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}