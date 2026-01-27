using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.LessonId);

            builder.HasOne(l => l.Module)
                   .WithMany(m => m.Lessons)
                   .HasForeignKey(l => l.ModuleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
