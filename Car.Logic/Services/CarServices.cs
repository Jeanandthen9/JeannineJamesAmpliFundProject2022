using Car.Data.Context;
using Car.Logic.Enums;
using Car.Logic.Interfaces;
using Car.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Logic.Services
{
    public class CarServices : ICarServices
    {

        private readonly AmplifundProjectContext _context;

        public CarServices(AmplifundProjectContext context)
        {
            _context = context;
        }

        public void CreateCar(CarDataToViewModel newCar)
        {
            var dbCar = new Car.Data.Models.Car();

            dbCar = MapViewModelToDataModel(newCar);

            _context.Cars.Add(dbCar);
            _context.SaveChanges();
        }

        public CarDataToViewModel FindCar(int carId)
        {
            var contextResult = _context.Cars.Where(c => c.Id == carId).FirstOrDefault();

            var result = new CarDataToViewModel();

            if (contextResult != null)
            {
                result = MapDataModelToViewModel(contextResult);
            }

            return result;
        }

        public IEnumerable<CarDataToViewModel> GetAllCars()
        {
            var contextResults = _context.Cars.ToList();

            var results = new List<CarDataToViewModel>();

            foreach(var cr in contextResults)
            {
                var car = MapDataModelToViewModel(cr);

                results.Add(car);
            }

            return results;
        }

        public void RemoveCar(int carId)
        {
            var contextResult = _context.Cars.Where(c => c.Id == carId).FirstOrDefault();

            if (contextResult != null)
            {
                _context.Cars.Remove(contextResult);
                _context.SaveChanges();
            }
        }

        public void UpdateCar(CarDataToViewModel car)
        {
            var oldContextResult = _context.Cars.Where(c => c.Id == car.Id).FirstOrDefault();

            if (oldContextResult != null)
            {
                var updatedContext = MapViewModelToDataModel(car);
                _context.Entry(oldContextResult).CurrentValues.SetValues(updatedContext);   
                _context.SaveChanges();
            }
        }

        private CarDataToViewModel MapDataModelToViewModel(Car.Data.Models.Car cr)
        {
            var car = new CarDataToViewModel();

            car.Id = cr.Id;
            car.Name = cr.Name;
            car.Description = cr.Description;
            car.Year = cr.Year;
            car.IsConvertable = cr.IsConvertable;
            car.Color = (Colors)Enum.Parse(typeof(Colors), cr.Color, true);

            return car;
        }

        private Car.Data.Models.Car MapViewModelToDataModel(CarDataToViewModel cr)
        {
            var car = new Car.Data.Models.Car();

            car.Id = cr.Id;
            car.Name = cr.Name;
            car.Description = cr.Description;
            car.Year = cr.Year;
            car.IsConvertable = cr.IsConvertable;
            car.Color = cr.Color.ToString();

            return car;
        }
    }
}
