

namespace ProblemNotififation.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Problem>().HasData(
                new Problem
                {
                    Id = 1,
                    FirstName = "Supitcha",
                    LastName = "Jampathong",
                    //ApplicationName = "Smartcare",
                    ProblemName = "App เปิดไม่ขึ้น",
                    Description = "Login เข้าใช้งานไม่ได้",
                    ApplicationId = 1,  
                },

                new Problem
                {
                    Id = 2,
                    FirstName = "Joonz",
                    LastName = "OiOi",
                    //ApplicationName = "TidlorTidlen",
                    ProblemName = "App เปิดไม่ขึ้น",
                    Description = "เมื่อวานใช้งานได้ปกติ แต่วันนี้ตอนเช้า login ด้วย password ใหม่แล้วขึ้น popup error",
                    ApplicationId= 2,
                }
            );

            modelBuilder.Entity<Application>().HasData(
                new Application { Id = 1, Name = "SmartCare", Description = "Oioi"},
                new Application { Id = 2, Name = "Tidlor", Description = "oioi" }
            );

        }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Application> Applications { get; set; }


    }
}
