namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HLA_banxinxi",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        banhao = c.String(nullable: false, maxLength: 50),
                        riqi = c.DateTime(),
                        leixing = c.String(nullable: false),
                        hangshu = c.Int(nullable: false),
                        lieshu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.banhao, unique: true, name: "Index_banhao_weiyi");
            
            CreateTable(
                "dbo.HLA_hang",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Lable = c.String(nullable: false),
                        lieshu = c.Int(nullable: false),
                        C01_id = c.Long(),
                        C02_id = c.Long(),
                        C03_id = c.Long(),
                        C04_id = c.Long(),
                        C05_id = c.Long(),
                        C06_id = c.Long(),
                        C07_id = c.Long(),
                        C08_id = c.Long(),
                        C09_id = c.Long(),
                        C10_id = c.Long(),
                        C11_id = c.Long(),
                        C12_id = c.Long(),
                        C13_id = c.Long(),
                        C14_id = c.Long(),
                        C15_id = c.Long(),
                        C16_id = c.Long(),
                        C17_id = c.Long(),
                        C18_id = c.Long(),
                        C19_id = c.Long(),
                        C20_id = c.Long(),
                        HLA_banxinxi_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HLA_weidian", t => t.C01_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C02_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C03_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C04_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C05_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C06_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C07_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C08_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C09_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C10_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C11_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C12_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C13_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C14_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C15_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C16_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C17_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C18_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C19_id)
                .ForeignKey("dbo.HLA_weidian", t => t.C20_id)
                .ForeignKey("dbo.HLA_banxinxi", t => t.HLA_banxinxi_id, cascadeDelete: true)
                .Index(t => t.C01_id)
                .Index(t => t.C02_id)
                .Index(t => t.C03_id)
                .Index(t => t.C04_id)
                .Index(t => t.C05_id)
                .Index(t => t.C06_id)
                .Index(t => t.C07_id)
                .Index(t => t.C08_id)
                .Index(t => t.C09_id)
                .Index(t => t.C10_id)
                .Index(t => t.C11_id)
                .Index(t => t.C12_id)
                .Index(t => t.C13_id)
                .Index(t => t.C14_id)
                .Index(t => t.C15_id)
                .Index(t => t.C16_id)
                .Index(t => t.C17_id)
                .Index(t => t.C18_id)
                .Index(t => t.C19_id)
                .Index(t => t.C20_id)
                .Index(t => t.HLA_banxinxi_id);
            
            CreateTable(
                "dbo.HLA_weidian",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        fenzu = c.String(),
                        leixing = c.String(),
                        weidian = c.String(),
                        HLA_yangbenjieshou_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HLA_yangbenjieshou", t => t.HLA_yangbenjieshou_id, cascadeDelete: true)
                .Index(t => t.HLA_yangbenjieshou_id);
            
            CreateTable(
                "dbo.HLA_yangbenjieshou",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        xingming = c.String(nullable: false),
                        xingbie = c.String(),
                        HLA_shenqingdan_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HLA_shenqingdan", t => t.HLA_shenqingdan_id, cascadeDelete: true)
                .Index(t => t.HLA_shenqingdan_id);
            
            CreateTable(
                "dbo.HLA_shenqingdan",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        bianhao = c.String(nullable: false, maxLength: 50),
                        xingming = c.String(nullable: false),
                        xingbie = c.String(),
                        chushengriqi = c.DateTime(),
                        shenfenzhenghao = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.bianhao, unique: true, name: "Index_bianhao_weiyi");
            
            CreateTable(
                "dbo.Jichuids",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        biao = c.String(nullable: false, maxLength: 100),
                        lie = c.String(nullable: false, maxLength: 50),
                        fenzu = c.String(nullable: false, maxLength: 50),
                        gengxinpinlv = c.String(nullable: false),
                        gengxinshijian = c.DateTime(nullable: false),
                        jichuid = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => new { t.biao, t.lie, t.fenzu }, unique: true, name: "Index_biao_lie_fenzu_weiyi");
            
            CreateTable(
                "dbo.Yonghus",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        zhanghao = c.String(nullable: false, maxLength: 50),
                        mima = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.zhanghao, unique: true, name: "Index_zhanghao_weiyi");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HLA_hang", "HLA_banxinxi_id", "dbo.HLA_banxinxi");
            DropForeignKey("dbo.HLA_hang", "C20_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C19_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C18_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C17_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C16_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C15_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C14_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C13_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C12_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C11_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C10_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C09_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C08_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C07_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C06_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C05_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C04_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C03_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C02_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_hang", "C01_id", "dbo.HLA_weidian");
            DropForeignKey("dbo.HLA_weidian", "HLA_yangbenjieshou_id", "dbo.HLA_yangbenjieshou");
            DropForeignKey("dbo.HLA_yangbenjieshou", "HLA_shenqingdan_id", "dbo.HLA_shenqingdan");
            DropIndex("dbo.Yonghus", "Index_zhanghao_weiyi");
            DropIndex("dbo.Jichuids", "Index_biao_lie_fenzu_weiyi");
            DropIndex("dbo.HLA_shenqingdan", "Index_bianhao_weiyi");
            DropIndex("dbo.HLA_yangbenjieshou", new[] { "HLA_shenqingdan_id" });
            DropIndex("dbo.HLA_weidian", new[] { "HLA_yangbenjieshou_id" });
            DropIndex("dbo.HLA_hang", new[] { "HLA_banxinxi_id" });
            DropIndex("dbo.HLA_hang", new[] { "C20_id" });
            DropIndex("dbo.HLA_hang", new[] { "C19_id" });
            DropIndex("dbo.HLA_hang", new[] { "C18_id" });
            DropIndex("dbo.HLA_hang", new[] { "C17_id" });
            DropIndex("dbo.HLA_hang", new[] { "C16_id" });
            DropIndex("dbo.HLA_hang", new[] { "C15_id" });
            DropIndex("dbo.HLA_hang", new[] { "C14_id" });
            DropIndex("dbo.HLA_hang", new[] { "C13_id" });
            DropIndex("dbo.HLA_hang", new[] { "C12_id" });
            DropIndex("dbo.HLA_hang", new[] { "C11_id" });
            DropIndex("dbo.HLA_hang", new[] { "C10_id" });
            DropIndex("dbo.HLA_hang", new[] { "C09_id" });
            DropIndex("dbo.HLA_hang", new[] { "C08_id" });
            DropIndex("dbo.HLA_hang", new[] { "C07_id" });
            DropIndex("dbo.HLA_hang", new[] { "C06_id" });
            DropIndex("dbo.HLA_hang", new[] { "C05_id" });
            DropIndex("dbo.HLA_hang", new[] { "C04_id" });
            DropIndex("dbo.HLA_hang", new[] { "C03_id" });
            DropIndex("dbo.HLA_hang", new[] { "C02_id" });
            DropIndex("dbo.HLA_hang", new[] { "C01_id" });
            DropIndex("dbo.HLA_banxinxi", "Index_banhao_weiyi");
            DropTable("dbo.Yonghus");
            DropTable("dbo.Jichuids");
            DropTable("dbo.HLA_shenqingdan");
            DropTable("dbo.HLA_yangbenjieshou");
            DropTable("dbo.HLA_weidian");
            DropTable("dbo.HLA_hang");
            DropTable("dbo.HLA_banxinxi");
        }
    }
}
