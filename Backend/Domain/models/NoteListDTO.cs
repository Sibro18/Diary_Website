namespace Diary.Domain.models
{
	public class NoteListDTO
	{
		public Guid Id { get; private set; }
		public string Title { get; private set; }

		public NoteListDTO (Guid id, string title)
		{
			Id = id;
			Title = title;
		}

		public static NoteListDTO Create(Guid id, string title) =>
			new NoteListDTO(id, title);

	}
}
