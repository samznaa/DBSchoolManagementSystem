using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodieFusion.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public int ContactNo { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }

        public string PostCode { get; set; }
        public string PassWord { get; set; }
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public List<Users> UserList { get; set; }

    }
}