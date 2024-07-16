using Diary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diary.DataAccess.Configurations
{
	public class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
	{
		public void Configure(EntityTypeBuilder<NoteEntity> builder) 
		{
			builder.HasKey(n => n.Id);
			builder.Property(n => n.Title)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(n => n.Description)
				.HasMaxLength(256);
			builder.Property(n => n.CreateDate)
				.IsRequired();

		}
	}
}
