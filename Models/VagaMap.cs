using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoVagas.Models
{
    public class VagaMap : IEntityTypeConfiguration<Vaga>
    {




        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.HasKey(x => x.Id); // Define Id como chave primária

            builder.Property(x => x.Title)
                .IsRequired() // Define que o campo é obrigatório
                .HasMaxLength(1000); // Define o tamanho máximo do título

            builder.Property(x => x.Description)
                .IsRequired() // Define que o campo é obrigatório
                .HasColumnType("TEXT"); // Define o tipo de coluna como TEXT

            builder.Property(x => x.Redirect_url)
                .IsRequired() // Define que o campo é obrigatório
                .HasColumnType("TEXT"); // Define o tipo de coluna como TEXT

            builder.Property(x => x.Created)
                .IsRequired() // Define que o campo é obrigatório
                .HasMaxLength(1000); // Define o tamanho máximo do campo Created

            builder.Property(x => x.Location)
                .IsRequired() // Define que o campo é obrigatório
                .HasMaxLength(1000); // Define o tamanho máximo do nome da localização

            builder.Property(x => x.Company)
                .IsRequired() // Define que o campo é obrigatório
                .HasMaxLength(1000); // Define o tamanho máximo do nome da empresa

           
        }


    }
}
