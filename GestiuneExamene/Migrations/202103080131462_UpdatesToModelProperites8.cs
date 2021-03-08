namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites8 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MakeupExams");
            AddColumn("dbo.MakeupExams", "IdMakeupExam", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj", "MarcaProf", "IdDisciplina", "IdSesiune", "AnUniversitar", "IdMakeupExam" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MakeupExams");
            DropColumn("dbo.MakeupExams", "IdMakeupExam");
            AddPrimaryKey("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj", "MarcaProf", "IdDisciplina", "IdSesiune", "AnUniversitar" });
        }
    }
}
