namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HLA_shenqingdan",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        bianhao = c.String(nullable: false, maxLength: 50),
                        xingming = c.String(),
                        xingbie = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jichuids", "Index_biao_lie_fenzu_weiyi");
            DropIndex("dbo.HLA_shenqingdan", "Index_bianhao_weiyi");
            DropTable("dbo.Jichuids");
            DropTable("dbo.HLA_shenqingdan");
        }
    }
}
