using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Thales.Applicatio;
using Thales.UI.Models;

namespace Thales.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmploye _employe;

        public HomeController(ILogger<HomeController> logger, IEmploye employe)
        {
            _logger = logger;
            _employe = employe;
        }

        public IActionResult Index()
        {
            ResponseEmployesModel responseEmployesModel = new ResponseEmployesModel();
            return View("Index", responseEmployesModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetEmployesAction()
        {
            ResponseEmployesModel responseEmployesModel = new ResponseEmployesModel();
            try
            {
                var EmployeId = this.HttpContext.Request.Form["EmployeId"];
                if (EmployeId == string.Empty)
                    responseEmployesModel = GetEmployes();
                else
                {
                    int employeId = 0;
                    if (int.TryParse(EmployeId, out employeId))
                    {
                        if (employeId > 0)
                            responseEmployesModel = GetEmploye(employeId);
                        else
                            responseEmployesModel = GetEmployes();
                    }
                    else
                        responseEmployesModel = GetEmployes();

                }

                return View("Index", responseEmployesModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                responseEmployesModel.ErrorResponse = ex.Message;
                return View("Index", responseEmployesModel);
            }
        }

        private ResponseEmployesModel GetEmploye(int id)
        {
            try
            {
                var employeStatus = _employe.GetEmployeById(id);
                while (!employeStatus.IsCompleted) { }
                if (employeStatus.Status == TaskStatus.Faulted)
                    throw new Exception(employeStatus.Exception.Message, employeStatus.Exception.InnerException);
                var resultEmploye = employeStatus.Result;
                ResponseEmployesModel response = new ResponseEmployesModel();
                if (resultEmploye != null)
                {
                    response.message = resultEmploye.message;
                    response.Employe = resultEmploye.data;
                    response.status = resultEmploye.status;
                }

                return response;
            }
            catch 
            {

                throw;
            }
        }

        private ResponseEmployesModel GetEmployes()
        {
            try
            {
                var employeStatus = _employe.GetEmployes();
                while (!employeStatus.IsCompleted) { }
                if (employeStatus.Status == TaskStatus.Faulted)
                    throw new Exception(employeStatus.Exception.Message, employeStatus.Exception.InnerException);
                var resultEmploye = employeStatus.Result;
                ResponseEmployesModel response = new ResponseEmployesModel();
                if (resultEmploye != null)
                {
                    response.message = resultEmploye.message;
                    response.Employes = resultEmploye.data;
                    response.status = resultEmploye.status;
                }

                return response;
            }
            catch 
            {

                throw;
            }
        }
    }
}