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
            //List<EmployeInfo> employeInfos = new List<EmployeInfo>();
            //foreach (var c in data)
            //{
            //    EmployeInfo employe = new EmployeInfo();
            //    employe.Id = c.Id;
            //    employe.Name = c.Name;
            //    employeInfos.Add(employe);

            //}
            return data;
        }

        public ResponseModel AddNewEmploye (EmployeInfo Info)
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
                    _dbContext.EmployeInfos.Add(data);
                    _dbContext.SaveChanges();
                }


                response.Status = true;
                response.Message = "Sucess";
                return response;
            }
            catch (Exception ex)
            {
                ResponseModel response = new ResponseModel();
                response.Status = false;
                response.Message = "An error occurred: " + ex.Message;
                return response;
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
                    _dbContext.EmployeInfos.Update(data);
                    _dbContext.SaveChanges();

                    response.Status = true;
                    response.Message = "Sucess";
                }

                else
                {
                    response.Status = false;
                    response.Message =  "Employe Not Exit";
                }
              
                return response;
            }
            catch (Exception ex)
            {
                ResponseModel response = new ResponseModel();
                response.Status = false;
                response.Message = "An error occurred: " + ex.Message;
                return response;
            }

        }


        public ResponseModel DeleteEmploye(int  employeId)
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
                ResponseModel response = new ResponseModel();
                response.Status = false;
                response.Message = "An error occurred: " + ex.Message;
                return response;
            }

        }

    }
}
