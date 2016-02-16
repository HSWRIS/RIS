namespace RISClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfew1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HLA_banxinxi", "banhao", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.HLA_banxinxi", "banhao", unique: true, name: "Index_banhao_weiyi");
        }
        
        public override void Down()
        {
            DropIndex("dbo.HLA_banxinxi", "Index_banhao_weiyi");
            AlterColumn("dbo.HLA_banxinxi", "banhao", c => c.String(nullable: false));
        }
    }
}
