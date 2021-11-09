
namespace Thales.UnitTests.FakeEntities
{
    public class FakeResponse
    {
        /// <summary>
        /// Codigo de respuesta del servicio
        /// </summary>
        public string status
        { get; set; }

        /// <summary>
        /// Lista de empleados devuelto por el servicio
        /// </summary>
        public FakeEmploye data
        { get; set; }

        /// <summary>
        /// Mensaje retornado por el servicio
        /// </summary>
        public string message
        { get; set; }
    }
}
