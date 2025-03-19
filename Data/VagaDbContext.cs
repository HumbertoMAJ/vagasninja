using Microsoft.EntityFrameworkCore;
using ProjetoVagas.Models;

namespace ProjetoVagas.Data
{
    public class VagaDbContext : DbContext
    {
        public VagaDbContext(DbContextOptions<VagaDbContext> options)
            : base(options)
        {              
        }

        public DbSet<Vaga> Vagas { get; set; }



      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento para a entidade Vaga
            modelBuilder.Entity<Vaga>(builder =>
            {
                builder.HasKey(v => v.Id);
                builder.Property(v => v.Title)
                    .HasMaxLength(1000)
                    .IsRequired();
                builder.Property(v => v.Description)
                    .HasColumnType("TEXT");
                builder.Property(v => v.Redirect_url)
                    .HasColumnType("TEXT")
                    .IsRequired();  // Adicionado IsRequired
                builder.Property(v => v.Created)
                    .HasColumnType("datetime")
                    .IsRequired();  // Mudando para datetime

                // Mapeamento para Location
                builder.OwnsOne(v => v.Location, location =>
                {
                    location.Property(l => l.Display_name)
                        .HasMaxLength(1000)
                        .HasColumnName("Location_Display_name");

                    // Se precisar armazenar 'Area' como uma string JSON
                    location.Ignore(l => l.Area); // Armazene como texto JSON ou delimitado por vírgulas
                });

                // Mapeamento para Company
                builder.OwnsOne(v => v.Company, company =>
                {
                    company.Property(c => c.Display_name)
                        .HasMaxLength(1000)
                        .HasColumnName("Company_Display_name");
                });

               
               
            });
        }




    }
}
