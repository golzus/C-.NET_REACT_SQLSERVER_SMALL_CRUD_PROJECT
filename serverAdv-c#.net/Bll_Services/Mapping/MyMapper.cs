using AutoMapper;
using DalRepository.models;
using DTO_Enteties_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bll_Services.Mapping
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<AdvertisementByVisitsDTO, AdvertisementByVisits>();
            CreateMap<AdvertisementByVisits, AdvertisementByVisitsDTO>();
        }
    }
}
