namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gregre : DbMigration
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
                        HLA_banxinxi_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HLA_banxinxi", t => t.HLA_banxinxi_id, cascadeDelete: true)
                .Index(t => t.HLA_banxinxi_id);
            
            CreateTable(
                "dbo.HLA_buban",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        lie = c.Int(nullable: false),
                        HLA_weidian_id = c.Long(nullable: false),
                        HLA_hang_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HLA_weidian", t => t.HLA_weidian_id, cascadeDelete: true)
                .ForeignKey("dbo.HLA_hang", t => t.HLA_hang_id, cascadeDelete: true)
                .Index(t => t.HLA_weidian_id)
                .Index(t => t.HLA_hang_id);
            
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
            DropForeignKey("dbo.HLA_buban", "HLA_hang_id", "dbo.HLA_hang");
            DropForeignKey("dbo.HLA_weidian", "HLA_yangbenjieshou_id", "dbo.HLA_yangbenjieshou");
            DropForeignKey("dbo.HLA_yangbenjieshou", "HLA_shenqingdan_id", "dbo.HLA_shenqingdan");
            DropForeignKey("dbo.HLA_buban", "HLA_weidian_id", "dbo.HLA_weidian");
            DropIndex("dbo.Yonghus", "Index_zhanghao_weiyi");
            DropIndex("dbo.Jichuids", "Index_biao_lie_fenzu_weiyi");
            DropIndex("dbo.HLA_shenqingdan", "Index_bianhao_weiyi");
            DropIndex("dbo.HLA_yangbenjieshou", new[] { "HLA_shenqingdan_id" });
            DropIndex("dbo.HLA_weidian", new[] { "HLA_yangbenjieshou_id" });
            DropIndex("dbo.HLA_buban", new[] { "HLA_hang_id" });
            DropIndex("dbo.HLA_buban", new[] { "HLA_weidian_id" });
            DropIndex("dbo.HLA_hang", new[] { "HLA_banxinxi_id" });
            DropIndex("dbo.HLA_banxinxi", "Index_banhao_weiyi");
            DropTable("dbo.Yonghus");
            DropTable("dbo.Jichuids");
            DropTable("dbo.HLA_shenqingdan");
            DropTable("dbo.HLA_yangbenjieshou");
            DropTable("dbo.HLA_weidian");
            DropTable("dbo.HLA_buban");
            DropTable("dbo.HLA_hang");
            DropTable("dbo.HLA_banxinxi");
        }
    }
}
