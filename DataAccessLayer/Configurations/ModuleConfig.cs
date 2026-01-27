using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class ModuleConfig : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(m => m.ModuleId);

            builder.HasOne(m => m.Course)
                   .WithMany(c => c.Modules)
                   .HasForeignKey(m => m.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
