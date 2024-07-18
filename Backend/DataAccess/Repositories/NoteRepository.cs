using Diary.DataAccess.Entities;
using Diary.Domain.models;
using Diary.Domain.abstractions;
using Microsoft.EntityFrameworkCore;

namespace Diary.DataAccess.Repositories
{
	public class NoteRepository : INoteRepository
	{
		private readonly NoteDbContext _context;

		public NoteRepository(NoteDbContext context) =>
			_context = context;

		public async Task<List<NoteListDTO>> GetNoteList()
		{
			var note_entity = await _context.Notes
				.AsNoTracking()
				.ToListAsync();

			var notes = note_entity.Select(n =>
				NoteListDTO.Create(n.Id, n.Title))
				.ToList();
			return notes;
		}
		public async Task<Note?> GetNoteDetails(Guid id)
		{
			var note_entity = await _context.Notes.FindAsync(id);
			Note? note = null;
			if (note_entity != null)
			{
				note = Note
				.Create(note_entity.Id, note_entity.Title,
						note_entity.Description, note_entity.CreateDate,
						note_entity.EditDate);
			}
			return note;
		}

		public async Task<Guid> Create(Note note)
		{
			var note_entity = new NoteEntity
			{
				Id = note.Id,
				Title = note.Title,
				Description = note.Description,
				CreateDate = note.CreateDate,
				EditDate = note.EditDate
			};

			await _context.Notes.AddAsync(note_entity);
			await _context.SaveChangesAsync();

			return note_entity.Id;
		}

		public async Task<bool> Update(Guid id, string title,
			string? description = null)
		{
			var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
			if (note == null)
			{
				return false;
			}

			await _context.Notes
				.Where(n => n.Id == id)
				.ExecuteUpdateAsync(s => s
					.SetProperty(n => n.Title, n => title)
					.SetProperty(n => n.Description, n => description)
					.SetProperty(n => n.EditDate, n => DateTime.Now));

			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(Guid id)
		{
			var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
			if (note == null)
			{
				return false;
			}
			_context.Notes.Remove(note);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
