using Bll_Services.IServices;
using Bll_Services.Services;
using DalRepository.models;
using DalRepository.Repository;
using DTO_Enteties_Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [ApiController]
    [Route("advertisement/byVisits")]
    public class AdvertisementByVisitController : Controller

    {
        //AdvertisementByVisitsService _service = new AdvertisementByVisitsService();

        private AdvertisementByVisitsService _service;

        public AdvertisementByVisitController(AdvertisementByVisitsService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public Task<bool> Add([FromBody] AdvertisementByVisitsDTO adv)
        {

            return _service.AddAsync(adv);
            //return Ok(result);


        }

        [HttpPost("currentAdv/{location}")]
        public IActionResult CurrentAdv([FromRoute] string location)
        {
            var result = _service.placeCurrent(location);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var result = await _service.GetAll();
            var result = _service.GetAllActive();
            return Ok(result);
        }
    }

}
