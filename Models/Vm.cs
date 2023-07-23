using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBSchoolManagementSystem.Services
{

    public class Vm
    {
        [Key]
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }




        [NotMapped]
        public List<Vm> VmList { get; set; }

    }
}