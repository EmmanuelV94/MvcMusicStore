using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// Modelo de base de datos que define la estructrura
    /// de la tabla Albums
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Identificador unico auto incrementable
        /// </summary>
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }


        /// <summary>
        /// Identificador unico del genero al que pertenece el album
        /// </summary>
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        /// <summary>
        /// Titúlo del album
        /// </summary>
        [Required(ErrorMessage = "An Album Title is required"),
            StringLength(160)]
        public string Title { get; set; }

        /// <summary>
        /// Precio de venta
        /// </summary>
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
            ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        /// <summary>
        /// URL con el arte conceptual
        /// </summary>
        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        /// <summary>
        /// Identificador unico del artista al que pertenece el album
        /// </summary>
        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        /// <summary>
        /// Navegación de EF para obtener información adicional del genero
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Navegación de EF para obtener información adicional del Artista
        /// </summary>
        public Artist Artist { get; set; }
    }
}