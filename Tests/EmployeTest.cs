using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using Tests.FakeEntities;
using Thales.Infrastructure;

namespace Tests
{
    public class Tests
    {
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string>
                {
                    {"EndPoints:Employe", "http://dummy.restapiexample.com/api/v1/employee/"},
                    {"EndPoints:Employes","http://dummy.restapiexample.com/api/v1/employees" }
                };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Test]
        public void Employ_ReturnExpected()
        {
            //Arrange
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
            EmployeDomain employeDomain = new EmployeDomain(_configuration);
            var result = employeDomain.GetEmployeById(employe.id);
            while (!result.IsCompleted) { };

            //Assert
            Assert.IsNotNull(result.Result);
            Assert.AreEqual(result.Result.data.Employee_anual_salary, expected.data.Employee_anual_salary);
            Assert.AreEqual(result.Result.data.employee_age, expected.data.employee_age);
            Assert.AreEqual(result.Result.data.employee_name, expected.data.employee_name);
            Assert.AreEqual(result.Result.data.employee_salary, expected.data.employee_salary);

            Assert.AreEqual(result.Result.message, expected.message);
            Assert.AreEqual(result.Result.status, expected.status);
        }
    }
}