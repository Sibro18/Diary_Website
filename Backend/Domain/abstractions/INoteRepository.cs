using Diary.Domain.models;

namespace Diary.Domain.abstractions
{
	public interface INoteRepository
	{
		Task<Guid> Create(Note note);
		Task<bool> Delete(Guid id);
		Task<Note?> GetNoteDetails(Guid id);
		Task<List<NoteListDTO>> GetNoteList();
		Task<bool> Update(Guid id, string title, string? description = null);
	}
}