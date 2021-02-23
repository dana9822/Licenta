namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        IdGrupa = c.Int(nullable: false),
                        IdSpec = c.Int(nullable: false),
                        AnStudiu = c.Int(nullable: false),
                        AnUniv = c.Int(nullable: false),
                        Matricola = c.Int(nullable: false),
                        Username = c.String(),
                        Nume = c.String(),
                        Prenume = c.String(),
                        StatusStudent = c.String(),
                    })
                .PrimaryKey(t => new { t.IdGrupa, t.IdSpec, t.AnStudiu, t.AnUniv, t.Matricola })
                .ForeignKey("dbo.Groups", t => new { t.IdGrupa, t.IdSpec, t.AnStudiu, t.AnUniv }, cascadeDelete: true)
                .Index(t => new { t.IdGrupa, t.IdSpec, t.AnStudiu, t.AnUniv });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUniv" }, "dbo.Groups");
            DropIndex("dbo.Students", new[] { "IdGrupa", "IdSpec", "AnStudiu", "AnUniv" });
            DropTable("dbo.Students");
        }
    }
}
