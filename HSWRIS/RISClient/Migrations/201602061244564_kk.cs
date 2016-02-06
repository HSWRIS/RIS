namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HLA_shenqingdan", "xingming", c => c.String(nullable: false));
            AlterColumn("dbo.HLA_shenqingdan", "xingbie", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HLA_shenqingdan", "xingbie", c => c.String(nullable: false));
            AlterColumn("dbo.HLA_shenqingdan", "xingming", c => c.String());
        }
    }
}
