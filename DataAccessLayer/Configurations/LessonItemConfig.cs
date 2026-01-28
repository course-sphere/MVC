
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class LessonItemConfig : IEntityTypeConfiguration<LessonItem>
    {
        public void Configure(EntityTypeBuilder<LessonItem> builder)
        {
            builder.HasKey(li => li.LessonItemId);
            builder.HasOne(li => li.Lesson)
                   .WithMany(l => l.LessonItems)
                   .HasForeignKey(li => li.LessonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
