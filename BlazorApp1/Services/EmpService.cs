using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DamoModels.CustomModels;

namespace BlazorApp1.Services
{
    public class EmpService:IEmpService
    {
        private readonly HttpClient _httpClient;
        public EmpService(HttpClient httpClient)
        {
           this._httpClient = httpClient;
        }

        public async Task<List<Employe>> GetEmployes()
        {
            return await _httpClient.GetFromJsonAsync<List<Employe>>("api/Employe/GetEmployes");
        }

        public  async Task<ResponseModel>AddNewEmploye(Employe employe)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employe/AddNewEmploye",employe);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }


        public async Task<ResponseModel> UpdateEmploye(Employe employe)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employe/UpdateEmploye", employe);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }




        public async Task<ResponseModel> DeleteEmploye(int employeId)
        {
            var response = await _httpClient.DeleteAsync($"api/Employe/DeleteEmploye/{employeId}");
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }


    }
}




