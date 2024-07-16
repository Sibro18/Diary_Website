using Diary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diary.DataAccess
{
	public class NoteDbContext : DbContext
	{
		public NoteDbContext(DbContextOptions<NoteDbContext> options)
			: base(options)
		{
		}

		public DbSet<NoteEntity> Notes { get; set; }
	}
}
