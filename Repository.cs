using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sulakkhana_Contacts.Models;

namespace Sulakkhana_Contacts.BusinessLayer
{
    public class Repository
    {
        private ContactDB_SulakkhanaEntities context;

        public Repository(ContactDB_SulakkhanaEntities context)
        {
            this.context = context;
        }

        public int CreateContact(Contacts c)
        {
            return context.InsertContact(c.Name, c.Address, c.Tel, c.Mobile, c.Email, c.CountryID);
           
        }

        public int UpdateContact(Contacts c)
        {
            return context.UpdateContact(c.ContactID,c.Name, c.Address, c.Tel, c.Mobile, c.Email, c.CountryID);
        }

        public IEnumerable<Contacts> GetContacts()
        {
            return context.GetContacts().Select(c => new Contacts { ContactID = c.ContactID, Name = c.Name, Address = c.Address, Tel = c.Tel, Mobile = c.Mobile, Email = c.Email, CountryID = (int)c.CountryID,Country=c.Country });
        }

        public int DeleteContact(int ContactID)
        {
            return context.DeleteContact(ContactID);
        }

        public IEnumerable<Countries> GetCountries()
        {
            return context.GetCountries().Select(c => new Countries { CountryID = (int)c.CountryID, Country = c.Country }); ;
        }

        

    }
}