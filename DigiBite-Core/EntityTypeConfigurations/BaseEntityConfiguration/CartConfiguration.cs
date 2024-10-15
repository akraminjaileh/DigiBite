using DigiBite_Core.Constant;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.EntityConfiguration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.CartStatus).HasDefaultValue(CartStatus.Active);
            builder.Property(x => x.Subtotal).IsRequired(false);
            builder.Property(x => x.Discount).IsRequired(false);
            builder.Property(x => x.VoucherDiscount).IsRequired(false);
            builder.Property(x => x.DeliveryFee).IsRequired(false);
            builder.Property(x => x.ServiceFee).IsRequired(false);
            builder.Property(x => x.TotalAmount).IsRequired(false);
            builder.Property(x => x.VoucherId).IsRequired(false);


        }
    }
}
