namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "ProfTitular", c => c.Int(nullable: false));
            AddColumn("dbo.Exams", "ProfSupraveghetor", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "ProfSupraveghetor");
            DropColumn("dbo.Exams", "ProfTitular");
        }
    }
}
