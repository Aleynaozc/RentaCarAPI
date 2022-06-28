using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public AdminController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }

        [HttpGet("UserList")]
        public async Task<List<User>> Get()
        {
            return await _rentaCarContext.Users.Select(u => new User()
            {
                Id=u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Password = u.Password
            }).ToListAsync();
        }
        [HttpGet("UpdateUser")]
        public IActionResult UpdateUser(int id)
        {
            var selectedUser = _rentaCarContext.Users.Where(t => t.Id == id).Select(o => new User()
            {
                Id = o.Id,
                FullName = o.FullName,
                Email = o.Email,
            }).FirstOrDefault();

            return Ok(selectedUser);
        }

        [HttpPost("UpdatedUser")]
        public IActionResult UpdatedUser([FromBody] SaveUserDTO user, int id)
        {
            var updatedUser = _rentaCarContext.Users.SingleOrDefault(t => t.Id == id);
            updatedUser.FullName = user.FullName;
            updatedUser.Email = user.Email;
            _rentaCarContext.Users.Update(updatedUser);
            _rentaCarContext.SaveChanges();
            return Ok(updatedUser);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {

            var deletedUser = _rentaCarContext.Users
                                   .Where(b => b.Id == id)
                                   .FirstOrDefault();


            _rentaCarContext.Users.Remove(deletedUser);
            _rentaCarContext.SaveChanges();
            return Ok(deletedUser);

        }
        [HttpGet("AllCars")]
        public async Task<List<Car>> ListCar()
        {
            return await _rentaCarContext.Cars
                                        .Select(o => new Car()
                                        {
                                            Id = o.Id,
                                            Price = o.Price,
                                            Officies = o.Officies,
                                            CarModal = o.CarModal,
                                            FuelType = o.FuelType,
                                            TransmissionType = o.TransmissionType,
                                            Classification = o.Classification,
                                        }).ToListAsync();


        }

        //[HttpPost("SaveOfficies")]
        //public IActionResult SaveOfficies(SaveOfficiesDTO officies)
        //{
        //    var newofficies = new Officies
        //    {
        //        Name = officies.Name,
        //        City = officies.City
        //    };
        //    _rentaCarContext.Officies.Add(newofficies);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(newofficies);
        //}

        //[HttpGet("UpdateOfficies")]
        //public IActionResult UpdateOfficies(int id)
        //{
        //    var selectedOfficies = _rentaCarContext.Officies.Where(o => o.Id == id).Select(o => new Officies()
        //    {
        //        Id = o.Id,
        //        Name = o.Name,
        //        City=o.City
        //    }).FirstOrDefault();

        //    return Ok(selectedOfficies);
        //}

        //[HttpPost("UpdatedOfficies")]
        //public IActionResult UpdatedOfficies(SaveOfficiesDTO officies, int id)
        //{
        //    var updatedOfficies = _rentaCarContext.Officies.SingleOrDefault(o => o.Id == id);


        //    updatedOfficies.Name = officies.Name;
        //    updatedOfficies.City = officies.City;

        //    _rentaCarContext.Officies.Update(updatedOfficies);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(updatedOfficies);
        //}

        //[HttpDelete("DeleteOfficies")]
        //public IActionResult DeleteOfficies(int id)
        //{

        //    var deletedOfficies = _rentaCarContext.Officies
        //                           .Where(b => b.Id == id).FirstOrDefault();


        //    _rentaCarContext.Officies.Remove(deletedOfficies);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(deletedOfficies);

        //}

        //[HttpPost("SaveCar")]
        //public IActionResult SaveCar(SaveCarDTO car)
        //{
        //    Car newcar = new Car();
        //    try
        //    {
        //        newcar.Price = car.Price;
        //        newcar.Officies = _rentaCarContext.Officies.FirstOrDefault(o => o.Id == car.OfficiesID);
        //        newcar.CarModal = _rentaCarContext.CarModals.FirstOrDefault(c => c.Id == car.CarModalID);
        //        newcar.TransmissionType = _rentaCarContext.TransmissionTypes.FirstOrDefault(t => t.Id == car.TransmissionID);
        //        newcar.FuelType = _rentaCarContext.FuelTypes.FirstOrDefault(f => f.Id == car.FuelTypeID);
        //        newcar.Classification = _rentaCarContext.Classifications.FirstOrDefault(b => b.Id == car.ClassificationID);


        //        _rentaCarContext.Cars.Add(newcar);
        //        _rentaCarContext.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //    return Ok(newcar);
        //}

        //[HttpGet("UpdateCar")]
        //public IActionResult UpdateCar(int id)
        //{

        //    var selectedCar = _rentaCarContext.Cars.Where(c => c.Id == id).Select(o => new Car()
        //    {
        //        Id = o.Id,
        //        Price = o.Price,
        //        Officies = o.Officies,
        //        CarModal = o.CarModal,
        //        FuelType = o.FuelType,
        //        TransmissionType = o.TransmissionType,
        //        Classification = o.Classification,
        //    }).FirstOrDefault();

        //    Car updateCar = new Car();

        //    updateCar.Id = selectedCar.Id;
        //    updateCar.Price = selectedCar.Price;
        //    updateCar.Officies = selectedCar.Officies;
        //    updateCar.CarModal = selectedCar.CarModal;
        //    updateCar.TransmissionType = selectedCar.TransmissionType;
        //    updateCar.FuelType = selectedCar.FuelType;
        //    updateCar.Classification = selectedCar.Classification;


        //    return Ok(updateCar);
        //}

        //[HttpPost("UpdatedCar")]
        //public IActionResult UpdatedCar(SaveCarDTO car, int id)
        //{

        //    var updatedCar = _rentaCarContext.Cars.SingleOrDefault(c => c.Id == id);

        //    updatedCar.Price = car.Price;
        //    updatedCar.Officies = _rentaCarContext.Officies.FirstOrDefault(o => o.Id == car.OfficiesID);
        //    updatedCar.CarModal = _rentaCarContext.CarModals.FirstOrDefault(c => c.Id == car.CarModalID);
        //    updatedCar.TransmissionType = _rentaCarContext.TransmissionTypes.FirstOrDefault(t => t.Id == car.TransmissionID);
        //    updatedCar.FuelType = _rentaCarContext.FuelTypes.FirstOrDefault(f => f.Id == car.FuelTypeID);
        //    updatedCar.Classification = _rentaCarContext.Classifications.FirstOrDefault(b => b.Id == car.ClassificationID);


        //    _rentaCarContext.Cars.Update(updatedCar);
        //    _rentaCarContext.SaveChanges();

        //    return Ok(updatedCar);
        //}

        //[HttpDelete("DeleteCar")]
        //public IActionResult CarDelete(int id)
        //{

        //    var deletedCar = _rentaCarContext.Cars
        //                           .Where(b => b.Id == id).Include(c => c.Officies)
        //                                                  .Include(c => c.CarModal)
        //                                                  .Include(c => c.TransmissionType)
        //                                                  .Include(c => c.FuelType)
        //                                                  .Include(c => c.Classification)
        //                                                    .FirstOrDefault();


        //    _rentaCarContext.Cars.Remove(deletedCar);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(deletedCar);

        //}

        //[HttpPost("SaveCarModal")]
        //public IActionResult SaveCarModal(SaveCarModalDTO carModal)
        //{
           
        //    CarModal newcarmodal = new CarModal();
        //    newcarmodal.Name = carModal.Name;
        //    newcarmodal.ImgURL = carModal.ImgURL;
        //    newcarmodal.ImgURL2 = carModal.ImgURL2;
        //    newcarmodal.Brand = _rentaCarContext.Brands.SingleOrDefault(b => b.Id == carModal.BrandId);


        //    _rentaCarContext.CarModals.Add(newcarmodal);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(newcarmodal);
        //}

        //[HttpGet("UpdateCarModal")]
        //public IActionResult UpdateCarModal(int id)
        //{
        //    var selectedCarModal = _rentaCarContext.CarModals.Where(c => c.Id == id).Select(o => new CarModal()
        //    {
        //        Id = o.Id,
        //        Name = o.Name,
        //        ImgURL=o.ImgURL,
        //        ImgURL2=o.ImgURL2,
        //        Brand=o.Brand
                
        //    }).FirstOrDefault();

        //    CarModal updateCarModal = new CarModal();

        //    updateCarModal.Id = selectedCarModal.Id;
        //    updateCarModal.Name = selectedCarModal.Name;
        //    updateCarModal.ImgURL = selectedCarModal.ImgURL;
        //    updateCarModal.ImgURL2 = selectedCarModal.ImgURL2;
        //    updateCarModal.Brand = selectedCarModal.Brand;

        //    return Ok(updateCarModal);
        //}

        //[HttpPost("UpdatedCarModal")]
        //public IActionResult UpdatedCarModal(SaveCarModalDTO carmodal, int id)
        //{

        //    var updatedCarModal = _rentaCarContext.CarModals.SingleOrDefault(c => c.Id == id);

        //    updatedCarModal.Name = carmodal.Name;
        //    updatedCarModal.ImgURL = carmodal.ImgURL;
        //    updatedCarModal.ImgURL2 = carmodal.ImgURL2;
        //    updatedCarModal.Brand = _rentaCarContext.Brands.FirstOrDefault(o => o.Id == carmodal.BrandId);


        //    _rentaCarContext.CarModals.Update(updatedCarModal);
        //    _rentaCarContext.SaveChanges();

        //    return Ok(updatedCarModal);
        //}

        //[HttpDelete("DeleteCarModal")]
        //public IActionResult DeleteCarModal(int id)
        //{

        //    var deletedCarModal = _rentaCarContext.CarModals
        //                           .Where(b => b.Id == id).Include(c => c.Brand)
        //                                                    .FirstOrDefault();


        //    _rentaCarContext.CarModals.Remove(deletedCarModal);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(deletedCarModal);

        //}

        //[HttpPost("SaveBrand")]
        //public IActionResult SaveBrand(SaveBrandDTO brand)
        //{
        //    var newbrand = new Brand
        //    {
        //        Name = brand.Name
        //    };
        //    _rentaCarContext.Brands.Add(newbrand);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(newbrand);
        //}

        //[HttpGet("UpdateBrand")]
        //public IActionResult UpdateBrand(int id)
        //{
        //    var selectedBrand = _rentaCarContext.Brands.Where(c => c.Id == id).Select(o => new Brand()
        //    {
        //        Id = o.Id,
        //        Name = o.Name
        //    }).FirstOrDefault();

        //    return Ok(selectedBrand);
        //}

        //[HttpPost("UpdatedBrand")]
        //public IActionResult UpdatedBrand(SaveBrandDTO brand ,int id)
        //{
        //    var updatedBrand = _rentaCarContext.Brands.SingleOrDefault(b => b.Id == id);


        //    updatedBrand.Name = brand.Name;

        //    _rentaCarContext.Brands.Update(updatedBrand);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(updatedBrand);
        //}

        //[HttpDelete("DeleteBrand")]
        //public IActionResult DeleteBrand(int id)
        //{

        //    var deletedBrand = _rentaCarContext.Brands
        //                           .Where(b => b.Id == id).FirstOrDefault();


        //    _rentaCarContext.Brands.Remove(deletedBrand);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(deletedBrand);

        //}

        //[HttpPost("SaveTrasmissionType")]
        //public IActionResult SaveTrasmissionType(SaveTransmissionTypeDTO transmission)
        //{
        //    var newtransmissionType = new TransmissionType
        //    {
        //        Type = transmission.Type
        //    };
        //    _rentaCarContext.TransmissionTypes.Add(newtransmissionType);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(newtransmissionType);
        //}

        //[HttpGet("UpdateTransmissionType")]
        //public IActionResult UpdateTransmissionType(int id)
        //{
        //    var selectedTransmissionType = _rentaCarContext.TransmissionTypes.Where(t => t.Id == id).Select(o => new TransmissionType()
        //    {
        //        Id = o.Id,
        //        Type = o.Type
        //    }).FirstOrDefault();

        //    return Ok(selectedTransmissionType);
        //}

        //[HttpPost("UpdatedTransmissionType")]
        //public IActionResult UpdatedTransmissionType(SaveTransmissionTypeDTO transmission, int id)
        //{
        //    var updatedTransmissionType = _rentaCarContext.TransmissionTypes.SingleOrDefault(t => t.Id == id);


        //    updatedTransmissionType.Type = transmission.Type;

        //    _rentaCarContext.TransmissionTypes.Update(updatedTransmissionType);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(updatedTransmissionType);
        //}

        //[HttpDelete("DeleteTrasmissionType")]
        //public IActionResult DeleteTrasmissionType(int id)
        //{

        //    var deletedTrasmission = _rentaCarContext.TransmissionTypes
        //                           .Where(b => b.Id == id).FirstOrDefault();


        //    _rentaCarContext.TransmissionTypes.Remove(deletedTrasmission);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(deletedTrasmission);

        //}


        //[HttpPost("SaveFuelType")]
        //public IActionResult SaveFuelType(SaveFuelTypeDTO fuelType)
        //{
        //    var newfuelType = new FuelType
        //    {
        //        Type = fuelType.Type
        //    };
        //    _rentaCarContext.FuelTypes.Add(newfuelType);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(newfuelType);
        //}

        //[HttpGet("UpdateFuelType")]
        //public IActionResult UpdateFuelType(int id)
        //{
        //    var selectedFuelType = _rentaCarContext.FuelTypes.Where(f => f.Id == id).Select(o => new FuelType()
        //    {
        //        Id = o.Id,
        //        Type = o.Type
        //    }).FirstOrDefault();

        //    return Ok(selectedFuelType);
        //}

        //[HttpPost("UpdatedFuelType")]
        //public IActionResult UpdatedFuelType(SaveFuelTypeDTO fueltype, int id)
        //{
        //    var updatedFuelType = _rentaCarContext.FuelTypes.SingleOrDefault(f => f.Id == id);


        //    updatedFuelType.Type = fueltype.Type;

        //    _rentaCarContext.FuelTypes.Update(updatedFuelType);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(updatedFuelType);
        //}

        //[HttpDelete("DeleteFuelType")]
        //public IActionResult DeleteFuelType(int id)
        //{

        //    var deletedFuelType = _rentaCarContext.FuelTypes
        //                           .Where(b => b.Id == id).FirstOrDefault();


        //    _rentaCarContext.FuelTypes.Remove(deletedFuelType);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(deletedFuelType);

        //}

        //[HttpPost("SaveClassification")]
        //public IActionResult SaveClassification(SaveClassificationDTO clas)
        //{
        //    var newClassifification = new Classification
        //    {
        //        Type = clas.Type
        //    };
        //    _rentaCarContext.Classifications.Add(newClassifification);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(newClassifification);
        //}



        //[HttpGet("UpdateClassification")]
        //public IActionResult UpdateClassification(int id)
        //{
        //    var selectedClassification = _rentaCarContext.Classifications.Where(f => f.Id == id).Select(o => new Classification()
        //    {
        //        Id = o.Id,
        //        Type = o.Type
        //    }).FirstOrDefault();

        //    return Ok(selectedClassification);
        //}

        //[HttpPost("UpdatedClassification")]
        //public IActionResult UpdatedClassification(SaveFuelTypeDTO fueltype, int id)
        //{
        //    var updatedClassification = _rentaCarContext.Classifications.SingleOrDefault(f => f.Id == id);


        //    updatedClassification.Type = fueltype.Type;

        //    _rentaCarContext.Classifications.Update(updatedClassification);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(updatedClassification);
        //}

        //[HttpDelete("DeleteClassification")]
        //public IActionResult DeleteClassification(int id)
        //{

        //    var deletedClassification = _rentaCarContext.Classifications
        //                           .Where(b => b.Id == id).FirstOrDefault();


        //    _rentaCarContext.Classifications.Remove(deletedClassification);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(deletedClassification);

        //}
    }
}
