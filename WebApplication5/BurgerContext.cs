namespace WebApplication5
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApplication5.Models;

    public class BurgerContext : DbContext
    {
        public BurgerContext()
            : base("name=BurgerContext")
        {
        }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<DishesType> DishesTypes { get; set; }
    }

}