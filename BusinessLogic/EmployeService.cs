using DamoModels.CustomModels;
using DamoModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeService : IEmployeService
    {
        private readonly EmployeDbContext _dbContext;
        public EmployeService(EmployeDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public List<EmployeInfo> GetEmployes()
        {
            var data = _dbContext.EmployeInfos.ToList();        
            return data;
        }

        //public ResponseModel AddNewEmploye(EmployeInfo Info)
        //{
        //    ResponseModel response = new ResponseModel();

        //    try
        //    {
        //        var data = _dbContext.EmployeInfos.FirstOrDefault(x => x.Id == Info.Id);

        //        if (data != null)
        //        {
        //            data.Name = Info.Name;
        //            data.Company = Info.Company;
        //            data.YearoffExprience = Info.YearoffExprience;
        //            _dbContext.SaveChanges();
        //        }

        //        response.Status = true;
        //        response.Message = "Success";
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        // Consider returning a meaningful error message
        //        response.Status = false;
        //        response.Message = "An error occurred while updating the employee.";
        //    }

        //    return response;
        //}



        public ResponseModel AddNewEmploye(EmployeInfo Info)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbContext.EmployeInfos.Where(x => x.Id == Info.Id).FirstOrDefault();
                if (data == null)
                {
                    //data.Name = Info.Name;
                    //data.Company = Info.Company;
                    //data.YearoffExprience = Info.YearoffExprience;
                    _dbContext.EmployeInfos.Add(Info);
                    _dbContext.SaveChanges();

                    response.Status = true;
                    response.Message = "Sucess";
                }

                else
                {
                    response.Status = false;
                    response.Message = "Employe Not Exit";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public ResponseModel UpdateEmploye(EmployeInfo Info)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbContext.EmployeInfos.Where(x => x.Id == Info.Id).FirstOrDefault();
                if (data != null)
                {
                    data.Name = Info.Name;
                    data.Company = Info.Company;
                    data.YearoffExprience = Info.YearoffExprience;
                    _dbContext.EmployeInfos.Update(Info);
                    _dbContext.SaveChanges();

                    response.Status = true;
                    response.Message = "Sucess";
                }

                else
                {
                    response.Status = false;
                    response.Message = "Employe Not Exit";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public ResponseModel DeleteEmployes(int  employeId)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbContext.EmployeInfos.Where(x => x.Id == employeId).FirstOrDefault();
                if (data != null)
                {
                   
                    _dbContext.EmployeInfos.Remove(data);
                    _dbContext.SaveChanges();

                    response.Status = true;
                    response.Message = "Sucess";
                }

                else
                {
                    response.Status = false;
                    response.Message = "Employe Not Exit";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

      
    }
}
