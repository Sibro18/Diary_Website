using Diary.Domain.abstractions;
using Diary.Domain.models;

namespace Diary.Application.Services
{
	public class NoteService
	{
		private INoteRepository _noteRepository;
		public NoteService(INoteRepository noteRepository)
			=> _noteRepository = noteRepository;

		public async Task<List<NoteListDTO>> GetAllNotes()
		{
			var noteList = await _noteRepository.GetNoteList();

			return noteList;
		}

		public async Task<(Note?, bool, string)> GetNoteDetails(Guid id)
		{
			string message = string.Empty;
			bool flag = true;

			var note = await _noteRepository.GetNoteDetails(id);

            if(note == null)
            {
				flag = false;
				message = "The note was not found";
            }
            return (note, flag, message);
		}

		public async Task<(bool, string)> CreateNote(string title, string? description)
		{
			bool flag = false;
			string message;
			if (title != string.Empty && description != string.Empty)
			{
				var note = Note.Create(
				Guid.NewGuid(),
				title,
				description,
				DateTime.Now,
				null);

				await _noteRepository.Create(note);
				flag = true;
				message = "the note was create successfuly";
			}
			else
			{
				message = "the note was not creating";
			}
			return (flag, message);
		}

		public async Task<(bool, string)> UpdateNote(Guid id, 
			string title, string? description)
		{
			bool flag = false;
			string message;
			if(title != string.Empty)
			{
				flag = await _noteRepository.Update(id, title, description);
			}

			if (flag)
			{
				message = "the note was update successfuly";
			}
			else
			{
				message = "the note was not updated";
			}
			return (flag, message);
		}

		public async Task<(bool, string)> DeleteNote(Guid id)
		{
			bool flag = await _noteRepository.Delete(id);
			string message;
	
			if (flag)
			{
				message = "note was deleted successfuly";
			}
			else
			{
				message = "note was not found";
			}

			return (flag, message);
		}

		

	}
}
