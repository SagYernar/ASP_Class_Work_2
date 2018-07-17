using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FIO { get; set; }
        public string Description { get; set; }
    }
}