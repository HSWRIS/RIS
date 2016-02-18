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

            var hla_shenqingdan_bianhao_jichuid = new Shujuku.Jichuid { fenzu="",biao = "HLA_shenqingdan", lie = "bianhao", gengxinpinlv = "Äê", gengxinshijian = DateTime.Now, jichuid = 0 };
            if (shujuku.Jichuid.Where(z=>z.biao.Equals(hla_shenqingdan_bianhao_jichuid.biao)&&z.lie.Equals(hla_shenqingdan_bianhao_jichuid.lie)&&z.fenzu.Equals(hla_shenqingdan_bianhao_jichuid.fenzu)).Count()==0)
            {
                shujuku.Jichuid.Add(hla_shenqingdan_bianhao_jichuid);
            }

            var hla_yangbenjieshou_bianhao_jichuid_SZ = new Shujuku.Jichuid { fenzu = "SZ", biao = "HLA_yangbenjieshou", lie = "bianhao", gengxinpinlv = "Äê", gengxinshijian = DateTime.Now, jichuid = 0 };
            if (shujuku.Jichuid.Where(z => z.biao.Equals(hla_yangbenjieshou_bianhao_jichuid_SZ.biao) && z.lie.Equals(hla_yangbenjieshou_bianhao_jichuid_SZ.lie) && z.fenzu.Equals(hla_yangbenjieshou_bianhao_jichuid_SZ.fenzu)).Count() == 0)
            {
                shujuku.Jichuid.Add(hla_yangbenjieshou_bianhao_jichuid_SZ);
            }

            var hla_yangbenjieshou_bianhao_jichuid_FY = new Shujuku.Jichuid { fenzu = "FY", biao = "HLA_yangbenjieshou", lie = "bianhao", gengxinpinlv = "Äê", gengxinshijian = DateTime.Now, jichuid = 0 };
            if (shujuku.Jichuid.Where(z => z.biao.Equals(hla_yangbenjieshou_bianhao_jichuid_FY.biao) && z.lie.Equals(hla_yangbenjieshou_bianhao_jichuid_FY.lie) && z.fenzu.Equals(hla_yangbenjieshou_bianhao_jichuid_FY.fenzu)).Count() == 0)
            {
                shujuku.Jichuid.Add(hla_yangbenjieshou_bianhao_jichuid_FY);
            }

            shujuku.SaveChanges();
        }
    }
}
