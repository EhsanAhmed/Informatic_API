using Informatic_API.DTO;
using Informatic_API.Interfaces;
using Informatic_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Informatic_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IRepository phoneRepository;
        private readonly Context context;
        private new readonly UserManager<ApplicationUser> User;

        public PhoneNumberController(IRepository _phoneRepository, Context context,UserManager<ApplicationUser> user)
        {
            this.phoneRepository = _phoneRepository;
            this.context = context;
            this.User = user;
        }
        [HttpGet("GetAllNumbers")]
        public async Task<IActionResult> GetAllNumbers()
        {
            List<PhoneNumber> phones = phoneRepository.GetAll();
            return Ok(phones);
        }

        [HttpGet("getByPhoneNumber")]
        public IActionResult getByPhoneNumber(string phoneNum)
        {
            PhoneNumber phone = phoneRepository.GetOneByPhoneNumber(phoneNum);
            if (phone == null)
            {
                return BadRequest("Empty ");
            }
            return Ok(phone);
        }


        [HttpPost("CreateNew")]
        public async Task<IActionResult> CreateNew([FromForm] PhoneNumberDTO phone)
        {
           
            PhoneNumber newPhone = new PhoneNumber()
            {
                Name = phone.Name,
                Phone_Number = phone.PhoneNumber
            };
            if (ModelState.IsValid)
            {
                try
                {
                    phoneRepository.Insert(newPhone);

                   
                    return Ok(phone);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }

        [HttpPut("EditByPhoneNumber")]
        public async Task<IActionResult> EditByPhoneNumber(string PhoneNum, [FromForm] PhoneNumberDTO phone)
        {

            PhoneNumber newPhone = new PhoneNumber()
            {
                Name = phone.Name,
                Phone_Number = phone.PhoneNumber
            };
            if (ModelState.IsValid)
            {
                try
                {
                    phoneRepository.Update(PhoneNum, newPhone);

                    return StatusCode(204, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("Delete")]
        public IActionResult Delete(string PhoneNum)
        {
            phoneRepository.Delete(PhoneNum);
            return Ok("one Item Deleted successfully");
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            long ph;
            bool success = long.TryParse(name, out ph);
            if (!success)
            {

                List<PhoneNumber> phones = phoneRepository.GetByName(name);
                return Ok(phones);
            }
            else
            {
                PhoneNumber phone = phoneRepository.GetOneByPhoneNumber(name);

                return Ok(phone);

            }

        }
    }
}
