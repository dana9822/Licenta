namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites7 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MakeupExams");
            AddPrimaryKey("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj", "MarcaProf", "IdDisciplina", "IdSesiune", "AnUniversitar" });
            DropColumn("dbo.MakeupExams", "IdIdentificator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MakeupExams", "IdIdentificator", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.MakeupExams");
            AddPrimaryKey("dbo.MakeupExams", new[] { "IdCorp", "NrSala", "Etaj", "MarcaProf", "IdDisciplina", "IdSesiune", "AnUniversitar", "IdIdentificator" });
        }
    }
}
