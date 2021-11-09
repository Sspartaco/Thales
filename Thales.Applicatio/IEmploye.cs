using Thales.Entities.Entities;

namespace Thales.Applicatio
{
    public interface IEmploye
    {
        public Task<ResponseEmployes> GetEmployes();

        public Task<ResponseEmploye> GetEmployeById(int id);
    }
}