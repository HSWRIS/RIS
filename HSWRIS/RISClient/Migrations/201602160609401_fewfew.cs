namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HLA_banxinxi",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        banhao = c.String(nullable: false),
                        riqi = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HLA_banxinxi");
        }
    }
}
