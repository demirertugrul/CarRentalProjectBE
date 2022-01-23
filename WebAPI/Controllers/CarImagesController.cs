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
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile formFile, [FromForm] CarImage carImages)
        {
            var result = _carImageService.Add(formFile, carImages);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImages)
        {
            var result = _carImageService.Delete(carImages);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile formFile, [FromForm] CarImage carImages)
        {
            var result = _carImageService.Update(formFile, carImages);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int id)
        {
            var result = _carImageService.GetByImageId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }



        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}