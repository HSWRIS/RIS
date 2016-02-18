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
            hla_yangbenjieshou.Property(z => z.leixing).IsRequired();
            hla_yangbenjieshou.Property(z => z.bianhao).IsRequired();
            hla_yangbenjieshou.HasMany(z => z.HLA_weidians).WithRequired(z => z.HLA_yangbenjieshou);

            //HLA 位点
            var hla_weidian = shujuku.Entity<HLA_weidian>();
            hla_weidian.HasKey(z => z.id);
            hla_weidian.HasMany(z => z.HLA_bubans).WithOptional(z => z.HLA_weidian);

            //HLA 板信息
            var hla_banxinxi = shujuku.Entity<HLA_banxinxi>();
            hla_banxinxi.HasKey(z => z.id);
            hla_banxinxi.Property(z => z.banhao).IsRequired().HasMaxLength(50).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_banhao_weiyi") { IsUnique = true }));
            hla_banxinxi.Property(z => z.leixing).IsRequired();
            hla_banxinxi.Property(z => z.hangshu).IsRequired();
            hla_banxinxi.Property(z => z.lieshu).IsRequired();
            hla_banxinxi.HasMany(z => z.hangs).WithRequired(z => z.HLA_banxinxi);

            //HLA 行
            var hla_hang = shujuku.Entity<HLA_hang>();
            hla_hang.HasKey(z => z.id);
            hla_hang.Property(z => z.Lable).IsRequired();
            hla_hang.Property(z => z.lieshu).IsRequired();
            hla_hang.HasMany(z => z.HLA_bubans).WithRequired(z => z.HLA_hang);
            hla_hang.Ignore(z => z.C01);
            hla_hang.Ignore(z => z.C02);
            hla_hang.Ignore(z => z.C03);
            hla_hang.Ignore(z => z.C04);
            hla_hang.Ignore(z => z.C05);
            hla_hang.Ignore(z => z.C06);
            hla_hang.Ignore(z => z.C07);
            hla_hang.Ignore(z => z.C08);
            hla_hang.Ignore(z => z.C09);
            hla_hang.Ignore(z => z.C10);
            hla_hang.Ignore(z => z.C11);
            hla_hang.Ignore(z => z.C12);
            hla_hang.Ignore(z => z.C13);
            hla_hang.Ignore(z => z.C14);
            hla_hang.Ignore(z => z.C15);
            hla_hang.Ignore(z => z.C16);
            hla_hang.Ignore(z => z.C17);
            hla_hang.Ignore(z => z.C18);
            hla_hang.Ignore(z => z.C19);
            hla_hang.Ignore(z => z.C20);

            //HLA 布板（说明）
            var HLA_buban = shujuku.Entity<HLA_bubanshuoming>();
            HLA_buban.HasKey(z => z.id);
            HLA_buban.Property(z => z.lie).IsRequired();

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
                        if (!ls.Equals("临时编号")) throw new Exception("业务逻辑错误，编号一旦确定便不能修改！");
                    }
                }
            }

            //HLA 样本接受
            if (entityEntry.Entity is HLA_yangbenjieshou)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    if (entityEntry.Property("bianhao").IsModified)
                    {
                        var ls = entityEntry.Property("bianhao").OriginalValue as string;
                        if (!ls.Equals("临时编号")) throw new Exception("业务逻辑错误，编号一旦确定便不能修改！");
                    }
                    if (entityEntry.Property("leixing").IsModified) throw new Exception("业务逻辑错误，样本类型一旦确定便不能修改！");
                }
            }

            //HLA 板信息
            if (entityEntry.Entity is HLA_banxinxi)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    if (entityEntry.Property("hangshu").IsModified) throw new Exception("业务逻辑错误，行数一旦确定便不能修改！");
                    if (entityEntry.Property("lieshu").IsModified) throw new Exception("业务逻辑错误，列数一旦确定便不能修改！");
                }
                if (entityEntry.State == EntityState.Added)
                {
                    var dangqian = (HLA_banxinxi)entityEntry.Entity;
                    if (dangqian.hangshu < 1) throw new Exception("业务逻辑错误，对于新加的，行数必须设定！");
                    if (dangqian.hangs.Count == 0) throw new Exception("业务逻辑错误，对于新加的，行必须设定！");
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }

        public virtual DbSet<Yonghu> Yonghu { get; set; }
        public virtual DbSet<HLA_shenqingdan> HLA_shenqingdan { get; set; }
        public virtual DbSet<HLA_yangbenjieshou> HLA_yangbenjieshou { get; set; }
        public virtual DbSet<HLA_weidian> HLA_weidian { get; set; }
        public virtual DbSet<HLA_banxinxi> HLA_banxinxi { get; set; }
        public virtual DbSet<HLA_bubanshuoming> HLA_buban { get; set; }
        public virtual DbSet<HLA_hang> HLA_hang { get; set; }
        public virtual DbSet<Jichuid> Jichuid { get; set; }
    }
}