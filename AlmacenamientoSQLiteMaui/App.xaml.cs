using AlmacenamientoSQLiteMaui.Data;
using System.IO;

namespace AlmacenamientoSQLiteMaui
{
    public partial class App : Application
    {
        static NotesDatabase database;

        // Propiedad estática para acceder a la base de datos
        public static NotesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3");
                    database = new NotesDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell(); // Mantén esta línea
        }
    }
}

