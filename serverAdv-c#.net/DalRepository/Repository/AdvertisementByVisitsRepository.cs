using DalRepository.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalRepository.Repository
{
    public class AdvertisementByVisitsRepository
    {
        public async Task<List<AdvertisementByVisits>> SelectAllAsync()

        {
            try
            {
                using (AdvContext db = new AdvContext())
                {
                  
                    return await db.AdvertisementByVisits.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task add(AdvertisementByVisits adv)
        {
            try
            {
                using (AdvContext db = new AdvContext())
                {
                    db.AdvertisementByVisits.Add(adv);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex) { throw; }
        }
        public async Task update(AdvertisementByVisits adv)
        {
            try
            {
                using (AdvContext db = new AdvContext())
                {
                    AdvertisementByVisits advold = await db.AdvertisementByVisits.FindAsync(adv.Id);
                    if (advold == null)
                    {
                        throw new Exception($"Advertisement with email {adv.Email} not found.");
                    }
                    advold.VisitsSoFar = adv.VisitsSoFar;
                    advold.Status = adv.Status;
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
