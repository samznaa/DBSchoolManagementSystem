using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class HomePageCount
    {
       
        public int Id { get; set; }  
        public int InstructorCount { get; set; }
        public int StudentCount { get; set; }
        public int CourseCount { get; set; }
        public int DepartmentCount { get; set; }
        //public string InstructorUrl { get; set; }
        //public string StudentUrl { get; set; }
    }
}


