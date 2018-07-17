using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class DishesType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Dishes> Dishes { get; set; }
    }
}