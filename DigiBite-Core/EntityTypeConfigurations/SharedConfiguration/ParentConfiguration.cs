using DigiBite_Core.Models.SharedEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBite_Core.EntityTypeConfigurations.SharedConfiguration
{
    public class ParentConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Parent
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            //Nullable(is Not Null By Default) and Default value Config
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDateTime).HasDefaultValueSql("SYSDATETIME()");
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.LastModifiedBy).IsRequired(false);
            builder.Property(x => x.LastModifiedDateTime).IsRequired(false);
        }
    }
}
