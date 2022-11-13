using System.Collections.Generic;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// Modelo de base datos que define la estructura de la tabla Generos
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Indentificador unico auto incrementable
        /// </summary>
        public int GenreId { get; set; }
        /// <summary>
        /// Nombre del genero
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Una descripción corta que detalle el tipo de musica y origen
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Navegación de EF para visualizar los albums que poseen dicho genero
        /// </summary>
        public List<Album> Albums { get; set; }
    }
}