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

            //HLA 申请单
            var hla_shengqingdan = shujuku.Entity<HLA_shenqingdan>();
            hla_shengqingdan.HasKey(z => z.id);
            hla_shengqingdan.Property(z => z.xingming).IsRequired();
            hla_shengqingdan.Property(z => z.bianhao).IsRequired().HasMaxLength(50).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_bianhao_weiyi") { IsUnique = true }));
            hla_shengqingdan.HasMany(z => z.HLA_yangbenjieshous).WithRequired(z => z.HLA_shenqingdan);

            //HLA 样本接受
            var hla_yangbenjieshou = shujuku.Entity<HLA_yangbenjieshou>();
            hla_yangbenjieshou.HasKey(z => z.id);
            hla_yangbenjieshou.Property(z => z.xingming).IsRequired();
            hla_yangbenjieshou.HasMany(z => z.HLA_weidians).WithRequired(z=>z.HLA_yangbenjieshou);

            //HLA 位点
            var hla_weidian = shujuku.Entity<HLA_weidian>();
            hla_weidian.HasKey(z => z.id);

            //基础ID
            var jichuid = shujuku.Entity<Jichuid>();
            jichuid.HasKey(z => z.id);
            jichuid.Property(j => j.biao).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_biao_lie_fenzu_weiyi", 1) { IsUnique = true }));
            jichuid.Property(j => j.lie).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_biao_lie_fenzu_weiyi", 2) { IsUnique = true }));
            jichuid.Property(j => j.fenzu).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_biao_lie_fenzu_weiyi", 3) { IsUnique = true }));
            jichuid.Property(z => z.gengxinpinlv).IsRequired();
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            //HLA 申请单
            if (entityEntry.Entity is HLA_shenqingdan)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    if (entityEntry.Property("bianhao").IsModified)
                    {
                        var ls = entityEntry.Property("bianhao").OriginalValue as string;
                        if (!ls.Equals("临时编号"))
                        {
                            throw new Exception("业务逻辑错误，编号一旦确定便不能修改！");
                        }
                    }
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }

        public virtual DbSet<Yonghu> Yonghu { get; set; }
        public virtual DbSet<HLA_shenqingdan> HLA_shenqingdan { get; set; }
        public virtual DbSet<HLA_yangbenjieshou> HLA_yangbenjieshou { get; set; }
        public virtual DbSet<HLA_weidian> HLA_weidian { get; set; }
        public virtual DbSet<Jichuid> Jichuid { get; set; }
    }
}