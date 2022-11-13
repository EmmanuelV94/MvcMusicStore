namespace MvcMusicStore.Models
{
    /// <summary>
    /// Modelo de base de datos que define la estructura de la tabla Artistas
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Identificador unico auto incrementable
        /// </summary>
        public int ArtistId { get; set; }
        /// <summary>
        /// Nombre del artista o banda
        /// </summary>
        public string Name { get; set; }
    }
}