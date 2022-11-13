using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcMusicStore.Models
{

    /// <summary>
    /// Implementación del IdentityUser por defecto que proporciona Microsoft
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Genera la identificación que representara al usuario
        /// </summary>
        /// <param name="manager">Información del usuario</param>
        /// <returns>La identificación del usuario</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// Clase encargada de definir el modelo e intermediario entre la base de datos
    /// y la aplicación
    /// </summary>
    public class MusicStoreEntities: IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Constructor por defecto que define la forma de conexión con la base de datos
        /// </summary>
        public MusicStoreEntities():base("MusicStoreEntities")
        {

        }

        /// <summary>
        /// Lectura y manipulación de la tabla Albums
        /// </summary>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// Lectura y manipulación de la tabla Artistas
        /// </summary>
        public DbSet<Artist> Artists { get; set; }

        /// <summary>
        /// Lectura y manipulación de la tabla Generos
        /// </summary>
        public DbSet<Genre> Genres { get; set; }


        /// <summary>
        /// Método estatico para iniciar con la creación del intermediario
        /// </summary>
        /// <returns></returns>
        public static MusicStoreEntities Create()
        {
            return new MusicStoreEntities();
        }

    }
}