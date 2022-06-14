using CarRental.Areas.Admin.Models.ViewModels;
using CarRental.Business.Abstract;
using CarRental.Core.Entity.Concrete;
using CarRental.CustomAttributes;
using CarRental.Entity.Concrete;
using System;
using System.Web.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
    [AdminCheck]
    public class DeviceMovementsController : Controller
    {
        private readonly IDeviceMovementService _deviceMovementService;
        private readonly IDeviceService _deviceService;

        public DeviceMovementsController(IDeviceMovementService deviceMovementService, IDeviceService deviceService)
        {
            _deviceMovementService = deviceMovementService;
            _deviceService = deviceService;
        }

        [HttpGet]
        public ActionResult Create() => View(new DeviceMovementModel()
        {
            Devices = _deviceService.GetAll(d => d.Status == Status.Active)
        });

        [HttpPost]
        public ActionResult Create(DeviceMovement deviceMovement, int DeviceId)
        {
            DeviceMovement deviceMovementToAdd = deviceMovement;
            deviceMovementToAdd.DeviceId = DeviceId;
            deviceMovementToAdd.CurrentDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _deviceMovementService.Add(deviceMovementToAdd);
                return RedirectToAction("Index", "Dashboard");
            }

            return View(deviceMovement);
        }
    }
}