using DalRepository.models;
using DTO_Enteties_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Services.IServices
{
    public interface AdvertisementByVisitsIService
    {
      
        Task<List<AdvertisementByVisitsDTO>> GetAll();
        List<AdvertisementByVisitsDTO> GetAllActive();
        Task<bool> AddAsync(AdvertisementByVisitsDTO adv);
        string placeCurrent(string location);
        AdvertisementByVisitsDTO ConvertToDTO(AdvertisementByVisits adv);
        AdvertisementByVisits convertToDALL(AdvertisementByVisitsDTO adv);
    }
}
