namespace MyBookKeeping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SystemUserSystemRoles", "SystemRole_UserId", "dbo.SystemRoles");
            RenameColumn(table: "dbo.SystemUserSystemRoles", name: "SystemRole_UserId", newName: "SystemRole_RoleId");
            RenameIndex(table: "dbo.SystemUserSystemRoles", name: "IX_SystemRole_UserId", newName: "IX_SystemRole_RoleId");
            DropPrimaryKey("dbo.SystemRoles");
            AddColumn("dbo.SystemRoles", "RoleId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.SystemRoles", "RoleId");
            AddForeignKey("dbo.SystemUserSystemRoles", "SystemRole_RoleId", "dbo.SystemRoles", "RoleId", cascadeDelete: true);
            DropColumn("dbo.SystemRoles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SystemRoles", "UserId", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("dbo.SystemUserSystemRoles", "SystemRole_RoleId", "dbo.SystemRoles");
            DropPrimaryKey("dbo.SystemRoles");
            DropColumn("dbo.SystemRoles", "RoleId");
            AddPrimaryKey("dbo.SystemRoles", "UserId");
            RenameIndex(table: "dbo.SystemUserSystemRoles", name: "IX_SystemRole_RoleId", newName: "IX_SystemRole_UserId");
            RenameColumn(table: "dbo.SystemUserSystemRoles", name: "SystemRole_RoleId", newName: "SystemRole_UserId");
            AddForeignKey("dbo.SystemUserSystemRoles", "SystemRole_UserId", "dbo.SystemRoles", "UserId", cascadeDelete: true);
        }
    }
}
