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
    public class WalletTransactionConfig : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.HasKey(t => t.WalletTransactionId);

            builder.HasOne(t => t.Wallet)
                   .WithMany(w => w.WalletTransactions)
                   .HasForeignKey(t => t.WalletId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
