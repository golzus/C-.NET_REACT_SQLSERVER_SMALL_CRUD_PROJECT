using DalRepository.models;
using DTO_Enteties_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Services.IServices
{
  public  interface  UserIService
    {
        Task <List<UserDTO>> GetUsersAsync();
        Task <bool> getUserByIdAsync(UserDTO user);
        Task<bool> addAsync(UserDTO user);
        UserDTO ConvertToDTO(User user);
        User ConvertToDALL(UserDTO user);
       
    }
}
