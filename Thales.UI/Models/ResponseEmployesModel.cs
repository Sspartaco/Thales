namespace Thales.UI.Models
{
    public class ResponseEmployesModel
    {
        /// <summary>
        /// Codigo de respuesta del servicio
        /// </summary>
        public string status
        { get; set; }

        /// <summary>
        /// Lista de empleados devuelto por el servicio
        /// </summary>
        public Infrastructure.Entities.Employe[] Employes
        { get; set; }

        /// <summary>
        /// Lista de empleados devuelto por el servicio
        /// </summary>
        public Infrastructure.Entities.Employe Employe
        { get; set; }

        /// <summary>
        /// Mensaje retornado por el servicio
        /// </summary>
        public string message
        { get; set; }

        public string ErrorResponse { get; set; }
    }
}
