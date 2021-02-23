using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GestiuneExamene.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        //public DbSet<Group> Groups { get; set; }
        //public DbSet<StudyYear> StudyYears { get; set; }
        //public DbSet<AcademicYear> AcademicYears { get; set; }
        //public DbSet<Subject> Subjects { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<SubjectCoverage> Coverages { get; set; }
        //public DbSet<SubjectAllocation> SubjectAllocations { get; set; }
        //public DbSet<Professor> Professors { get; set; }
        //public DbSet<Building> Buildings { get; set; }
        //public DbSet<Classroom> Classrooms { get; set; }
        //public DbSet<Session> Sessions { get; set; }
        //public DbSet<YearSession> YearSessions { get; set; }
        //public DbSet<MakeupExamRequest> MakeupExamRequests { get; set; }
        //public DbSet<Exam> Exams { get; set; }
        //public DbSet<MakeupExam> MakeupExams { get; set; }


        public class InitDatabase : DropCreateDatabaseAlways<ApplicationDbContext>

        {
            protected override void Seed(ApplicationDbContext ctx)
            {


            }
        }
    }
}