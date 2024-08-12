//using Bll_Services.IServices;
//using DalRepository.models;
//using DalRepository.Repository;
//using DTO_Enteties_Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bll_Services.Services
//{
//    public class UserService : UserIService
//    {
//        private UserRepository rep;
//        //Task<List<UserDTO>> GetUsersAsync();
//        //UserRepository rep=new UserRepository();
//        public UserService(UserRepository rep)
//        {
//            this.rep = rep;
//        }
//        public async Task<bool> addAsync(UserDTO user)
//        {

//            await rep.add(ConvertToDALL(user));
//            return true;
//        }

//        public User ConvertToDALL(UserDTO user)
//        {
//            User dall = new User();
//            dall.Email = user.Email;
//            dall.Password = user.Password;
//            return dall;
//        }



//        public UserDTO ConvertToDTO(User user)
//        {
//            UserDTO dto = new UserDTO();
//            dto.Email = user.Email;
//            dto.Password = user.Password;
//            return dto;
//        }

//        public Task<bool> getUserByIdAsync(UserDTO user)
//        {
//            string email = user.Email;
//            return rep.find(email);

//        }

//        public async Task<List<UserDTO>> GetUsersAsync()
//        {

//            var users = await rep.SelectAllAsync();


//            var userDTOs = ConvertToDTOList(users);

//            return userDTOs;

//        }



//        private List<UserDTO> ConvertToDTOList(List<User> userList)
//        {
//            //DTOהמרת אוסף ממבנה מסד הנתונים לאוסף מסוג 
//            List<UserDTO> userDtoList = new List<UserDTO>();
//            foreach (User user in userList)
//            {
//                userDtoList.Add(ConvertToDTO(user));
//            }

//            return userDtoList;
//        }
//    }
//}





using AutoMapper;
using Bll_Services.IServices;
using DalRepository.models;
using DalRepository.Repository;
using DTO_Enteties_Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bll_Services.Services
{




    public class UserService : UserIService
    {
        private readonly UserRepository rep;
        private readonly IMapper _mapper;

        public UserService(UserRepository rep, IMapper mapper)
        {
            this.rep = rep;
            this._mapper = mapper;
        }

        public async Task<bool> addAsync(UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
           return await rep.add(userEntity);
          
        }

        public async Task<bool> getUserByIdAsync(UserDTO user)
        {
            string email = user.Email;
            return await rep.find(email);
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await rep.SelectAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
