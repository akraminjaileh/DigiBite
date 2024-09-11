using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DigiBite_Core.Enums.DigiBiteEnums;

namespace DigiBite_Core.EntityTypeConfigurations.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.Status).HasDefaultValue(OrderStatus.New);
            builder.Property(x => x.PaymentStatus).HasDefaultValue(PaymentStatus.Pending);
            builder.Property(x => x.CustomerNotes).IsRequired(false);
            builder.Property(x => x.Rating).IsRequired(false);
            builder.Property(x => x.DeliveryDate).IsRequired(false);

            //String Max Length
            builder.Property(x => x.CustomerNotes).HasMaxLength(300);

        }
    }
}
