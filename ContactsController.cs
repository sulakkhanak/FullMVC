using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sulakkhana_Contacts.Models;
using Sulakkhana_Contacts.BusinessLayer;

namespace Sulakkhana_Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private Repository rule;

        private ContactDB_SulakkhanaEntities context = new ContactDB_SulakkhanaEntities();

        public ContactsController()
        {
            rule = new Repository(new ContactDB_SulakkhanaEntities());
        }

        //
        // GET: /Contacts/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetContacts()
        {
            var con = rule.GetContacts().ToList();
            return Json(con, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateContact(Contacts contact)
        {
            return Json(rule.CreateContact(contact), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountries()
        {
            var CusData = rule.GetCountries().ToList();
            return Json(CusData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateContact(Contacts contact)
        {
            return Json(rule.UpdateContact(contact), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteContact(int ContactID)
        {
            return Json(rule.DeleteContact(ContactID), JsonRequestBehavior.AllowGet);
        }
	}
}