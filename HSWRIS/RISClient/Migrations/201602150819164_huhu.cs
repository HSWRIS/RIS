namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class huhu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HLA_weidian", "beizhu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HLA_weidian", "beizhu", c => c.String());
        }
    }
}
