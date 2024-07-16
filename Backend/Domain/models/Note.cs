using System;

namespace Diary.Domain.models
{
	public class Note
	{
		public Guid Id { get; private set; }
		public string Title { get; private set; }
		public string? Description { get; private set; }
		public DateTime CreateDate { get; private set; }
		public DateTime? EditDate { get; private set; }

		public Note(Guid id, string title, string? description,
			DateTime create_date, DateTime? edit_date)
		{
			Id = id;
			Title = title;
			Description = description;
			CreateDate = create_date; 
			EditDate = edit_date; 
		}

		public static Note Create(Guid id, string title, string? description,
			DateTime create_date, DateTime? edit_date) => 
			new Note(id, title, description, create_date, edit_date);

	}
}
