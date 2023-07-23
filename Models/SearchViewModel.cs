using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class SearchViewModel
    {
        public string SearchQuery { get; set; }
        public List<Student> Students { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}