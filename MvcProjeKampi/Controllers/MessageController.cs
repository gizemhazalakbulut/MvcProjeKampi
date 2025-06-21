using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Message = EntityLayer.Concrete.Message;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message
        public ActionResult Inbox()
        {
            var messagelist = cm.GetListInbox(); 
            return View(messagelist);
        }

        public ActionResult Sendbox()
        {
            var messagelist = cm.GetListSendbox();
            return View(messagelist);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var value = cm.GetByID(id);
            return View(value);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var value = cm.GetByID(id);
            return View(value);
        }
    }
}