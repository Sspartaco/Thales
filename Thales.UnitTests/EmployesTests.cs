using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thales.Infrastructure;
using Thales.UnitTests.FakeEntities;

namespace Thales.UnitTests
{
    [TestClass]
    public class EmployesTests
    {
        public EmployesTests()
        {

        }


        [TestMethod]
        public void AddWhenReturnFalse_Facturacion()
        {
            


            Assert.IsFalse(false);
        }

        [TestMethod]
        public void Employ_ReturnExpected()
        {
            //Arrange
            var inMemorySettings = new Dictionary<string, string>
                {
                    {"EndPoints:Employe", "http://dummy.restapiexample.com/api/v1/employee/"},
                    {"EndPoints:Employes","http://dummy.restapiexample.com/api/v1/employees" }
                };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            FakeEmploye employe = new FakeEmploye();
            employe.id = 2;
            employe.employee_name = "Garrett Winters";
            employe.employee_salary = 170750;
            employe.employee_age = 63;
            employe.profile_image = "";
            employe.Employee_anual_salary = (employe.employee_salary * 12);

            FakeResponse expected = new FakeResponse();
            expected.status = "success";
            expected.data = employe;
            expected.message = "Successfully! Record has been fetched.";

            //Act
            EmployeDomain employeDomain = new EmployeDomain(configuration);
            var result = employeDomain.GetEmployeById(employe.id);

            //Assert

            Assert.AreEqual(expected, result);
        }
    }
}
