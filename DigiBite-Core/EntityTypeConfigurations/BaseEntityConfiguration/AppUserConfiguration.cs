using DigiBite_Core.Enums;
using DigiBite_Core.Models.Entities;
using DigiBite_Core.Models.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.BaseEntityConfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {


            //Foreign key 
            builder.HasMany<Address>().WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany<Cart>().WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany<Category>().WithOne().HasForeignKey(x => x.CreatedBy);
            builder.HasMany<Ingredient>().WithOne().HasForeignKey(x => x.CreatedBy);
            builder.HasMany<Item>().WithOne().HasForeignKey(x => x.CreatedBy);
            builder.HasMany<Meal>().WithOne().HasForeignKey(x => x.CreatedBy);
            builder.HasMany<Order>().WithOne().HasForeignKey(x => x.CreatedBy);
            //This indicates which employee created this Voucher
            builder.HasMany<Voucher>().WithOne().HasForeignKey(x => x.CreatedBy);


            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsBanned).HasDefaultValue(false);
            builder.Property(x => x.CreationDateTime).HasDefaultValueSql("SYSDATETIME()");
            builder.Property(x => x.LastModifiedDateTime).HasDefaultValueSql("SYSDATETIME()");

            builder.Property(x => x.DateOfBirth).IsRequired(false);
            builder.Property(x => x.ProfileImgId).IsRequired(false);
            builder.Property(x => x.LastName).IsRequired(false);
            builder.Property(x => x.BanReason).IsRequired(false);
            builder.Property(x => x.EmployeeInformationId).IsRequired(false);
            builder.Property(x => x.Gender).IsRequired(false);
            builder.Property(x => x.BanType).IsRequired(false);

            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.PasswordHash).IsRequired(true);
            builder.Property(x => x.PhoneNumber).IsRequired(true);
            builder.Property(x => x.UserName).IsRequired(true);

            //UNIQUE
            builder.HasIndex(x => x.Email).IsUnique(true);
            builder.HasIndex(x => x.PhoneNumber).IsUnique(true);

            //Check Constraint
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_User_FirstName", "FirstName NOT LIKE '%[^a-zA-Z ]%' AND LEN(FirstName) > 2"));
            builder.ToTable(x =>
            x.HasCheckConstraint("CH_User_LastName", "LastName NOT LIKE '%[^a-zA-Z ]%' AND LEN(LastName) > 2"));

            //String Max Length
            builder.Property(x => x.FirstName).HasMaxLength(20);
            builder.Property(x => x.LastName).HasMaxLength(20);


        }
    }
}
