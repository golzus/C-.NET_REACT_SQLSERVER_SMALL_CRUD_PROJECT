using DalRepository.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DalRepository.Repository
{
    public class UserRepository
    {
        public async Task<List<User>> SelectAllAsync()
        {
            try
            {
                using (AdvContext db = new AdvContext())
                {
                    return await db.Users.ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> add(User user)
        {
            try
            {
                using (AdvContext db = new AdvContext())
                {

                    db.Users.AddAsync(user);
                    var changes = await db.SaveChangesAsync();
                    return changes > 0;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //private User User(object user)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> find(string email)
        {
            try
            {
                using (AdvContext db = new AdvContext())
                {
                  User user=  await db.Users.FindAsync(email);
                    return user==null?false:true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}