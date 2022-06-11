using CarRental.Business.Abstract;
using CarRental.Core.MvcUI.Concrete;
using CarRental.Entity.Concrete;
using System;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    public class CustomerReviewsController : BaseController<CustomerReview, ICustomerReviewService>
    {
        private readonly ICustomerReviewService _customerReviewService;

        public CustomerReviewsController(ICustomerReviewService customerReviewService) : base(customerReviewService) => _customerReviewService = customerReviewService;

        [HttpPost]
        public override ActionResult Create(CustomerReview entity, HttpPostedFileBase Image) => DataEntry(entity, Image, DataEntryState.Added);

        [HttpPost]
        public override ActionResult Edit(CustomerReview entity, HttpPostedFileBase Image) => DataEntry(entity, Image, DataEntryState.Modified);

        [NonAction]
        private ActionResult DataEntry(CustomerReview entity, HttpPostedFileBase image, DataEntryState dataEntryState)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entity.Image = Utility.SaveFile(image, Server.MapPath("~/Content/img/avatars/"));

                    switch (dataEntryState)
                    {
                        case DataEntryState.Added:
                            {
                                _customerReviewService.Add(entity);
                                return RedirectToAction("Index");
                            }
                        case DataEntryState.Modified:
                            {
                                _customerReviewService.Update(entity);
                                return Redirect($"~/Admin/CustomerReviews/Edit/{entity.Id}");
                            }
                    }
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "Resim yüklerken bir hata oluştu.";
                    ViewBag.GoBackLink = $"/CustomerReviews/{(dataEntryState == DataEntryState.Added ? "Create" : "Edit")}";
                    return View("Error");
                }
            }

            return View(entity);
        }
    }
}