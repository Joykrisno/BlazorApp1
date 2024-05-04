using DamoModels.CustomModels;
using DamoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IEmployeService
    {

        List<EmployeInfo> GetEmployes();

        ResponseModel AddNewEmploye( EmployeInfo Info);

       // ResponseModel UpdateEmploye();
        ResponseModel DeleteEmployes(int employeId);

    }
}
