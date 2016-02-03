namespace RISClient.Shujuku
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Shujuku : DbContext
    {
        public Shujuku()
            : base("name=Shujuku")
        {
        }

      

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

  
}