using ProyectoFinalXamarin.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalXamarin.Services
{
    public interface IMedicalApiService
    {
        Task<Suggest> GetSuggestAsync();
        Task<OutCome> GetOutcomesAsync();

        [Get("/v1/dx/GetOutcomes")]
        Task<Disease> GetDiseasesAsync();
    }
}
