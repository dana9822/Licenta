namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classrooms", "NumberOfSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Classrooms", "ClassroomType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classrooms", "ClassroomType");
            DropColumn("dbo.Classrooms", "NumberOfSeats");
        }
    }
}
