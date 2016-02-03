namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RISClient.Shujuku.Shujuku>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RISClient.Shujuku.Shujuku shujuku)
        {
            var kaifarenyuan = new Shujuku.Yonghu { zhanghao="kaifarenyuan",mima="kaifarenyuan"};
            if (shujuku.Yonghu.Where(y=>y.zhanghao.Equals(kaifarenyuan.zhanghao)).Count()==0)
            {
                shujuku.Yonghu.Add(kaifarenyuan);
            }
            shujuku.SaveChanges();
        }
    }
}
