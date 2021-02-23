namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        IdGrupa = c.Int(nullable: false),
                        IdSpecializare = c.Int(nullable: false),
                        AnStudiuId = c.Int(nullable: false),
                        AnUniversitarId = c.Int(nullable: false),
                        nrGrupa = c.Int(nullable: false),
                        NrStudenti = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdGrupa, t.IdSpecializare, t.AnStudiuId, t.AnUniversitarId })
                .ForeignKey("dbo.AcademicYears", t => t.AnUniversitarId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.IdSpecializare, cascadeDelete: true)
                .ForeignKey("dbo.StudyYears", t => t.AnStudiuId, cascadeDelete: true)
                .Index(t => t.IdSpecializare)
                .Index(t => t.AnStudiuId)
                .Index(t => t.AnUniversitarId);
            
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        AcademicYearId = c.Int(nullable: false, identity: true),
                        AnUniversitar = c.String(),
                    })
                .PrimaryKey(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.StudyYears",
                c => new
                    {
                        StudyYearId = c.Int(nullable: false, identity: true),
                        AnStudiu = c.String(),
                    })
                .PrimaryKey(t => t.StudyYearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "AnStudiuId", "dbo.StudyYears");
            DropForeignKey("dbo.Groups", "IdSpecializare", "dbo.Specializations");
            DropForeignKey("dbo.Groups", "AnUniversitarId", "dbo.AcademicYears");
            DropIndex("dbo.Groups", new[] { "AnUniversitarId" });
            DropIndex("dbo.Groups", new[] { "AnStudiuId" });
            DropIndex("dbo.Groups", new[] { "IdSpecializare" });
            DropTable("dbo.StudyYears");
            DropTable("dbo.AcademicYears");
            DropTable("dbo.Groups");
        }
    }
}
