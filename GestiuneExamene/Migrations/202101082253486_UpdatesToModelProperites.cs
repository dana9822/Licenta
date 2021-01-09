namespace GestiuneExamene.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToModelProperites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        AcademicalYear = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AcademicalYear);
            
            CreateTable(
                "dbo.Coverages",
                c => new
                    {
                        SpecializationID = c.Int(nullable: false),
                        AcademicalYear = c.String(nullable: false, maxLength: 128),
                        StudyingYear = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpecializationID, t.AcademicalYear, t.StudyingYear, t.ProfessorId, t.SubjectId })
                .ForeignKey("dbo.AcademicYears", t => t.AcademicalYear, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.StudyYears", t => t.StudyingYear, cascadeDelete: true)
                .Index(t => t.SpecializationID)
                .Index(t => t.AcademicalYear)
                .Index(t => t.StudyingYear)
                .Index(t => t.ProfessorId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        ProfessorFirstName = c.String(),
                        ProfessorLastName = c.String(),
                        ProfessorUniversityDegree = c.String(),
                    })
                .PrimaryKey(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationID = c.Int(nullable: false),
                        SpecializationName = c.String(),
                        SpecializationDegreeLevel = c.String(),
                    })
                .PrimaryKey(t => t.SpecializationID)
                .ForeignKey("dbo.Faculties", t => t.SpecializationID)
                .Index(t => t.SpecializationID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        faculty_id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.faculty_id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupNumber = c.Int(nullable: false),
                        NumberOfStudents = c.Int(nullable: false),
                        AcademicYear_AcademicalYear = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GroupNumber)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYear_AcademicalYear)
                .ForeignKey("dbo.Specializations", t => t.GroupNumber)
                .ForeignKey("dbo.StudyYears", t => t.GroupNumber)
                .Index(t => t.GroupNumber)
                .Index(t => t.AcademicYear_AcademicalYear);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        GroupNumber = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        ClassroomNumber = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        EvaluationMode = c.String(),
                        ExamDate = c.DateTime(nullable: false),
                        ExamHour = c.Int(nullable: false),
                        ExamTime = c.Int(nullable: false),
                        Classroom_ClassroomFloor = c.Int(),
                        Classroom_ClassroomNumber = c.Int(),
                    })
                .PrimaryKey(t => new { t.GroupNumber, t.SessionId, t.ClassroomNumber, t.SubjectId })
                .ForeignKey("dbo.Classrooms", t => new { t.Classroom_ClassroomFloor, t.Classroom_ClassroomNumber })
                .ForeignKey("dbo.Groups", t => t.GroupNumber, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupNumber)
                .Index(t => t.SessionId)
                .Index(t => t.SubjectId)
                .Index(t => new { t.Classroom_ClassroomFloor, t.Classroom_ClassroomNumber });
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomFloor = c.Int(nullable: false),
                        ClassroomNumber = c.Int(nullable: false),
                        Building_BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassroomFloor, t.ClassroomNumber })
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId)
                .Index(t => t.Building_BuildingId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingName = c.String(),
                        BuildingAdress = c.String(),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        SessionName = c.String(),
                    })
                .PrimaryKey(t => t.SessionId);
            
            CreateTable(
                "dbo.MakeupExamRequests",
                c => new
                    {
                        AcademicalYear = c.String(nullable: false, maxLength: 128),
                        StudentRegNumber = c.Int(nullable: false),
                        User = c.String(nullable: false, maxLength: 128),
                        SessionId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Student_StudentRegNumber = c.Int(),
                        Student_User = c.String(maxLength: 128),
                        Student_StudentRegNumber1 = c.Int(),
                        Student_User1 = c.String(maxLength: 128),
                        StudentUser_StudentRegNumber = c.Int(),
                        StudentUser_User = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AcademicalYear, t.StudentRegNumber, t.User, t.SessionId, t.SubjectId })
                .ForeignKey("dbo.AcademicYears", t => t.AcademicalYear, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => new { t.Student_StudentRegNumber, t.Student_User })
                .ForeignKey("dbo.Students", t => new { t.Student_StudentRegNumber1, t.Student_User1 })
                .ForeignKey("dbo.Students", t => new { t.StudentUser_StudentRegNumber, t.StudentUser_User })
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.AcademicalYear)
                .Index(t => t.SessionId)
                .Index(t => t.SubjectId)
                .Index(t => new { t.Student_StudentRegNumber, t.Student_User })
                .Index(t => new { t.Student_StudentRegNumber1, t.Student_User1 })
                .Index(t => new { t.StudentUser_StudentRegNumber, t.StudentUser_User });
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentRegNumber = c.Int(nullable: false),
                        User = c.String(nullable: false, maxLength: 128),
                        StudentFirstName = c.String(),
                        StudentLastName = c.String(),
                        IsStudentStatus = c.String(),
                        Password = c.String(),
                        Group_GroupNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRegNumber, t.User })
                .ForeignKey("dbo.Groups", t => t.Group_GroupNumber)
                .Index(t => t.Group_GroupNumber);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.SubjectAllocations",
                c => new
                    {
                        SpecializationID = c.Int(nullable: false),
                        StudyingYear = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Semester = c.String(),
                        EvaluationType = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => new { t.SpecializationID, t.StudyingYear, t.SubjectId })
                .ForeignKey("dbo.Specializations", t => t.SpecializationID, cascadeDelete: true)
                .ForeignKey("dbo.StudyYears", t => t.StudyingYear, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SpecializationID)
                .Index(t => t.StudyingYear)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.StudyYears",
                c => new
                    {
                        StudyingYear = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.StudyingYear);
            
            CreateTable(
                "dbo.YearSessions",
                c => new
                    {
                        AcademicalYear = c.String(nullable: false, maxLength: 128),
                        SessionId = c.Int(nullable: false),
                        BeginSessionDate = c.DateTime(nullable: false),
                        EndSessionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.AcademicalYear, t.SessionId, t.BeginSessionDate })
                .ForeignKey("dbo.AcademicYears", t => t.AcademicalYear, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.AcademicalYear)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.MakeupExams",
                c => new
                    {
                        AcademicalYear = c.String(nullable: false, maxLength: 128),
                        SessionId = c.Int(nullable: false),
                        ClassroomNumber = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        MakeupExamDate = c.DateTime(nullable: false),
                        MakeupExamHour = c.Int(nullable: false),
                        MakeupExamTime = c.Int(nullable: false),
                        MakeupExamEvaluationMode = c.String(),
                        Classroom_ClassroomFloor = c.Int(),
                        Classroom_ClassroomNumber = c.Int(),
                    })
                .PrimaryKey(t => new { t.AcademicalYear, t.SessionId, t.ClassroomNumber, t.ProfessorId, t.SubjectId, t.MakeupExamDate, t.MakeupExamHour })
                .ForeignKey("dbo.AcademicYears", t => t.AcademicalYear, cascadeDelete: true)
                .ForeignKey("dbo.Classrooms", t => new { t.Classroom_ClassroomFloor, t.Classroom_ClassroomNumber })
                .ForeignKey("dbo.Professors", t => t.ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.AcademicalYear)
                .Index(t => t.SessionId)
                .Index(t => t.ProfessorId)
                .Index(t => t.SubjectId)
                .Index(t => new { t.Classroom_ClassroomFloor, t.Classroom_ClassroomNumber });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MakeupExams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.MakeupExams", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.MakeupExams", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.MakeupExams", new[] { "Classroom_ClassroomFloor", "Classroom_ClassroomNumber" }, "dbo.Classrooms");
            DropForeignKey("dbo.MakeupExams", "AcademicalYear", "dbo.AcademicYears");
            DropForeignKey("dbo.Groups", "GroupNumber", "dbo.StudyYears");
            DropForeignKey("dbo.Groups", "GroupNumber", "dbo.Specializations");
            DropForeignKey("dbo.YearSessions", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.YearSessions", "AcademicalYear", "dbo.AcademicYears");
            DropForeignKey("dbo.SubjectAllocations", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectAllocations", "StudyingYear", "dbo.StudyYears");
            DropForeignKey("dbo.Coverages", "StudyingYear", "dbo.StudyYears");
            DropForeignKey("dbo.SubjectAllocations", "SpecializationID", "dbo.Specializations");
            DropForeignKey("dbo.MakeupExamRequests", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Coverages", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.MakeupExamRequests", new[] { "StudentUser_StudentRegNumber", "StudentUser_User" }, "dbo.Students");
            DropForeignKey("dbo.MakeupExamRequests", new[] { "Student_StudentRegNumber1", "Student_User1" }, "dbo.Students");
            DropForeignKey("dbo.MakeupExamRequests", new[] { "Student_StudentRegNumber", "Student_User" }, "dbo.Students");
            DropForeignKey("dbo.Students", "Group_GroupNumber", "dbo.Groups");
            DropForeignKey("dbo.MakeupExamRequests", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.MakeupExamRequests", "AcademicalYear", "dbo.AcademicYears");
            DropForeignKey("dbo.Exams", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Exams", "GroupNumber", "dbo.Groups");
            DropForeignKey("dbo.Exams", new[] { "Classroom_ClassroomFloor", "Classroom_ClassroomNumber" }, "dbo.Classrooms");
            DropForeignKey("dbo.Classrooms", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Groups", "AcademicYear_AcademicalYear", "dbo.AcademicYears");
            DropForeignKey("dbo.Specializations", "SpecializationID", "dbo.Faculties");
            DropForeignKey("dbo.Coverages", "SpecializationID", "dbo.Specializations");
            DropForeignKey("dbo.Coverages", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.Coverages", "AcademicalYear", "dbo.AcademicYears");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MakeupExams", new[] { "Classroom_ClassroomFloor", "Classroom_ClassroomNumber" });
            DropIndex("dbo.MakeupExams", new[] { "SubjectId" });
            DropIndex("dbo.MakeupExams", new[] { "ProfessorId" });
            DropIndex("dbo.MakeupExams", new[] { "SessionId" });
            DropIndex("dbo.MakeupExams", new[] { "AcademicalYear" });
            DropIndex("dbo.YearSessions", new[] { "SessionId" });
            DropIndex("dbo.YearSessions", new[] { "AcademicalYear" });
            DropIndex("dbo.SubjectAllocations", new[] { "SubjectId" });
            DropIndex("dbo.SubjectAllocations", new[] { "StudyingYear" });
            DropIndex("dbo.SubjectAllocations", new[] { "SpecializationID" });
            DropIndex("dbo.Students", new[] { "Group_GroupNumber" });
            DropIndex("dbo.MakeupExamRequests", new[] { "StudentUser_StudentRegNumber", "StudentUser_User" });
            DropIndex("dbo.MakeupExamRequests", new[] { "Student_StudentRegNumber1", "Student_User1" });
            DropIndex("dbo.MakeupExamRequests", new[] { "Student_StudentRegNumber", "Student_User" });
            DropIndex("dbo.MakeupExamRequests", new[] { "SubjectId" });
            DropIndex("dbo.MakeupExamRequests", new[] { "SessionId" });
            DropIndex("dbo.MakeupExamRequests", new[] { "AcademicalYear" });
            DropIndex("dbo.Classrooms", new[] { "Building_BuildingId" });
            DropIndex("dbo.Exams", new[] { "Classroom_ClassroomFloor", "Classroom_ClassroomNumber" });
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropIndex("dbo.Exams", new[] { "SessionId" });
            DropIndex("dbo.Exams", new[] { "GroupNumber" });
            DropIndex("dbo.Groups", new[] { "AcademicYear_AcademicalYear" });
            DropIndex("dbo.Groups", new[] { "GroupNumber" });
            DropIndex("dbo.Specializations", new[] { "SpecializationID" });
            DropIndex("dbo.Coverages", new[] { "SubjectId" });
            DropIndex("dbo.Coverages", new[] { "ProfessorId" });
            DropIndex("dbo.Coverages", new[] { "StudyingYear" });
            DropIndex("dbo.Coverages", new[] { "AcademicalYear" });
            DropIndex("dbo.Coverages", new[] { "SpecializationID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MakeupExams");
            DropTable("dbo.YearSessions");
            DropTable("dbo.StudyYears");
            DropTable("dbo.SubjectAllocations");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.MakeupExamRequests");
            DropTable("dbo.Sessions");
            DropTable("dbo.Buildings");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Exams");
            DropTable("dbo.Groups");
            DropTable("dbo.Faculties");
            DropTable("dbo.Specializations");
            DropTable("dbo.Professors");
            DropTable("dbo.Coverages");
            DropTable("dbo.AcademicYears");
        }
    }
}
