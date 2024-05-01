using class_11.Models;
using Microsoft.EntityFrameworkCore;

namespace class_11.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions option):base(option) 
        {
                
        }


        public DbSet<EmployeeViewModel> tblEmployee { get; set; }
        public DbSet<StudentViewModel> tblStudends { get; set; }
    }
}
