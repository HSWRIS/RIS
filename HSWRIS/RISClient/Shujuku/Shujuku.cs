namespace RISClient.Shujuku
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Shujuku : DbContext
    {
        public Shujuku()
            : base("name=Shujuku")
        {
        }

        protected override void OnModelCreating(DbModelBuilder shujuku)
        {
            base.OnModelCreating(shujuku);
            //用户
            var yonghu = shujuku.Entity<Yonghu>();
            yonghu.HasKey(z => z.id);
            yonghu.Property(y => y.zhanghao).IsRequired().HasMaxLength(50).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_zhanghao_weiyi") { IsUnique = true }));
            yonghu.Property(y => y.mima).IsRequired();
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }

        public virtual DbSet<Yonghu> Yonghu { get; set; }
    }


}