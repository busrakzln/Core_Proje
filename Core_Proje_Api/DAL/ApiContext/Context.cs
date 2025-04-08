using Core_Proje_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=CoreProjeDb2;integrated security=true");
        }// bu bağlantı adresi SQL'e bir veri tabanı olarak yansıtılacak

        public DbSet<Category> Categories { get; set; }
    }
}
