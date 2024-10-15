using DigiBite_Core.Entities.Lookups;
using DigiBite_Core.Entities.ManyToMany;
using DigiBite_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.ManyToManyConfiguration
{
    public class CartItemAddonConfiguration : IEntityTypeConfiguration<CartItemAddon>
    {
        public void Configure(EntityTypeBuilder<CartItemAddon> builder)
        {
            //Composite Key
            builder.HasKey(x => new {x.AddonId , x.CartItemId});
            //Foreign key 
            builder.HasOne<CartItem>().WithMany().HasForeignKey(x => x.CartItemId);
            builder.HasOne<AddOn>().WithMany().HasForeignKey(x => x.AddonId);

        }
    }
}
