namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gewgew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HLA_yangbenjieshou", "leixing", c => c.String(nullable: false));
            AddColumn("dbo.HLA_yangbenjieshou", "bianhao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HLA_yangbenjieshou", "bianhao");
            DropColumn("dbo.HLA_yangbenjieshou", "leixing");
        }
    }
}
