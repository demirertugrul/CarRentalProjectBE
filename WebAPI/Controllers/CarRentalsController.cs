using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalsController : ControllerBase
    {

        ICarRentalService _carRentalService;
        public CarRentalsController(ICarRentalService carRentalService)
        {
            _carRentalService = carRentalService;
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _carRentalService.getRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _carRentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
