namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfew2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HLA_hang", "HLA_banxinxi_id", "dbo.HLA_banxinxi");
            DropIndex("dbo.HLA_hang", new[] { "HLA_banxinxi_id" });
            AlterColumn("dbo.HLA_hang", "HLA_banxinxi_id", c => c.Long(nullable: false));
            CreateIndex("dbo.HLA_hang", "HLA_banxinxi_id");
            AddForeignKey("dbo.HLA_hang", "HLA_banxinxi_id", "dbo.HLA_banxinxi", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HLA_hang", "HLA_banxinxi_id", "dbo.HLA_banxinxi");
            DropIndex("dbo.HLA_hang", new[] { "HLA_banxinxi_id" });
            AlterColumn("dbo.HLA_hang", "HLA_banxinxi_id", c => c.Long());
            CreateIndex("dbo.HLA_hang", "HLA_banxinxi_id");
            AddForeignKey("dbo.HLA_hang", "HLA_banxinxi_id", "dbo.HLA_banxinxi", "id");
        }
    }
}
