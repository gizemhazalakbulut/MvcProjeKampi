using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public PartialViewResult ContactListMenu()
        {
            ViewBag.gelenmesajlar = mm.GetListInbox().Count();
            ViewBag.gidenmesajlar = mm.GetListSendbox().Count();
            ViewBag.iletisim= cm.GetList().Count();

            return PartialView();
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetByID(id);
            return View(contactValue);
        }
    }
}