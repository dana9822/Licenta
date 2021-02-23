namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SessionYears",
                c => new
                    {
                        IdSesiune = c.Int(nullable: false),
                        AnUniversitar = c.Int(nullable: false),
                        DataInceput = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdSesiune, t.AnUniversitar })
                .ForeignKey("dbo.AcademicYears", t => t.AnUniversitar, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.IdSesiune, cascadeDelete: true)
                .Index(t => t.IdSesiune)
                .Index(t => t.AnUniversitar);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        IdSesiune = c.Int(nullable: false, identity: true),
                        DenumireSesiune = c.String(),
                    })
                .PrimaryKey(t => t.IdSesiune);
            
            CreateTable(
                "dbo.SubjectCoverages",
                c => new
                    {
                        IdSpecializare = c.Int(nullable: false),
                        IdDisciplina = c.Int(nullable: false),
                        MarcaProf = c.Int(nullable: false),
                        AnStudiu = c.Int(nullable: false),
                        AnUniversitar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdSpecializare, t.IdDisciplina, t.MarcaProf, t.AnStudiu, t.AnUniversitar })
                .ForeignKey("dbo.AcademicYears", t => t.AnUniversitar, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.MarcaProf, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.IdSpecializare, cascadeDelete: true)
                .ForeignKey("dbo.StudyYears", t => t.AnStudiu, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.IdDisciplina, cascadeDelete: true)
                .Index(t => t.IdSpecializare)
                .Index(t => t.IdDisciplina)
                .Index(t => t.MarcaProf)
                .Index(t => t.AnStudiu)
                .Index(t => t.AnUniversitar);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        MarcaProf = c.Int(nullable: false, identity: true),
                        Nume = c.String(nullable: false),
                        Prenume = c.String(nullable: false),
                        GradDidactic = c.String(),
                    })
                .PrimaryKey(t => t.MarcaProf);
            
            CreateTable(
                "dbo.SubjectAllocations",
                c => new
                    {
                        IdSpecializare = c.Int(nullable: false),
                        AnStudiu = c.Int(nullable: false),
                        IdDisciplina = c.Int(nullable: false),
                        Semestru = c.String(),
                        TipEvaluare = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => new { t.IdSpecializare, t.AnStudiu, t.IdDisciplina })
                .ForeignKey("dbo.Specializations", t => t.IdSpecializare, cascadeDelete: true)
                .ForeignKey("dbo.StudyYears", t => t.AnStudiu, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.IdDisciplina, cascadeDelete: true)
                .Index(t => t.IdSpecializare)
                .Index(t => t.AnStudiu)
                .Index(t => t.IdDisciplina);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        IdDisciplina = c.Int(nullable: false, identity: true),
                        DenumireDisciplina = c.String(),
                    })
                .PrimaryKey(t => t.IdDisciplina);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectCoverages", "IdDisciplina", "dbo.Subjects");
            DropForeignKey("dbo.SubjectCoverages", "AnStudiu", "dbo.StudyYears");
            DropForeignKey("dbo.SubjectAllocations", "IdDisciplina", "dbo.Subjects");
            DropForeignKey("dbo.SubjectAllocations", "AnStudiu", "dbo.StudyYears");
            DropForeignKey("dbo.SubjectAllocations", "IdSpecializare", "dbo.Specializations");
            DropForeignKey("dbo.SubjectCoverages", "IdSpecializare", "dbo.Specializations");
            DropForeignKey("dbo.SubjectCoverages", "MarcaProf", "dbo.Professors");
            DropForeignKey("dbo.SubjectCoverages", "AnUniversitar", "dbo.AcademicYears");
            DropForeignKey("dbo.SessionYears", "IdSesiune", "dbo.Sessions");
            DropForeignKey("dbo.SessionYears", "AnUniversitar", "dbo.AcademicYears");
            DropIndex("dbo.SubjectAllocations", new[] { "IdDisciplina" });
            DropIndex("dbo.SubjectAllocations", new[] { "AnStudiu" });
            DropIndex("dbo.SubjectAllocations", new[] { "IdSpecializare" });
            DropIndex("dbo.SubjectCoverages", new[] { "AnUniversitar" });
            DropIndex("dbo.SubjectCoverages", new[] { "AnStudiu" });
            DropIndex("dbo.SubjectCoverages", new[] { "MarcaProf" });
            DropIndex("dbo.SubjectCoverages", new[] { "IdDisciplina" });
            DropIndex("dbo.SubjectCoverages", new[] { "IdSpecializare" });
            DropIndex("dbo.SessionYears", new[] { "AnUniversitar" });
            DropIndex("dbo.SessionYears", new[] { "IdSesiune" });
            DropTable("dbo.Subjects");
            DropTable("dbo.SubjectAllocations");
            DropTable("dbo.Professors");
            DropTable("dbo.SubjectCoverages");
            DropTable("dbo.Sessions");
            DropTable("dbo.SessionYears");
        }
    }
}
