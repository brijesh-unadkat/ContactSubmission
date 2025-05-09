using ContactSubmit.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactSubmit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSubmit.Infrastructure
{
    public class ContactService
    {
        private readonly DatabaseContext _databaseContext;
        public ContactService(DatabaseContext dbContext) { 
            _databaseContext = dbContext;
        }

        
        public async Task<bool> AddContact(ContactModel addContact)
        {
            //Check for duplicate email id
            bool isEmailExists = _databaseContext.Contact.Where(x=>x.EmailAddress.ToLower() == addContact.EmailAddress.ToLower())?.FirstOrDefault() != null;
            bool isPhoneExists = _databaseContext.Contact.Where(x => x.PhoneNumber.ToLower() == addContact.PhoneNumber.ToLower())?.FirstOrDefault() != null;
            if (isEmailExists || isPhoneExists)
            {
                return false;
            }
            else
            {
                _databaseContext.Contact.Add(addContact);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
        }

        
        public IEnumerable<ContactModel> GetContacts()
        {
            var data = _databaseContext.Contact;
            return data.ToArray();
        }
       
    }
}
