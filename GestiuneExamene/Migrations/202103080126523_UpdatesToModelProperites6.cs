namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MakeupExams");
            DropPrimaryKey("dbo.SessionYears");
            AddColumn("dbo.MakeupExams", "IdIdentificator", c => c.Int(nullable: false));
            AddColumn("dbo.SessionYears", "IdSessionYear", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj", "MarcaProf", "IdDisciplina", "IdSesiune", "AnUniversitar", "IdIdentificator" });
            AddPrimaryKey("dbo.SessionYears", new[] { "IdSesiune", "AnUniversitar", "IdSessionYear" });
            CreateIndex("dbo.MakeupExams", "Data", unique: true);
            CreateIndex("dbo.SessionYears", "DataInceput", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.SessionYears", new[] { "DataInceput" });
            DropIndex("dbo.MakeupExams", new[] { "Data" });
            DropPrimaryKey("dbo.SessionYears");
            DropPrimaryKey("dbo.MakeupExams");
            DropColumn("dbo.SessionYears", "IdSessionYear");
            DropColumn("dbo.MakeupExams", "IdIdentificator");
            AddPrimaryKey("dbo.SessionYears", new[] { "IdSesiune", "AnUniversitar" });
            AddPrimaryKey("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj", "MarcaProf", "IdDisciplina", "IdSesiune", "AnUniversitar" });
        }
    }
}
