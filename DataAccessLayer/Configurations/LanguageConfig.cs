using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.LanguageId);

            builder.HasIndex(l => l.Code).IsUnique();
            builder.HasIndex(l => l.Name).IsUnique();
            builder.HasData(
            new Language
            {
                LanguageId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Code = "en",
                Name = "English",
                IsActive = true
            },
            new Language
            {
                LanguageId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Code = "ja",
                Name = "Japanese",
                IsActive = true
            },
            new Language
            {
                LanguageId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Code = "ko",
                Name = "Korean",
                IsActive = true
            },
            new Language
            {
                LanguageId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Code = "zh",
                Name = "Chinese",
                IsActive = true
            },
            new Language
            {
                LanguageId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Code = "es",
                Name = "Spanish",
                IsActive = true
            },
            new Language
            {
                LanguageId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Code = "fr",
                Name = "French",
                IsActive = true
            },
            new Language
            {
                LanguageId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                Code = "de",
                Name = "German",
                IsActive = true
            },
            new Language
            {
                LanguageId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                Code = "vi",
                Name = "Vietnamese",
                IsActive = true
            }
        );
        }
    }
}