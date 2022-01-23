using Business.Abstract;
using Entities.Concrete;
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
    public class CarsController : ControllerBase
    {

        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getcardetailsbycarid")]
        public IActionResult GetCarDetailsByCarId(int carId)
        {
            var result = _carService.GetCarDetailsByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("getcarsbybrandidwithdetails")]
        public IActionResult GetCarsByBrandIdWithDetails(int brandId)
        {
            var result = _carService.GetCarsByBrandIdWithDetails(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }



        [HttpGet("getcarsbycoloridwithdetails")]
        public IActionResult GetCarsByColorIdWithDetails(int colorId)
        {
            var result = _carService.GetCarsByColorIdWithDetails(colorId);


            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
