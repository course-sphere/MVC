using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class WalletConfig : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(w => w.WalletId);
            builder.HasOne(w => w.User)
                           .WithOne(u => u.Wallet)
                           .HasForeignKey<Wallet>(w => w.UserId)
                           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
