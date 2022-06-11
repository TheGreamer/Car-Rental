using System.Web.Mvc;
using CarRental.Areas.Admin.Models.ViewModels;
using CarRental.Business.Abstract;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.MvcUI.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarImageService _carImageService;

        public CarsController(ICarService carService, ICarImageService carImageService)
        {
            _carService = carService;
            _carImageService = carImageService;
        }

        [HttpGet]
        public ActionResult Index() => View(new AdminCarListModel()
        {
            Cars = _carService.GetAll(),
            CarImages = _carImageService.GetAll()
        });

        [HttpGet]
        public ActionResult Details(int? id) => GetCarById(id, true);

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(car);
                return RedirectToAction("Index");
            }

            return View(car);
        }

        [HttpGet]
        public ActionResult Edit(int? id) => GetCarById(id);

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Update(car);
                return Redirect($"~/Admin/Cars/Edit/{car.Id}");
            }

            return View(car);
        }

        [HttpGet]
        public ActionResult ChangeStatus(int? id) => GetCarById(id, changeStatus: true);
        
        [HttpGet]
        public ActionResult Delete(int? id) => GetCarById(id);

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _carImageService.GetAll(c => c.CarId == id).ForEach(i => _carImageService.Delete(i));
            _carService.Delete(_carService.GetById(id));
            return Content(Utility.RedirectWithMessage("Araba silindi. Listeye yönlendiriliyorsunuz.", "Admin/Cars", duration: 1.0));
        }

        [NonAction]
        public ActionResult GetCarById(int? id, bool getCarImages = false, string errorMessage = "Araba bulunamadı.", string goBackLink = "/Cars/Index", bool changeStatus = false)
        {
            if (id == null)
                return Content(Utility.RedirectWithMessage("Hatalı işlem gerçekleşti. Listeye yönlendiriliyorsunuz.", "Admin/Cars"));

            Car car = _carService.GetById((int)id);

            if (car == null)
            {
                ViewBag.PanelErrorMessage = errorMessage;
                ViewBag.GoBackLink = goBackLink;
                return View("Error");
            }

            if (getCarImages)
            {
                return View(new AdminCarWithImagesModel()
                {
                    Car = car,
                    CarImages = _carImageService.GetAll(c => c.CarId == id)
                });
            }
            else
            {
                if (changeStatus)
                {
                    car.Status = car.Status == Status.Active ? Status.Passive : Status.Active;
                    _carService.Update(car);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(car);
                }
            }
        }
    }
}