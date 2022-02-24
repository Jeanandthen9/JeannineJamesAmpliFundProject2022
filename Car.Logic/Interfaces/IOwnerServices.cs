using Car.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Logic.Interfaces
{
    public interface IOwnerServices
    {
        IEnumerable<OwnerDataToViewModel> GetAllOwners();
        void CreateOwner(int ownerId);
        OwnerDataToViewModel FindOwner(int ownerId);
        void UpdateOwner(int ownerId);
        void RemoveOwner(int ownerId);
    }
}
