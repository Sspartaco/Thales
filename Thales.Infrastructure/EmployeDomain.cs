using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Thales.Applicatio;
using Thales.Entities.Entities;

namespace Thales.Infrastructure
{
    public class EmployeDomain : IEmploye
    {
        private readonly IConfiguration _configuration;

        public EmployeDomain(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseEmployes> GetEmployes()
        {
            try
            {
                var httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(_configuration.GetSection("EndPoints:Employes").Value);
                var resultDeserialize = JsonConvert.DeserializeObject<ResponseEmployes>(result);

                if (resultDeserialize != null)
                    foreach (var employe in resultDeserialize.data)
                    {
                        employe.Employee_anual_salary = (employe.employee_salary * 12);
                    }

                return resultDeserialize;
            }
            catch
            {

                throw;
            }
        }

        public async Task<ResponseEmploye> GetEmployeById(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(String.Concat(_configuration.GetSection("EndPoints:Employe").Value, id));
                var resultDeserialize = JsonConvert.DeserializeObject<ResponseEmploye>(result);

                if (resultDeserialize != null)
                    resultDeserialize.data.Employee_anual_salary = (resultDeserialize.data.employee_salary * 12);

                return resultDeserialize;
            }
            catch
            {

                throw;
            }
        }
    }
}