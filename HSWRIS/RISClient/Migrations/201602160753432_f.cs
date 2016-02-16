namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HLA_banxinxi", "leixing", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HLA_banxinxi", "leixing");
        }
    }
}
