namespace App.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGroupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nature = c.String(),
                        Name = c.String(),
                        Code = c.String(),
                        ParentGroupId = c.Int(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.ParentGroupId)
                .Index(t => t.ParentGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "ParentGroupId", "dbo.Groups");
            DropIndex("dbo.Groups", new[] { "ParentGroupId" });
            DropTable("dbo.Groups");
        }
    }
}
