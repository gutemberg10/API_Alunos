using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Alunos.Context.Map
{
    public class TurmaMap : IEntityTypeConfiguration<TurmaModel>
    {
        public void Configure(EntityTypeBuilder<TurmaModel> builder)
        {
            builder.HasKey(x => x.TurmaId);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnoLetivo).IsRequired().HasMaxLength(150);
        }
    }
}
