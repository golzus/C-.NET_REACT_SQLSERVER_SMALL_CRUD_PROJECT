﻿using AutoMapper;
using Bll_Services.IServices;
using DalRepository.models;
using DalRepository.Repository;
using DTO_Enteties_Common;
using System.Collections.Generic;
using System.Threading.Tasks;



//List<AdvertisementByVisitsDTO> GetAllActive();
//string placeCurrent(string location);


namespace Bll_Services.Services
{
    public class AdvertisementByVisitsService : AdvertisementByVisitsIService
    {
        private readonly AdvertisementByVisitsRepository _rep;
        private readonly IMapper _mapper;

        public AdvertisementByVisitsService(AdvertisementByVisitsRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(AdvertisementByVisitsDTO adv)
        {
            adv.Status = true;
            adv.Email = "";
            adv.VisitsSoFar = 0;
            var entity = _mapper.Map<AdvertisementByVisits>(adv);
            await _rep.add(entity);
            return true;
        }

        public async Task<List<AdvertisementByVisitsDTO>> GetAll()
        {
            var list = await _rep.SelectAllAsync();
            return _mapper.Map<List<AdvertisementByVisitsDTO>>(list);
        }


        public string placeCurrent(string location)
        {
            string str = "";

            List<AdvertisementByVisitsDTO> list = new List<AdvertisementByVisitsDTO>();
            list = GetAll().Result;
            foreach (AdvertisementByVisitsDTO adv in list)
            {
                if (adv.Location == location && adv.Status)
                {
                    if (adv.DesiredVisits - adv.VisitsSoFar <= 0)
                    {
                        adv.Status = false;
                        str = "";
                        _rep.update(_mapper.Map<AdvertisementByVisits>(adv));
                    }
                    else
                        str = adv.Path;
                }
            }
            return str;
        }

        public List<AdvertisementByVisitsDTO> GetAllActive()
        {
            List<AdvertisementByVisitsDTO> listNew = new List<AdvertisementByVisitsDTO>();
            var list = GetAll().Result;
            foreach (var adv in list)
            {
                if (adv.DesiredVisits - adv.VisitsSoFar <= 0)
                {
                    adv.Status = false;
                    var entity = _mapper.Map<AdvertisementByVisits>(adv);
                    _rep.update(entity);
                }
                else
                {
                    adv.VisitsSoFar++;
                    var entity = _mapper.Map<AdvertisementByVisits>(adv);
                    _rep.update(entity);
                    listNew.Add(adv);
                }
            }
            return listNew;
        }
    }
}



//using Bll_Services.IServices;
//using DalRepository.models;
//using DalRepository.Repository;
//using DTO_Enteties_Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


//namespace Bll_Services.Services
//{
//    public class AdvertisementByVisitsService : AdvertisementByVisitsIService
//    {
//        private AdvertisementByVisitsRepository rep;
//        public AdvertisementByVisitsService(AdvertisementByVisitsRepository rep)
//        {
//            this.rep = rep;
//        }
//        //AdvertisementByVisitsRepository rep = new AdvertisementByVisitsRepository();
//        public async Task<bool> AddAsync(AdvertisementByVisitsDTO adv)
//        {

//            adv.Status = true;
//            adv.Email = "";
//            adv.VisitsSoFar = 0;
//            await rep.add(convertToDALL(adv));
//            return true;
//        }
//        public async Task<List<AdvertisementByVisitsDTO>> GetAll()
//        {

//            AdvertisementByVisitsRepository rep = new AdvertisementByVisitsRepository();
//            var list = await rep.SelectAllAsync();

//            return ConvertToDTOList(list);

//        }
//        private List<AdvertisementByVisitsDTO> ConvertToDTOList(List<AdvertisementByVisits> la)
//        {
//            //DTOהמרת אוסף ממבנה מסד הנתונים לאוסף מסוג 
//            List<AdvertisementByVisitsDTO> laNew = new List<AdvertisementByVisitsDTO>();
//            foreach (var item in la)
//            {
//                laNew.Add(ConvertToDTO(item));
//            }
//            return laNew;
//        }
//        public AdvertisementByVisitsDTO ConvertToDTO(AdvertisementByVisits adv)
//        {
//            AdvertisementByVisitsDTO dtoAdv = new AdvertisementByVisitsDTO();
//            dtoAdv.Id = adv.Id;
//            dtoAdv.Status = adv.Status;
//            dtoAdv.Location = adv.Location;
//            dtoAdv.Path = adv.Path;
//            dtoAdv.Email = adv.Email;
//            dtoAdv.DesiredVisits = adv.DesiredVisits;
//            dtoAdv.VisitsSoFar = adv.VisitsSoFar;
//            return dtoAdv;
//        }
//        public AdvertisementByVisits convertToDALL(AdvertisementByVisitsDTO adv)
//        {
//            AdvertisementByVisits dalAdv = new AdvertisementByVisits();
//            dalAdv.Id = adv.Id;
//            dalAdv.Status = adv.Status;
//            dalAdv.Location = adv.Location;
//            dalAdv.Path = adv.Path;
//            dalAdv.Email = adv.Email;
//            dalAdv.DesiredVisits = adv.DesiredVisits;
//            dalAdv.DesiredVisits = adv.DesiredVisits;
//            dalAdv.VisitsSoFar = adv.VisitsSoFar;
//            return dalAdv;
//        }

//        public string placeCurrent(string location)
//        {
//            string str = "";

//            List<AdvertisementByVisitsDTO> list = new List<AdvertisementByVisitsDTO>();
//            list = GetAll().Result;
//            foreach (AdvertisementByVisitsDTO adv in list)
//            {
//                if (adv.Location == location && adv.Status)
//                {
//                    if (adv.DesiredVisits - adv.VisitsSoFar <= 0)
//                    {
//                        adv.Status = false;
//                        str = "";
//                        rep.update(convertToDALL(adv));
//                    }
//                    else
//                        str = adv.Path;
//                }
//            }
//            return str;
//        }
//        public List<AdvertisementByVisitsDTO> GetAllActive()
//        {
//            List<AdvertisementByVisitsDTO> list = new List<AdvertisementByVisitsDTO>();
//            GetAll().Result.ForEach(a =>
//            {
//                {
//                    if ((a.DesiredVisits - a.VisitsSoFar) <= 0)
//                    {
//                        a.Status = false;
//                        rep.update(convertToDALL(a));
//                    }
//                    else
//                    {
//                        a.VisitsSoFar = a.VisitsSoFar+1;
//                        rep.update(convertToDALL(a));
//                        list.Add(a);

//                    }
//                }
//            }
//                );
//            return list;
//        }


//    }
//}