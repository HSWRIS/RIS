namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yonghus",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        zhanghao = c.String(),
                        mima = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yonghus");
        }
    }
}
