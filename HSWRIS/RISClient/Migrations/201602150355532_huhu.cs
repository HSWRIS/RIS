namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class huhu : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HLA_yangbenjieshou", "HLA_shenqingdan_id", "dbo.HLA_shenqingdan");
            DropIndex("dbo.HLA_yangbenjieshou", new[] { "HLA_shenqingdan_id" });
            DropTable("dbo.HLA_yangbenjieshou");
        }
    }
}
