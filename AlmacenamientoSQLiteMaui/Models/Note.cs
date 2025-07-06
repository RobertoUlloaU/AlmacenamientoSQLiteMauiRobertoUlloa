using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace AlmacenamientoSQLiteMaui.Models
{
    // Clase que representa la tabla en la base de datos
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // ID único, clave primaria

        [MaxLength(250)]
        public string Text { get; set; } // Texto de la nota

        public DateTime Date { get; set; } // Fecha de creación
    }
}
