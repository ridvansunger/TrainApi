using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainApi.Models;

namespace TrainApi.Controllers
{
    using Business;

    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
      


        [HttpPost("trains")]
        public IActionResult Rezervation(RezervasyonBilet rezervationBilet)
        {
            if (rezervationBilet == null)
            {
                return BadRequest("Nesne boş gönderilemez");
            }
    
            return Ok(new RezervationBusiness(rezervationBilet).Rezervation());
        }


    

    }
}
