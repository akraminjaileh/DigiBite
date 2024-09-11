using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DigiBite_Core.Enums.DigiBiteEnums;

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
            builder.Property(x => x.Quantity).IsRequired(false);
            builder.Property(x => x.ItemPrice).IsRequired(false);
            builder.Property(x => x.SpecialNotes).IsRequired(false);
            builder.Property(x => x.Subtotal).IsRequired(false);
            builder.Property(x => x.Discount).IsRequired(false);
            builder.Property(x => x.VoucherDiscount).IsRequired(false);
            builder.Property(x => x.DeliveryFee).IsRequired(false);
            builder.Property(x => x.ServiceFee).IsRequired(false);
            builder.Property(x => x.TotalAmount).IsRequired(false);
            builder.Property(x => x.VoucherId).IsRequired(false);


            //String Max Length
            builder.Property(x => x.SpecialNotes).HasMaxLength(300);

        }
    }


    //public class CtegoryConfiguration : IEntityTypeConfiguration<Category>
    //{
    //    public void Configure(EntityTypeBuilder<Category> builder)
    //    {

    //        //Foreign key 
    //        builder.HasMany<AgentTransaction>().WithOne().HasForeignKey(x => x.AgentId);


    //        //Nullable(is Not Null By Default) and Default value Config

    //        builder.Property(x => x.LastModifiedDateTime).HasDefaultValue(DateTime.Now);
    //        builder.Property(x => x.CreatedBy).IsRequired(true);


    //        //UNIQUE
    //        builder.HasIndex(x => x.Phone).IsUnique(true);


    //        //Check Constraint
    //        builder.ToTable(x =>
    //        x.HasCheckConstraint("CH_User_Name", "Name NOT LIKE '%[^a-zA-Z ]%' AND LEN(Name) > 5"));


    //        //String Max Length
    //        builder.Property(x => x.Name).HasMaxLength(50);

    //    }
    //}
}
