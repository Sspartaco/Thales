
namespace Thales.Entities.Entities
{
    /// <summary>
    /// Respuesta del servicio
    /// </summary>
    public class ResponseEmploye
    {
        /// <summary>
        /// Codigo de respuesta del servicio
        /// </summary>
        public string status
        { get; set; }

        /// <summary>
        /// Lista de empleados devuelto por el servicio
        /// </summary>
        public Infrastructure.Entities.Employe data
        { get; set; }

        /// <summary>
        /// Mensaje retornado por el servicio
        /// </summary>
        public string message
        { get; set; }
    }
}
