using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DamoModels.CustomModels;

namespace BlazorApp1.Services
{
    public class EmpService:IEmpService
    {
        private readonly HttpClient httpClient;
        public EmpService(HttpClient _httpClient)
        {
           this.httpClient = _httpClient;
        }

        public async Task<List<Employe>> GetEmployes()
        {
            return await httpClient.GetFromJsonAsync<List<Employe>>("api/Employe/GetEmployes");
        }

        public async Task<ResponseModel> AddNewEmploye(Employe employe)
        {
            var response = await httpClient.PostAsJsonAsync("api/Employe/AddNewEmploye", employe);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }



        public async Task<ResponseModel> UpdateEmployes(Employe employe)
        {
            var response = await httpClient.PostAsJsonAsync("api/Employe/UpdateEmployes", employe);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }




        public async Task<ResponseModel> DeleteEmploye(int employeId)
        {
            var response = await httpClient.DeleteAsync($"api/Employe/DeleteEmploye/{employeId}");
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }


    }
}




