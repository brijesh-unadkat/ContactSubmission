using ContactSubmit.Domain.Models;
using ContactSubmit.Infrastructure;
using ContactSubmit.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactSubmit.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;
       

        private readonly ILogger<ContactController> _logger;

        public ContactController(ContactService contactService, ILogger<ContactController> logger)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// This method is use for Get all contacts from Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetContactDetails")]
        public IActionResult GetContacts()
        {
            var data = _contactService.GetContacts();
            return Ok(data.ToArray());
        }

        [HttpPost]
        [Route("SaveContactDetails") ]
        public async Task<IActionResult> PostContact(ContactModel contact)
        {
            try
            {
               if(await _contactService.AddContact(contact))
               { return Ok(); }
               else { return BadRequest(); }    
               
                
            }
            catch(Exception e)
            {
                return null;
            }
        }

        

        
    }
}
