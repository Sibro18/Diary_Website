using Diary.DataAccess;
using Diary.DataAccess.Repositories;
using Diary.Domain.abstractions;
using Microsoft.EntityFrameworkCore;

namespace WEB_API
{
	public class Program
	{
		private static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<NoteDbContext>(options =>
			{
				options.UseSqlite(builder.Configuration.GetConnectionString("NoteConnString"));
			});

			builder.Services.AddScoped<INoteRepository, NoteRepository>();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
