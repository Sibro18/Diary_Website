namespace Diary.DataAccess.Entities
{
	public class NoteEntity
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? EditDate { get; set; }
	}
}
