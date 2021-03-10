namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Parola", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Parola");
        }
    }
}
