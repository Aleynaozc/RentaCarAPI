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
    public class CarModalController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public CarModalController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }

        [HttpGet("CarModalList")]
        public async Task<List<CarModal>> CarModalList()
        {
            return await _rentaCarContext.CarModals.Select(cm => new CarModal()
            {
                Id=cm.Id,
                Name = cm.Name,
                ImgURL = cm.ImgURL,
                ImgURL2 = cm.ImgURL2,
                Brand = cm.Brand

            }).ToListAsync();
        }
        [HttpPost("SaveCarModal")]
        public IActionResult SaveCarModal(SaveCarModalDTO carModal)
        {

            CarModal newcarmodal = new CarModal();
            newcarmodal.Name = carModal.Name;
            newcarmodal.ImgURL = carModal.ImgURL;
            newcarmodal.ImgURL2 = carModal.ImgURL2;
            newcarmodal.Brand = _rentaCarContext.Brands.SingleOrDefault(b => b.Id == carModal.BrandId);


            _rentaCarContext.CarModals.Add(newcarmodal);
            _rentaCarContext.SaveChanges();
            return Ok(newcarmodal);
        }

        [HttpGet("UpdateCarModal")]
        public IActionResult UpdateCarModal(int id)
        {
            var selectedCarModal = _rentaCarContext.CarModals.Where(c => c.Id == id).Select(o => new CarModal()
            {
                Id = o.Id,
                Name = o.Name,
                ImgURL = o.ImgURL,
                ImgURL2 = o.ImgURL2,
                Brand = o.Brand

            }).FirstOrDefault();

            CarModal updateCarModal = new CarModal();

            updateCarModal.Id = selectedCarModal.Id;
            updateCarModal.Name = selectedCarModal.Name;
            updateCarModal.ImgURL = selectedCarModal.ImgURL;
            updateCarModal.ImgURL2 = selectedCarModal.ImgURL2;
            updateCarModal.Brand = selectedCarModal.Brand;

            return Ok(updateCarModal);
        }

        [HttpPost("UpdatedCarModal")]
        public IActionResult UpdatedCarModal(SaveCarModalDTO carmodal, int id)
        {

            var updatedCarModal = _rentaCarContext.CarModals.SingleOrDefault(c => c.Id == id);

            updatedCarModal.Name = carmodal.Name;
            updatedCarModal.ImgURL = carmodal.ImgURL;
            updatedCarModal.ImgURL2 = carmodal.ImgURL2;
            updatedCarModal.Brand = _rentaCarContext.Brands.FirstOrDefault(o => o.Id == carmodal.BrandId);


            _rentaCarContext.CarModals.Update(updatedCarModal);
            _rentaCarContext.SaveChanges();

            return Ok(updatedCarModal);
        }

        [HttpDelete("DeleteCarModal")]
        public IActionResult DeleteCarModal(int id)
        {

            var deletedCarModal = _rentaCarContext.CarModals
                                   .Where(b => b.Id == id).Include(c => c.Brand)
                                                            .FirstOrDefault();


            _rentaCarContext.CarModals.Remove(deletedCarModal);
            _rentaCarContext.SaveChanges();
            return Ok(deletedCarModal);

        }
    }
}
