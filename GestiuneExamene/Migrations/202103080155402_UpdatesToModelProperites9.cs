namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUniv" }, "dbo.Groups");
            DropForeignKey("dbo.Exams", new[] { "IdGrupa", "IdSpecializare", "AnStudiu", "AnUniversitar" }, "dbo.Groups");
            DropPrimaryKey("dbo.Groups");
            AlterColumn("dbo.Groups", "IdGrupa", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Groups", new[] { "IdGrupa", "IdSpecializare", "AnStudiuId", "AnUniversitarId" });
            AddForeignKey("dbo.Students", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUniv" }, "dbo.Groups", new[] { "IdGrupa", "IdSpecializare", "AnStudiuId", "AnUniversitarId" }, cascadeDelete: true);
            AddForeignKey("dbo.Exams", new[] { "IdGrupa", "IdSpecializare", "AnStudiu", "AnUniversitar" }, "dbo.Groups", new[] { "IdGrupa", "IdSpecializare", "AnStudiuId", "AnUniversitarId" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", new[] { "IdGrupa", "IdSpecializare", "AnStudiu", "AnUniversitar" }, "dbo.Groups");
            DropForeignKey("dbo.Students", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUniv" }, "dbo.Groups");
            DropPrimaryKey("dbo.Groups");
            AlterColumn("dbo.Groups", "IdGrupa", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Groups", new[] { "IdGrupa", "IdSpecializare", "AnStudiuId", "AnUniversitarId" });
            AddForeignKey("dbo.Exams", new[] { "IdGrupa", "IdSpecializare", "AnStudiu", "AnUniversitar" }, "dbo.Groups", new[] { "IdGrupa", "IdSpecializare", "AnStudiuId", "AnUniversitarId" }, cascadeDelete: true);
            AddForeignKey("dbo.Students", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUniv" }, "dbo.Groups", new[] { "IdGrupa", "IdSpecializare", "AnStudiuId", "AnUniversitarId" }, cascadeDelete: true);
        }
    }
}
