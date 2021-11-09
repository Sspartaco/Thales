using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thales.Entities.Entities
{
    public class ResponseEmployes
    {
        /// <summary>
        /// Codigo de respuesta del servicio
        /// </summary>
        public string status
        { get; set; }

        /// <summary>
        /// Lista de empleados devuelto por el servicio
        /// </summary>
        public Infrastructure.Entities.Employe[] data
        { get; set; }

        /// <summary>
        /// Mensaje retornado por el servicio
        /// </summary>
        public string message
        { get; set; }
    }
}
