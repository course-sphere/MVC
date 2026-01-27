using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class GradedItemConfig : IEntityTypeConfiguration<GradedItem>
    {
        public void Configure(EntityTypeBuilder<GradedItem> builder)
        {
            builder.HasKey(gi => gi.GradedItemId);
            builder.HasOne(gi => gi.Lesson)
                   .WithMany(l => l.GradedItems)
                   .HasForeignKey(gi => gi.LessonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }   
}
