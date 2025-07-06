using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AlmacenamientoSQLiteMaui.Models;

namespace AlmacenamientoSQLiteMaui.Data
{
    // Clase que gestiona la conexión a la base de datos y las operaciones CRUD
    public class NotesDatabase
    {
        readonly SQLiteAsyncConnection database;

        // Constructor que recibe la ruta de la base de datos
        public NotesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait(); // Crea la tabla si no existe
        }

        // Obtiene todas las notas
        public Task<List<Note>> GetNotesAsync()
        {
            return database.Table<Note>().ToListAsync();
        }

        // Obtiene una nota específica por ID
        public Task<Note> GetNoteAsync(int id)
        {
            return database.Table<Note>()
                           .Where(i => i.Id == id)
                           .FirstOrDefaultAsync();
        }

        // Guarda o actualiza una nota
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return database.UpdateAsync(note); // Si tiene ID, actualiza
            }
            else
            {
                return database.InsertAsync(note); // Si no tiene ID, inserta nueva
            }
        }

        // Elimina una nota
        public Task<int> DeleteNoteAsync(Note note)
        {
            return database.DeleteAsync(note);
        }
    }
}
