using DamoModels.CustomModels;
using DamoModels.Models;

namespace DamoApi.Controllers
{
    public interface IEmployeService
    {

         List<EmployeInfo> GetEmployes();
        ResponseModel DeleteEmployes(int employeId);

        ResponseModel AddNewEmploye(EmployeInfo info);


        ResponseModel UpdateEmploye();
    }
}