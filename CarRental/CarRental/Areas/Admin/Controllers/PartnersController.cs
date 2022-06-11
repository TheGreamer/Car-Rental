using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;
using System;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class PartnersController : BaseController<Partner, IPartnerService>
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService) : base(partnerService) => _partnerService = partnerService;

        [HttpPost]
        public override ActionResult Create(Partner entity, HttpPostedFileBase Image) => DataEntry(entity, Image, DataEntryState.Added);

        [HttpPost]
        public override ActionResult Edit(Partner entity, HttpPostedFileBase Image) => DataEntry(entity, Image, DataEntryState.Modified);

        [NonAction]
        private ActionResult DataEntry(Partner entity, HttpPostedFileBase image, DataEntryState dataEntryState)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entity.Image = Utility.SaveFile(image, Server.MapPath("~/Content/img/partners/"));

                    switch (dataEntryState)
                    {
                        case DataEntryState.Added:
                            {
                                _partnerService.Add(entity);
                                return RedirectToAction("Index");
                            }
                        case DataEntryState.Modified:
                            {
                                _partnerService.Update(entity);
                                return Redirect($"~/Admin/Partners/Edit/{entity.Id}");
                            }
                    }
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "Resim yüklerken bir hata oluştu.";
                    ViewBag.GoBackLink = $"/Partners/{(dataEntryState == DataEntryState.Added ? "Create" : "Edit")}";
                    return View("Error");
                }
            }

            return View(entity);
        }
    }
}