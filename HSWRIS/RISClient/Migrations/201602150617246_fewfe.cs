namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HLA_weidian",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        fenzu = c.String(),
                        leixing = c.String(),
                        weidian = c.String(),
                        beizhu = c.String(),
                        HLA_yangbenjieshou_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HLA_yangbenjieshou", t => t.HLA_yangbenjieshou_id, cascadeDelete: true)
                .Index(t => t.HLA_yangbenjieshou_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HLA_weidian", "HLA_yangbenjieshou_id", "dbo.HLA_yangbenjieshou");
            DropIndex("dbo.HLA_weidian", new[] { "HLA_yangbenjieshou_id" });
            DropTable("dbo.HLA_weidian");
        }
    }
}
