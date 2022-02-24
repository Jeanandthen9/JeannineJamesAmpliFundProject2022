using Car.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car.Logic.Interfaces
{
    public interface ICarServices
    {
        IEnumerable<CarDataToViewModel> GetAllCars();
        void CreateCar(CarDataToViewModel newCar);
        CarDataToViewModel FindCar(int carId);
        void UpdateCar(CarDataToViewModel car);
        void RemoveCar(int carId);
    }
}
