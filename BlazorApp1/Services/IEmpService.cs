using DamoModels.CustomModels;

namespace BlazorApp1.Services
{
    public interface IEmpService
    {
        Task<List<Employe>> GetEmployes();
        Task<ResponseModel> AddNewEmploye(Employe employe);
        Task<ResponseModel> UpdateEmploye(Employe employe);
        Task<ResponseModel> DeleteEmploye(int employeId);
    }
}
