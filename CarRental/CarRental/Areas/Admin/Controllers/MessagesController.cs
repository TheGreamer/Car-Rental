using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;
using System.Web.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class MessagesController : BaseController<Message, IMessageService>
    {
        public MessagesController(IMessageService messageService) : base(messageService)
        {
        }

        [HttpGet]
        public override ActionResult Create() => RedirectToAction("Index");

        [HttpGet]
        public override ActionResult Edit(int? id) => RedirectToAction("Index");

        [HttpGet]
        public override ActionResult ChangeStatus(int? id) => RedirectToAction("Index");
    }
}