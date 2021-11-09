
namespace Thales.Infrastructure.Entities
{
    /// <summary>
    /// Estructura de empleado
    /// </summary>
    public class Employe
    {

        /// <summary>
        /// Identificador unico
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre del empleado
        /// </summary>
        public string employee_name { get; set; }

        /// <summary>
        /// Salario del empleado
        /// </summary>
        public int employee_salary { get; set; }

        /// <summary>
        /// Edad del empleado
        /// </summary>
        public int employee_age { get; set; }

        /// <summary>
        /// Imagen del empleado
        /// </summary>
        public string profile_image { get; set; }

        /// <summary>
        /// Saluario Anual empleado
        /// </summary>
        public int Employee_anual_salary { get; set; }
    }
}
