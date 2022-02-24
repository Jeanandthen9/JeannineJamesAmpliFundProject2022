using Car.Data.Context;
using Car.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car.UI.Controllers
{
    public class OwnerShowcaseController : Controller
    {
        private readonly AmplifundProjectContext _context;

        public OwnerShowcaseController(AmplifundProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region GET ALL OWNERS
        [HttpGet]
        public List<OwnerViewModel> GetAllOwners()
        {
            var ownerList = new List<OwnerViewModel>();
            return ownerList;
        }
        #endregion

        #region EDIT OWNER

        [HttpGet]
        public IActionResult EditOwner(int ownerId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditOwner(OwnerViewModel ownerVM)
        {
            return View();
        }
        #endregion

        #region DELETE OWNER
        [HttpGet]
        public IActionResult DeleteOwner(int ownerId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteOwner(OwnerViewModel ownerVM)
        {
            return View();
        }
        #endregion

        #region CREATE OWNER
        [HttpGet]
        public IActionResult CreateOwner(int ownerId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateOwner(OwnerViewModel ownerVM)
        {
            return View();
        }
        #endregion
    }
}
