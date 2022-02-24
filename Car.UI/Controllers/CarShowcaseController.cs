using Car.Data.Context;
using Car.Logic.Enums;
using Car.Logic.Interfaces;
using Car.Logic.Models;
using Car.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Car.UI.Controllers
{
    public class CarShowcaseController : Controller
    {
        private readonly ICarServices _carService;

        public CarShowcaseController(ICarServices carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vmList = GetAllCars();
            return View(vmList);
        }

        #region GET ALL CARS
        public IEnumerable<CarViewModel> GetAllCars()
        {
            var carServiceList = _carService.GetAllCars();

            var carsVMList = new List<CarViewModel>();

            foreach (var car in carServiceList)
            {
                var carVM = MapToViewModel(car);

                carsVMList.Add(carVM);
            }

            return carsVMList;
        }
        #endregion

        #region GET CAR DETAILS
        public IActionResult GetCarDetails(int carId)
        {
            var contextResult = _carService.FindCar(carId);

            var carVM = MapToViewModel(contextResult);

            return PartialView("~/Views/CarShowcase/_GetCarDetailsPartial.cshtml", carVM);
        }
        #endregion

        #region EDIT CAR

        [HttpGet]
        public IActionResult EditCar(int carId)
        {
            var contextResult = _carService.FindCar(carId);

            var carVM = MapToViewModel(contextResult);

            return PartialView("~/Views/CarShowcase/_EditCarPartial.cshtml", carVM);
        }
        [HttpPost]
        public IActionResult EditCar(CarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/CarShowcase/_EditCarPartial.cshtml", carVM);
            }

            var carDVM = MapToDataViewModel(carVM);

            _carService.UpdateCar(carDVM);

            return RedirectToAction("Index", "CarShowcase");
        }
        #endregion

        #region DELETE CAR
        [HttpGet]
        public IActionResult DeleteCar(int carId)
        {
            var contextResult = _carService.FindCar(carId);

            var carVM = MapToViewModel(contextResult);


            return PartialView("~/Views/CarShowcase/_DeleteCarPartial.cshtml", carVM);
        }
        [HttpPost]
        public IActionResult DeleteCarConfirm(int carId)
        {
            _carService.RemoveCar(carId);

            return RedirectToAction("Index", "CarShowcase");
        }
        #endregion

        #region CREATE CAR
        [HttpGet]
        public IActionResult CreateCar()
        {
            var carVM = new CarViewModel();

            return PartialView("~/Views/CarShowcase/_CreateCarPartial.cshtml", carVM);
        }
        [HttpPost]
        public IActionResult CreateCar(CarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/CarShowcase/_CreateCarPartial.cshtml", carVM);
            }

            var carDVM = MapToDataViewModel(carVM);

            _carService.CreateCar(carDVM);

            return RedirectToAction("Index", "CarShowcase");
        }
        #endregion

        private CarViewModel MapToViewModel(CarDataToViewModel car)
        {
            var carVM = new CarViewModel();
            carVM.Name = car.Name;
            carVM.Description = car.Description;
            carVM.Id = car.Id;
            carVM.Year = car.Year;
            carVM.IsConvertable = car.IsConvertable;
            carVM.Color = car.Color;

            return carVM;
        }

        private CarDataToViewModel MapToDataViewModel(CarViewModel car)
        {
            var carDVM = new CarDataToViewModel();
            carDVM.Name = car.Name;
            carDVM.Description = car.Description;
            carDVM.Id = car.Id;
            carDVM.Year = car.Year;
            carDVM.IsConvertable = car.IsConvertable;
            carDVM.Color = car.Color;

            return carDVM;
        }
    }
}
