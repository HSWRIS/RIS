namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class few : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HLA_buban", "HLA_weidian_id", "dbo.HLA_weidian");
            DropIndex("dbo.HLA_buban", new[] { "HLA_weidian_id" });
            AlterColumn("dbo.HLA_buban", "HLA_weidian_id", c => c.Long());
            CreateIndex("dbo.HLA_buban", "HLA_weidian_id");
            AddForeignKey("dbo.HLA_buban", "HLA_weidian_id", "dbo.HLA_weidian", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HLA_buban", "HLA_weidian_id", "dbo.HLA_weidian");
            DropIndex("dbo.HLA_buban", new[] { "HLA_weidian_id" });
            AlterColumn("dbo.HLA_buban", "HLA_weidian_id", c => c.Long(nullable: false));
            CreateIndex("dbo.HLA_buban", "HLA_weidian_id");
            AddForeignKey("dbo.HLA_buban", "HLA_weidian_id", "dbo.HLA_weidian", "id", cascadeDelete: true);
        }
    }
}
