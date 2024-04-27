using DamoModels.Models;

namespace DamoApi.Controllers
{
    public interface IEmployeService
    {

        List<EmployeInfo> GetEmployes();
    }
}