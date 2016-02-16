namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HLA_hang",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        hangqian = c.String(nullable: false),
                        HLA_banxinxi_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HLA_banxinxi", t => t.HLA_banxinxi_id)
                .Index(t => t.HLA_banxinxi_id);
            
            AddColumn("dbo.HLA_banxinxi", "hangshu", c => c.Int(nullable: false));
            AddColumn("dbo.HLA_banxinxi", "lieshu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HLA_hang", "HLA_banxinxi_id", "dbo.HLA_banxinxi");
            DropIndex("dbo.HLA_hang", new[] { "HLA_banxinxi_id" });
            DropColumn("dbo.HLA_banxinxi", "lieshu");
            DropColumn("dbo.HLA_banxinxi", "hangshu");
            DropTable("dbo.HLA_hang");
        }
    }
}
