namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MakeupExamRequests",
                c => new
                    {
                        IdGrupa = c.Int(nullable: false),
                        IdSpec = c.Int(nullable: false),
                        AnStudiu = c.Int(nullable: false),
                        AnUnivStudent = c.Int(nullable: false),
                        Matricola = c.Int(nullable: false),
                        IdSesiune = c.Int(nullable: false),
                        IdDisc = c.Int(nullable: false),
                        AnUnivCurent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdGrupa, t.IdSpec, t.AnStudiu, t.AnUnivStudent, t.Matricola, t.IdSesiune, t.IdDisc, t.AnUnivCurent })
                .ForeignKey("dbo.AcademicYears", t => t.AnUnivCurent, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.IdSesiune, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => new { t.IdGrupa, t.IdSpec, t.AnStudiu, t.AnUnivStudent, t.Matricola }, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.IdDisc, cascadeDelete: true)
                .Index(t => new { t.IdGrupa, t.IdSpec, t.AnStudiu, t.AnUnivStudent, t.Matricola })
                .Index(t => t.IdSesiune)
                .Index(t => t.IdDisc)
                .Index(t => t.AnUnivCurent);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        IdCorp = c.Int(nullable: false),
                        NrSala = c.Int(nullable: false),
                        Etaj = c.Int(nullable: false),
                        IdGrupa = c.Int(nullable: false),
                        IdSpecializare = c.Int(nullable: false),
                        AnStudiu = c.Int(nullable: false),
                        AnUniversitar = c.Int(nullable: false),
                        IdSesiune = c.Int(nullable: false),
                        IdDisciplina = c.Int(nullable: false),
                        ModEvaluare = c.String(),
                        Data = c.DateTime(nullable: false),
                        Ora = c.Int(nullable: false),
                        Durata = c.String(),
                    })
                .PrimaryKey(t => new { t.IdCorp, t.NrSala, t.Etaj, t.IdGrupa, t.IdSpecializare, t.AnStudiu, t.AnUniversitar, t.IdSesiune, t.IdDisciplina })
                .ForeignKey("dbo.Classrooms", t => new { t.IdCorp, t.NrSala, t.Etaj }, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => new { t.IdGrupa, t.IdSpecializare, t.AnStudiu, t.AnUniversitar }, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.IdSesiune, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.IdDisciplina, cascadeDelete: true)
                .Index(t => new { t.IdCorp, t.NrSala, t.Etaj })
                .Index(t => new { t.IdGrupa, t.IdSpecializare, t.AnStudiu, t.AnUniversitar })
                .Index(t => t.IdSesiune)
                .Index(t => t.IdDisciplina);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        IdCorp = c.Int(nullable: false),
                        NrSala = c.Int(nullable: false),
                        Etaj = c.Int(nullable: false),
                        NrLocuri = c.Int(nullable: false),
                        TipSala = c.String(),
                    })
                .PrimaryKey(t => new { t.IdCorp, t.NrSala, t.Etaj })
                .ForeignKey("dbo.Buildings", t => t.IdCorp, cascadeDelete: true)
                .Index(t => t.IdCorp);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        IdCorp = c.Int(nullable: false, identity: true),
                        DenumireCorp = c.String(),
                        Adresa = c.String(),
                    })
                .PrimaryKey(t => t.IdCorp);
            
            CreateTable(
                "dbo.MakeupExams",
                c => new
                    {
                        IdCorp = c.Int(nullable: false),
                        NrSala = c.Int(nullable: false),
                        Etaj = c.Int(nullable: false),
                        MarcaProf = c.Int(nullable: false),
                        IdDisciplina = c.Int(nullable: false),
                        IdSesiune = c.Int(nullable: false),
                        AnUniversitar = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Ora = c.Int(nullable: false),
                        ModEvaluare = c.String(),
                        Durata = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdCorp, t.NrSala, t.Etaj, t.MarcaProf, t.IdDisciplina, t.IdSesiune, t.AnUniversitar })
                .ForeignKey("dbo.AcademicYears", t => t.AnUniversitar, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => new { t.IdCorp, t.NrSala, t.Etaj }, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.MarcaProf, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.IdSesiune, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.IdDisciplina, cascadeDelete: true)
                .Index(t => new { t.IdCorp, t.NrSala, t.Etaj })
                .Index(t => t.MarcaProf)
                .Index(t => t.IdDisciplina)
                .Index(t => t.IdSesiune)
                .Index(t => t.AnUniversitar);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MakeupExamRequests", "IdDisc", "dbo.Subjects");
            DropForeignKey("dbo.MakeupExamRequests", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUnivStudent", "Matricola" }, "dbo.Students");
            DropForeignKey("dbo.MakeupExamRequests", "IdSesiune", "dbo.Sessions");
            DropForeignKey("dbo.Exams", "IdDisciplina", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "IdSesiune", "dbo.Sessions");
            DropForeignKey("dbo.Exams", new[] { "IdGrupa", "IdSpecializare", "AnStudiu", "AnUniversitar" }, "dbo.Groups");
            DropForeignKey("dbo.Exams", new[] { "IdCorp", "NrSala", "Etaj" }, "dbo.Classrooms");
            DropForeignKey("dbo.MakeupExams", "IdDisciplina", "dbo.Subjects");
            DropForeignKey("dbo.MakeupExams", "IdSesiune", "dbo.Sessions");
            DropForeignKey("dbo.MakeupExams", "MarcaProf", "dbo.Professors");
            DropForeignKey("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj" }, "dbo.Classrooms");
            DropForeignKey("dbo.MakeupExams", "AnUniversitar", "dbo.AcademicYears");
            DropForeignKey("dbo.Classrooms", "IdCorp", "dbo.Buildings");
            DropForeignKey("dbo.MakeupExamRequests", "AnUnivCurent", "dbo.AcademicYears");
            DropIndex("dbo.MakeupExams", new[] { "AnUniversitar" });
            DropIndex("dbo.MakeupExams", new[] { "IdSesiune" });
            DropIndex("dbo.MakeupExams", new[] { "IdDisciplina" });
            DropIndex("dbo.MakeupExams", new[] { "MarcaProf" });
            DropIndex("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj" });
            DropIndex("dbo.Classrooms", new[] { "IdCorp" });
            DropIndex("dbo.Exams", new[] { "IdDisciplina" });
            DropIndex("dbo.Exams", new[] { "IdSesiune" });
            DropIndex("dbo.Exams", new[] { "IdGrupa", "IdSpecializare", "AnStudiu", "AnUniversitar" });
            DropIndex("dbo.Exams", new[] { "IdCorp", "NrSala", "Etaj" });
            DropIndex("dbo.MakeupExamRequests", new[] { "AnUnivCurent" });
            DropIndex("dbo.MakeupExamRequests", new[] { "IdDisc" });
            DropIndex("dbo.MakeupExamRequests", new[] { "IdSesiune" });
            DropIndex("dbo.MakeupExamRequests", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUnivStudent", "Matricola" });
            DropTable("dbo.MakeupExams");
            DropTable("dbo.Buildings");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Exams");
            DropTable("dbo.MakeupExamRequests");
        }
    }
}
