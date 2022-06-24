using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public CarController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }


        [HttpPost("SaveCar")]
        public IActionResult SaveCar(SaveCarDTO car)
        {
            Car newcar = new Car();
            try
            {
                newcar.Price = car.Price;
                newcar.Officies = _rentaCarContext.Officies.FirstOrDefault(o => o.Id == car.OfficiesID);
                newcar.CarModal = _rentaCarContext.CarModals.FirstOrDefault(c => c.Id == car.CarModalID);
                newcar.TransmissionType = _rentaCarContext.TransmissionTypes.FirstOrDefault(t => t.Id == car.TransmissionID);
                newcar.FuelType = _rentaCarContext.FuelTypes.FirstOrDefault(f => f.Id == car.FuelTypeID);
                newcar.Classification = _rentaCarContext.Classifications.FirstOrDefault(b => b.Id == car.ClassificationID);


                _rentaCarContext.Cars.Add(newcar);
                _rentaCarContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(newcar);
        }

        [HttpGet("UpdateCar")]
        public IActionResult UpdateCar(int id)
        {

            var selectedCar = _rentaCarContext.Cars.Where(c => c.Id == id).Select(o => new Car()
            {
                Id = o.Id,
                Price = o.Price,
                Officies = o.Officies,
                CarModal = o.CarModal,
                FuelType = o.FuelType,
                TransmissionType = o.TransmissionType,
                Classification = o.Classification,
            }).FirstOrDefault();

            Car updateCar = new Car();

            updateCar.Id = selectedCar.Id;
            updateCar.Price = selectedCar.Price;
            updateCar.Officies = selectedCar.Officies;
            updateCar.CarModal = selectedCar.CarModal;
            updateCar.TransmissionType = selectedCar.TransmissionType;
            updateCar.FuelType = selectedCar.FuelType;
            updateCar.Classification = selectedCar.Classification;


            return Ok(updateCar);
        }

        [HttpPost("UpdatedCar")]
        public IActionResult UpdatedCar(SaveCarDTO car, int id)
        {

            var updatedCar = _rentaCarContext.Cars.SingleOrDefault(c => c.Id == id);

            updatedCar.Price = car.Price;
            updatedCar.Officies = _rentaCarContext.Officies.FirstOrDefault(o => o.Id == car.OfficiesID);
            updatedCar.CarModal = _rentaCarContext.CarModals.FirstOrDefault(c => c.Id == car.CarModalID);
            updatedCar.TransmissionType = _rentaCarContext.TransmissionTypes.FirstOrDefault(t => t.Id == car.TransmissionID);
            updatedCar.FuelType = _rentaCarContext.FuelTypes.FirstOrDefault(f => f.Id == car.FuelTypeID);
            updatedCar.Classification = _rentaCarContext.Classifications.FirstOrDefault(b => b.Id == car.ClassificationID);


            _rentaCarContext.Cars.Update(updatedCar);
            _rentaCarContext.SaveChanges();

            return Ok(updatedCar);
        }

        [HttpDelete("DeleteCar")]
        public IActionResult CarDelete(int id)
        {

            var deletedCar = _rentaCarContext.Cars
                                   .Where(b => b.Id == id).Include(c => c.Officies)
                                                          .Include(c => c.CarModal)
                                                          .Include(c => c.TransmissionType)
                                                          .Include(c => c.FuelType)
                                                          .Include(c => c.Classification)
                                                            .FirstOrDefault();


            _rentaCarContext.Cars.Remove(deletedCar);
            _rentaCarContext.SaveChanges();
            return Ok(deletedCar);

        }
    }
}
