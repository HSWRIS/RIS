namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fw : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Yonghus", "zhanghao", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Yonghus", "mima", c => c.String(nullable: false));
            CreateIndex("dbo.Yonghus", "zhanghao", unique: true, name: "Index_zhanghao_weiyi");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Yonghus", "Index_zhanghao_weiyi");
            AlterColumn("dbo.Yonghus", "mima", c => c.String());
            AlterColumn("dbo.Yonghus", "zhanghao", c => c.String());
        }
    }
}
