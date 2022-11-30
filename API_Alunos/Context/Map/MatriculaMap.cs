using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Alunos.Context.Map
{
    public class MatriculaMap : IEntityTypeConfiguration<MatriculaModel>
    {
        public void Configure(EntityTypeBuilder<MatriculaModel> builder)
        {
            builder.HasKey(x => x.MatriculaId);
            builder.Property(x => x.MatriculaName).IsRequired().HasMaxLength(255);
        }
    }
}
