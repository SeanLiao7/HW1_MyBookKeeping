namespace MyBookKeeping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        CreateBy = c.Guid(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 50),
                        CreateBy = c.Guid(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 200),
                        IsEnable = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        UpdateBy = c.Guid(),
                        UpdateOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.SystemUserSystemRoles",
                c => new
                    {
                        SystemUser_UserId = c.Guid(nullable: false),
                        SystemRole_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SystemUser_UserId, t.SystemRole_UserId })
                .ForeignKey("dbo.SystemUsers", t => t.SystemUser_UserId, cascadeDelete: true)
                .ForeignKey("dbo.SystemRoles", t => t.SystemRole_UserId, cascadeDelete: true)
                .Index(t => t.SystemUser_UserId)
                .Index(t => t.SystemRole_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemUserSystemRoles", "SystemRole_UserId", "dbo.SystemRoles");
            DropForeignKey("dbo.SystemUserSystemRoles", "SystemUser_UserId", "dbo.SystemUsers");
            DropIndex("dbo.SystemUserSystemRoles", new[] { "SystemRole_UserId" });
            DropIndex("dbo.SystemUserSystemRoles", new[] { "SystemUser_UserId" });
            DropTable("dbo.SystemUserSystemRoles");
            DropTable("dbo.SystemUsers");
            DropTable("dbo.SystemRoles");
        }
    }
}
