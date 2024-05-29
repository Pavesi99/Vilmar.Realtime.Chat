using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vilmar.Realtime.Chat.Areas.Message
{
    public class MessageMap : IEntityTypeConfiguration<MessageModel>
    {
        public void Configure(EntityTypeBuilder<MessageModel> builder)
        {
            builder.ToTable("Message");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ChatId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Text).IsRequired();
            builder.Property(p => p.PostedData).IsRequired();
        }
    }
}
