using CarRental.Business.Abstract;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.MvcUI.Concrete;
using CarRental.Entity.Concrete;
using CarRental.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarImageService _carImageService;

        public CarController(ICarService carService, ICarImageService carImageService)
        {
            _carService = carService;
            _carImageService = carImageService;
        }

        [HttpGet]
        public ActionResult Index() => View(new CarListModel()
        {
            Cars = _carService.GetAll(c => c.Status == Status.Active),
            CarImages = _carImageService.GetAll(c => c.Status == Status.Active)
        });

        [HttpPost]
        public ActionResult Index(string name, double monthlyPayment, int year) => View(new CarListModel()
        {
            Cars = _carService.GetAll(c => c.Name.Contains(name) && c.MonthlyPayment <= monthlyPayment && c.Year >= year && c.Status == Status.Active),
            CarImages = _carImageService.GetAll(c => c.Status == Status.Active)
        });

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return Content(Utility.RedirectWithMessage("Hatalı işlem gerçekleşti. Listeye yönlendiriliyorsunuz.", "Car"));

            Car car = _carService.GetById((int)id);

            if (car == null)
            {
                ViewBag.ErrorMessage = "Araba bulunamadı.";
                return View("Error");
            }

            return View(new CarWithImagesModel()
            {
                Car = car,
                CarImages = _carImageService.GetAll(c => c.CarId == id && c.Status == Status.Active),
                SimiliarCars = _carService.GetAll(s => (s.GasolineType == car.GasolineType || s.GearType == car.GearType || Math.Abs(s.KilometersPerLiter - car.KilometersPerLiter) <= 10) && s.Id != car.Id && car.Status == Status.Active),
                SimiliarCarImages = _carImageService.GetAll(c => c.Status == Status.Active)
            });
        }
    }
}