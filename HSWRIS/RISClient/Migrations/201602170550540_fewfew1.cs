namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfew1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HLA_buban", newName: "HLA_bubanshuoming");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.HLA_bubanshuoming", newName: "HLA_buban");
        }
    }
}
